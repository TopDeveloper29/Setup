using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;

namespace Setup
{
    internal static class SetupManager
    {
        public static bool SetupHoldPackage
        {
            get
            {
                if (SetupBin != null && SetupBinName != null && SetupCfgName != null)
                { return true; }
                else 
                { return false; }
            }
        }
        public static string SetupBin { get; set; }
        public static string SetupBinName { get; set; }
        public static string SetupCfgName { get; set; }

        public static void AddShortcut(string shortcutLocation, string pathToExe, string IconPath = null)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.Description = SettingsManager.CurrentSetting.Name;
            if (IconPath != null) { shortcut.IconLocation = IconPath; }
            shortcut.TargetPath = pathToExe;
            shortcut.Save();
        }
        public static string ParsePath(string Path) { return Path.Replace(@".\", AppDomain.CurrentDomain.BaseDirectory); }
        public static Reg ParseRegistryKey(RegistryItem RegistryKey)
        {
            Enum.TryParse<RegType>(RegistryKey.Path.Split(new string[] { @"\" }, StringSplitOptions.None)[0], out RegType Type);
            return new Reg { Type = Type, Path = RegistryKey.Path.Replace($@"{Type}\", string.Empty) };
        }
        public static void Install(string Path, bool Desktop, bool StartMenu, bool StartUp)
        {
            string publicDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            string programDataStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs";
            string publiclnkpath = $@"{publicDesktopPath}\{SettingsManager.CurrentSetting.Name}.lnk";
            string programlnkpath = $@"{programDataStartMenuPath}\{SettingsManager.CurrentSetting.Name}.lnk";
            string AditionalUninstall = string.Empty;
            string AppIconPath = null;

            // Handle any aditional string to uninstall
            if (Desktop) { AditionalUninstall += $"&& del /F \"{publiclnkpath}\""; }
            if (StartMenu) { AditionalUninstall += $" && del /F \"{programlnkpath}\""; }
            if (StartUp) { AditionalUninstall += $" && \"C:\\WINDOWS\\system32\\reg.exe\" DELETE \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\" /v \"{SettingsManager.CurrentSetting.Name}\" /f"; }

            // Register application
            string Reg3264 = string.Empty;

            switch (SettingsManager.CurrentSetting.Architecture)
            {
                case AppArchitechture.X64:
                    Reg3264 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
                    break;
                case AppArchitechture.X86:
                    Reg3264 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";
                    break;
            }
            RegistryKey key = Registry.LocalMachine.CreateSubKey($"{Reg3264}{SettingsManager.CurrentSetting.Name}",true,RegistryOptions.None);
            if (key != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(SettingsManager.CurrentSetting.Icon))
                    {
                        if (SettingsManager.CurrentSetting.Icon.Contains(".bin"))
                        {
                            AppIconPath = $@"{Path}\{SettingsManager.CurrentSetting.Icon.Split(new string[] { ".bin" }, StringSplitOptions.None)[1]}";
                        }
                        else
                        {
                            string RawPath = ParsePath(SettingsManager.CurrentSetting.Icon);
                            System.IO.File.Copy(RawPath, Path);
                            AppIconPath = $@"{Path}\{RawPath.Split(new string[] { @"\" }, StringSplitOptions.None).Last()}";
                        }
                        key.SetValue("DisplayIcon", AppIconPath);
                    }
                    key.SetValue("DisplayName", SettingsManager.CurrentSetting.Name);
                    key.SetValue("DisplayVersion", SettingsManager.CurrentSetting.Version);
                    key.SetValue("Publisher", SettingsManager.CurrentSetting.Publisher);
                    key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                    key.SetValue("NoModify", 1);
                    key.SetValue("NoRepair", 1);
                    key.SetValue("UninstallString", $"C:\\WINDOWS\\system32\\cmd.exe /C RMDIR /S /Q \"{Path}\" && \"C:\\WINDOWS\\system32\\reg.exe\" DELETE \"HKEY_LOCAL_MACHINE\\{Reg3264}{SettingsManager.CurrentSetting.Name}\" /f {AditionalUninstall}");
                }
                finally
                {
                    key.Close();
                }
            }

            // Create directory
            if (Directory.Exists(Path))
            {
                Directory.Delete(Path, true);
                Directory.CreateDirectory(Path);
            }
            else
            { Directory.CreateDirectory(Path); }

            // Copy file
            if (SettingsManager.CurrentSetting.DataSource.Contains(".bin"))
            {
                string DS = ParsePath(SettingsManager.CurrentSetting.DataSource);
                if(System.IO.File.Exists(DS))
                {
                    PackageManager.Extract(DS, Path);
                }
            }
            else
            {
                string DS = ParsePath(SettingsManager.CurrentSetting.DataSource);
                if (Directory.Exists(DS))
                {
                    System.IO.File.Copy(DS, Path);
                }
            }

            // Registry settings
            if (SettingsManager.CurrentSetting.RegistryKeys != null && SettingsManager.CurrentSetting.RegistryKeys.Count > 0)
            {
                foreach (RegistryItem Item in SettingsManager.CurrentSetting.RegistryKeys)
                {
                    Reg ItemReg = ParseRegistryKey(Item);
                    string ItemPath = ItemReg.Path;
                    string Name = Item.Name;
                    string Value = Item.Value;

                    switch (ItemReg.Type)
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

            // Create shortcut if they selected
            if (Desktop)
            {
                AddShortcut(publiclnkpath, $@"{Path}\{SettingsManager.CurrentSetting.ExecutableName}", AppIconPath);
            }

            if (StartMenu)
            {
                AddShortcut(programlnkpath, $@"{Path}\{SettingsManager.CurrentSetting.ExecutableName}", AppIconPath);
            }

            // add to start-up if selected
            if (StartUp)
            {
                using (RegistryKey rrkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", writable: true))
                { if (rrkey != null) { rrkey.SetValue(SettingsManager.CurrentSetting.Name, $@"{Path}\{SettingsManager.CurrentSetting.ExecutableName}"); } }
            }
            if (SetupHoldPackage)
            {
                System.IO.File.Delete($"{AppDomain.CurrentDomain.BaseDirectory}{SetupCfgName}");
                System.IO.File.Delete($"{AppDomain.CurrentDomain.BaseDirectory}{SetupBinName}");
            }
        }
    }
    public class Reg
    {
        public RegType Type { get; set; }
        public string Path { get; set; }
    }
    public enum RegType { HKLM, HKCU }
}
