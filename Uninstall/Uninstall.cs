using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static Uninstall.UninstallManager;

namespace Uninstall
{
    internal class Uninstall
    {
        // The real Main function call in Program.cs
        [STAThread]
        public static void Main(string[] Args)
        {
            bool Quiet = false;
            bool KeepData = false;
            foreach (string arg in Args)
            {
                switch (arg.ToLower())
                {
                    case "quiet":
                    case "/quiet":
                    case "-quiet":
                    case "-q":
                    case "/q":
                    case "-silent":
                    case "/silent":
                    case "/s":
                    case "-s":
                        Quiet = true;
                        break;
                    case "keepdata":
                    case "/keepdata":
                    case "-keepdata":
                    case "-k":
                    case "/k":
                        KeepData = true;
                        break;

                    default:
                        MessageBox.Show("Here valid argument:\n\n" +
                            "Perform uninstall without UI:\nquiet, /quiet, -quiet, -q, /q, -silent, /s, -s\n\n" +
                            "When running silently by default it will remove application data with this you can specify to keep data\n" +
                            "keepdata, /keepdata, -keepdata, -k, /k","Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                        
                }
            }
           
            string CurrentBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
            if (CurrentBin.Contains("!json|START|json!") && CurrentBin.Contains("!json|END|json!"))
            {
                string CurrentBase64 = CurrentBin.Split(new string[] { "!json|START|json!" },StringSplitOptions.None).Last().Split(new string[] { "!json|END|json!" }, StringSplitOptions.None).First();
                string Json = Base64ToString(CurrentBase64);
                Load(Json);

                if(Current != null)
                {
                    DialogResult Result = DialogResult.No;
                    if (Quiet)
                    {
                        if (KeepData)
                        {
                            Result = DialogResult.Ignore;
                        }
                        else
                        {
                            Result = DialogResult.Yes;
                        }
                    }
                    else
                    {
                        Result = new ConfirmUninstall($"Do you want to uninstall {Current.Name}?").ShowDialog();
                    }
                    if (Result == DialogResult.Yes || Result == DialogResult.Ignore)
                    {
                        string Reg3264 = string.Empty;
                        switch (Current.Architechture)
                        {
                            case AppArchitechture.X64:
                                Reg3264 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
                                break;
                            case AppArchitechture.X86:
                                Reg3264 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";
                                break;
                        }

                        RegistryKey key = Registry.LocalMachine.CreateSubKey($"{Reg3264}", true, RegistryOptions.None);
                        key.DeleteSubKeyTree(Current.Name);

                        // Remove desktop icon if exist
                        if (!string.IsNullOrEmpty(Current.DektopIcon) && File.Exists(Current.DektopIcon))
                        {File.Delete(Current.DektopIcon); }

                        // Remove start menu icon if it exist
                        if (!string.IsNullOrEmpty(Current.StartMenuIcon) && File.Exists(Current.StartMenuIcon))
                        { File.Delete(Current.StartMenuIcon); }

                        // Remove application from start-up if it was set
                        if (Current.StartUp)
                        {
                            using (RegistryKey rrkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", writable: true))
                            { if (rrkey != null) { rrkey.DeleteSubKey(Current.Name); } }
                        }

                        // If the result is not ingore (Keep data option) wipe registry setting
                        if (Result == DialogResult.Yes && Current.RegistryKeys != null && Current.RegistryKeys.Count > 0)
                        {
                            foreach (RegistryItem Item in Current.RegistryKeys)
                            {
                                string ItemPath = Item.Path;
                                switch (Item.Type)
                                {
                                    case RegType.HKLM:
                                        Registry.LocalMachine.DeleteSubKey(ItemPath);
                                        break;

                                    case RegType.HKCU:
                                        Registry.CurrentUser.DeleteSubKey(ItemPath);
                                        break;
                                }
                            }
                        }

                        foreach (string Scripts in Current.PowershellScripts)
                        {
                            PowershellManager.Run(Scripts);
                        }

                        // Delete application directory and add key to next logon to clean-up the remaining item
                        Directory.Delete(Current.InstallPath, true);
                        using (RegistryKey rrkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", true))
                        { rrkey.SetValue(Current.Name, $@"""{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\system32\cmd.exe"" /C RMDIR /S /Q ""{Current.InstallPath}""");  }

                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                MessageBox.Show("Uninstaller is not configured yet uninstallation is abord !!!", "Unintaller not configure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
