using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup
{
    public static class App
    {
        [STAThread]
        public static void Main(string[] Args)
        {
            int Index = 0;
            bool Quiet = false;
            foreach (string arg in Args)
            {
                switch (arg.ToLower())
                {
                    case "setup":
                    case "-setup":
                    case "/setup":
                    case "-s":
                    case "/s":
                        try
                        {
                            if (File.Exists(Args[Index + 1]))
                            {
                                PackageManager.NewExe(Args[Index + 1]);
                            }
                            else { throw new Exception("Folder Not Found"); }
                        }
                        catch
                        {
                            MessageBox.Show($"You must provide a valid config file path next to {arg}", "Path not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Environment.Exit(0);
                        break;
                    
                    case "newbin":
                    case "/newbin":
                    case "-newbin":
                    case "/n":
                    case "-n":
                        try
                        {
                            if (Directory.Exists(Args[Index+1]))
                            {
                                PackageManager.NewBin(Args[Index+1]);
                            }
                            else { throw new Exception("Folder Not Found"); }
                        }
                        catch
                        {
                            MessageBox.Show($"You must provide a valid folder path next to {arg}", "Path not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Environment.Exit(0);
                        break;

                    case "config":
                    case "/config":
                    case "-config":
                    case "/c":
                    case "-c":
                        try
                        {
                            if (File.Exists(Args[Index + 1]))
                            {
                                SettingsManager.Load(Args[Index + 1]);
                            }
                            else { throw new Exception("File Not Found"); }
                        }
                        catch
                        {
                            MessageBox.Show($"You must provide a valid file path next to {arg}", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    
                    case "json":
                    case "/json":
                    case "-json":
                    case "-j":
                    case "/j":
                        SettingsManager.CreateSample();
                        Environment.Exit(0);
                        break;

                    case "quiet":
                    case "/quiet":
                    case "-quiet":
                    case "/q":
                    case "-q":
                        Quiet = true;
                        break;
                    
                    default:
                    case "help":
                    case "/help":
                    case "-help":
                    case "/?":
                    case "-?":
                        MessageBox.Show("This is availaible command line to run or create package for setup.exe\n\n" +
                            
                            "*Note each argument as multiple variation for conveniance.\n" +
                            " Example: Quiet will also work with this\n" +
                            " -Quiet /Quiet -Q /Q\n\n" +

                            "=== Setup Option ===\n" +

                            "Quiet : Run Setup.exe silently without UI, note you can configure setup using config.json file\n\n" +

                            "Config [Config Path] : this alow to specify a config file by default app look for config.json.\n\n" +
                            
                            "=== Packaging Option ===\n" +
                            "The best way to proceed is first generate a bin file or create a \"data\" folder next to setup.exe then generate a new config.json and finaly create a self executable setup.exe\n\n" +

                            "NewBin [Folder Path] : This allow to package a folder to a compressed bin file that can be use as data source for setup.\n\n" +

                            "Json : This will create a new config.json holding all property that could be configure in setup. Note none of them are mandatory\n\n" +

                            "Setup [Config Path] : This allow you to create a setup.exe that will hold both config and data, you must specify path to a valid config.json that the datasource is set to a .bin file.\n\n"

                        , "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                        break;
                }
                Index++;
            }

            // Get current bin and check if it hold a package
            string ExeBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
            if (ExeBin != null && ExeBin.Contains("!pkg|START|pkg!") && ExeBin.Contains("!pkg|END|pkg!"))
            {
                // if yes extract data of it
                try
                {
                    // Get global bin data including flag with file name
                    string EmbedPackageBin = ExeBin.Split(new string[] { "!pkg|START|pkg!" }, StringSplitOptions.None)[1].Split(new string[] { "!pkg|END|pkg!" }, StringSplitOptions.None)[0];

                    // get file name and separate flag with it to get bin of cfg
                    SetupManager.SetupCfgName = EmbedPackageBin.Split(new string[] { "!cfg|" }, StringSplitOptions.None)[1].Split(new string[] { "|cfg!" }, StringSplitOptions.None)[0];
                    PackageManager.BytesToFile(EmbedPackageBin.Split(new string[] { $"!cfg|{SetupManager.SetupCfgName}|cfg!" }, StringSplitOptions.None)[1].Split(new string[] { "!cfg|END|cfg!" }, StringSplitOptions.None)[0], SetupManager.SetupCfgName);
                    
                    // get file name and separate flag with it to get bin of .bin
                    SetupManager.SetupBinName = EmbedPackageBin.Split(new string[] { "!bin|" }, StringSplitOptions.None)[1].Split(new string[] { "|bin!" }, StringSplitOptions.None)[0];
                    SetupManager.SetupBin = EmbedPackageBin.Split(new string[] { $"!bin|{SetupManager.SetupBinName}|bin!" }, StringSplitOptions.None)[1].Split(new string[] { "!bin|END|bin!" }, StringSplitOptions.None)[0];
                    PackageManager.BytesToFile(SetupManager.SetupBin, SetupManager.SetupBinName);
                    Thread.Sleep(1500);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,ex.Source,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            SettingsManager.Load();
            if (Quiet)
            {
                string InstallPath = string.Empty;
                if (string.IsNullOrWhiteSpace(SettingsManager.CurrentSetting.Path))
                {
                    InstallPath = SettingsManager.FindDefaultPath(SettingsManager.CurrentSetting.Architecture, SettingsManager.CurrentSetting.Name, SettingsManager.CurrentSetting.Publisher);
                }
                else
                {
                    InstallPath = SettingsManager.CurrentSetting.Path;
                }

                SetupManager.Install(InstallPath,SettingsManager.CurrentSetting.DesktopCheckBox.Checked, SettingsManager.CurrentSetting.StartMenuCheckBox.Checked, SettingsManager.CurrentSetting.StartUpCheckBox.Checked);
                Environment.Exit(0);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SetupForm());
            }
        }
    }
}
