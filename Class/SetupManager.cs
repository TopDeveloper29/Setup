using IWshRuntimeLibrary;
using Microsoft.Win32;
using Setup.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Windows.Forms;

namespace Setup
{
    // All method use to copy data and install the application on system but alos all method to parse object and string
    internal static class SetupManager
    {
        // Hold the name of the temporay extracted file to read it later or delete it at close
        public static string SetupBinName { get; set; }

        // Create a shortcut in windows
        public static void AddShortcut(string shortcutLocation, string pathToExe, string IconPath = null)
        {
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.Description = SettingsManager.Current.Name;
                if (IconPath != null) { shortcut.IconLocation = IconPath; }
                shortcut.TargetPath = pathToExe;
                shortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Fail to create link", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Parse path (replace all character by full path)
        public static string ParsePath(string Path) { return VariableManager.Parse(Path.Replace(@".\", AppDomain.CurrentDomain.BaseDirectory)); }

        // Validate if user as admin right
        public static bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                isAdmin = false;
            }

            return isAdmin;
        }
        
        // Copy all file of a directory exlcluding the directory itself
        public static void CopyDirectoryContents(string sourceDir, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);

            // Copy each file into the new directory
            foreach (string filePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(filePath);
                string destFile = Path.Combine(destinationDir, fileName);
                System.IO.File.Copy(filePath, destFile, true);
            }

            // Copy each subdirectory using recursion
            foreach (string directoryPath in Directory.GetDirectories(sourceDir))
            {
                string directoryName = Path.GetFileName(directoryPath);
                string destDirectory = Path.Combine(destinationDir, directoryName);
                CopyDirectoryContents(directoryPath, destDirectory);
            }
        }

        // Perform the install of application on system
        public static void Install(string Path, bool Desktop, bool StartMenu, bool StartUp)
        {
            // Rehost as admin if not already
            if (!IsUserAdministrator())
            {
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo() 
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Process.GetCurrentProcess().MainModule.FileName,
                        Arguments = $"{App.AppArgs} /install \"{Path},{Desktop},{StartMenu},{StartUp}\"",
                        Verb = "runas"
                    }
                };
                proc.Start();
                return;
            }
            
            // base variable for thesetup
            string publicDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            string programDataStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs";
            string publiclnkpath = $@"{publicDesktopPath}\{SettingsManager.Current.Name}.lnk";
            string programlnkpath = $@"{programDataStartMenuPath}\{SettingsManager.Current.Name}.lnk";
            string AppIconPath = null;
            string UninstallerName = "Uninstall.exe";
            string CurrentPath = ParsePath(@".\Uninstall.exe");
            string UninstallerPath = $@"{Path}\{UninstallerName}";

            // Set-up environement variable
            VariableManager.Set(SetupVariable.Name, SettingsManager.Current.Name);
            VariableManager.Set(SetupVariable.Version, SettingsManager.Current.Version);
            VariableManager.Set(SetupVariable.InstallPath, Path);
            VariableManager.Set(SetupVariable.Publisher, SettingsManager.Current.Publisher);
            VariableManager.Set(SetupVariable.Architecture, SettingsManager.Current.Architecture.ToString());
            VariableManager.Set(SetupVariable.ExecutableName, SettingsManager.Current.ExecutableName);

            // Create directory
            try
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                    Directory.CreateDirectory(Path);
                }
                else
                { Directory.CreateDirectory(Path); }
            }
            catch
            { MessageBox.Show("Fail to create installation directory", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            // Register application
            try
            {
                string Reg3264 = string.Empty;

                switch (SettingsManager.Current.Architecture)
                {
                    case AppArchitechture.X64:
                        Reg3264 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
                        break;
                    case AppArchitechture.X86:
                        Reg3264 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";
                        break;
                }
                RegistryKey key = Registry.LocalMachine.CreateSubKey($"{Reg3264}{SettingsManager.Current.Name}", true, RegistryOptions.None);
                if (key != null)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(SettingsManager.Current.Icon))
                        {
                            if (SettingsManager.Current.Icon.Contains(".bin"))
                            {
                                AppIconPath = $@"{Path}\{SettingsManager.Current.Icon.Split(new string[] { ".bin" }, StringSplitOptions.None)[1]}";
                            }
                            else
                            {
                                string RawPath = ParsePath(SettingsManager.Current.Icon);
                                System.IO.File.Copy(RawPath, Path);
                                AppIconPath = $@"{Path}\{RawPath.Split(new string[] { @"\" }, StringSplitOptions.None).Last()}";
                            }
                            key.SetValue("DisplayIcon", AppIconPath);
                        }
                        key.SetValue("DisplayName", SettingsManager.Current.Name);
                        key.SetValue("DisplayVersion", SettingsManager.Current.Version);
                        key.SetValue("Publisher", SettingsManager.Current.Publisher);
                        key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                        key.SetValue("NoModify", 1);
                        key.SetValue("NoRepair", 1);
                        key.SetValue("UninstallString", $"{UninstallerPath}");
                    }
                    finally
                    {
                        key.Close();
                    }
                }
            }
            catch
            { MessageBox.Show("Fail to register application in registry", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            // Copy file
            try
            {
                
                if (SettingsManager.Current.DataSource.Contains(".bin"))
                {
                    string DS = ParsePath(SettingsManager.Current.DataSource);
                    if (System.IO.File.Exists(DS))
                    {
                        PackageManager.Extract(DS, Path);
                    }
                }
                else
                {
                    CopyDirectoryContents(ParsePath(SettingsManager.Current.DataSource), Path);
                }
            }
            catch
            { MessageBox.Show("Fail to copy application file", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            // Registry settings
            List<RegistryItem> ParsedRegistryItems = new List<RegistryItem>();
            try
            {
                
                if (SettingsManager.Current.RegistryKeys != null && SettingsManager.Current.RegistryKeys.Count > 0)
                {
                    foreach (RegistryItem Item in SettingsManager.Current.RegistryKeys)
                    {
                        string ItemPath = VariableManager.Parse(Item.Path);
                        string Name = VariableManager.Parse(Item.Name);
                        string Value = VariableManager.Parse(Item.Value);
                        ParsedRegistryItems.Add(new RegistryItem { Name = Name, Path = ItemPath, Value = Value, Type = Item.Type });

                        switch (Item.Type)
                        {
                            case RegType.HKLM:
                                using (RegistryKey rkey = Registry.LocalMachine.OpenSubKey(ItemPath, true))
                                {
                                    if (rkey == null)
                                    {
                                        Registry.LocalMachine.CreateSubKey(ItemPath).SetValue(Name, Value);
                                    }
                                    else
                                    {
                                        rkey.SetValue(Name, Value, RegistryValueKind.String);
                                    }
                                }
                                break;

                            case RegType.HKCU:
                                using (RegistryKey rkey = Registry.CurrentUser.OpenSubKey(ItemPath, true))
                                {
                                    if (rkey == null)
                                    {
                                        Registry.CurrentUser.CreateSubKey(ItemPath).SetValue(Name, Value);
                                    }
                                    else
                                    {
                                        rkey.SetValue(Name, Value, RegistryValueKind.String);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch
            { MessageBox.Show("Fail to create custom registry settings", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            // Create shortcut if they selected
            if (Desktop)
            {
                AddShortcut(publiclnkpath, $@"{Path}\{SettingsManager.Current.ExecutableName}", AppIconPath);
            }
            if (StartMenu)
            {
                AddShortcut(programlnkpath, $@"{Path}\{SettingsManager.Current.ExecutableName}", AppIconPath);
            }

            // add to start-up if selected
            if (StartUp)
            {
                try
                {
                    using (RegistryKey rrkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", writable: true))
                    { if (rrkey != null) { rrkey.SetValue(SettingsManager.Current.Name, $@"{Path}\{SettingsManager.Current.ExecutableName}"); } }
                }
                catch
                { MessageBox.Show("Fail to register application in start-up", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            // Run post install scripts
            foreach (string Scripts in SettingsManager.Current.PowershellScripts.Values)
            {
                PowershellManager.Run(VariableManager.Parse(Scripts));
            }

            // Parse uninstaller script
            List<string> ParsedScripts = new List<string>();
            foreach (string Script in SettingsManager.Current.UninstallScripts.Values)
            {
                ParsedScripts.Add(VariableManager.Parse(Script));
            }


            // Create the unistaller with good information
            try
            {
                // Poupulate the unistall information object with good information
                UninstallManager.Load(SettingsManager.Current.Name, Path, publicDesktopPath, programlnkpath, StartUp, SettingsManager.Current.Architecture, ParsedRegistryItems, ParsedScripts);
                // Create the unistaller
                PackageManager.Base64toFile(Properties.Resources.Base64Uninstall, UninstallerName);
                System.IO.File.Move(CurrentPath, UninstallerPath);

                // Populate the installer with information in base64
                string Output = string.Empty;
                Output += "\n!json|START|json!\n";
                Output += UninstallManager.ToBase64();
                Output += "\n!json|END|json!";
                System.IO.File.AppendAllText(UninstallerPath, Output);
            }
            catch
            {
                MessageBox.Show("Fail to create and copy application uninstaller", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clean temp file
            if (App.CleanUpRequired)
            {
                if (SetupBinName != null)
                {
                    System.IO.File.Delete(ParsePath($@".\{SetupBinName}"));
                }
                App.CleanUpRequired = false;
            }
        }
    }
}
