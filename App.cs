using Setup.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Setup
{
    public static class App
    {
        // Hold if setup.exe extract some temporary file that need to be clean on close
        public static bool CleanUpRequired { get; set; } = false; 
        
        // List of args fill in initialization to pass on app rehost as admin
        public static string AppArgs {  get; private set; }

        // The real Main function call in Program.cs
        [STAThread]
        public static void Main(string[] Args)
        {
            //Args = new string[] {"/p"};
            int Index = 0;
            bool Quiet = false;
            string[]InstallArgs = null;
            
            // Process each arguments
            foreach (string arg in Args)
            {
                // Save args for further rehost
                AppArgs += $"{arg} ";

                // Handle args
                switch (arg.ToLower())
                {
                    // Select another config file for setup
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

                    // Toogle quiet mode for setup
                    case "quiet":
                    case "/quiet":
                    case "-quiet":
                    case "/q":
                    case "-q":
                        Quiet = true;
                        break;


                    // Package a self executable setup from a config file
                    case "setup":
                    case "-setup":
                    case "/setup":
                    case "-s":
                    case "/s":
                        try
                        {
                            if (File.Exists(Args[Index + 1]))
                            {
                                PackageManager.NewSelfExe(Args[Index + 1],$"{AppDomain.CurrentDomain.BaseDirectory}Setup");
                            }
                            else { throw new Exception("Folder Not Found"); }
                        }
                        catch
                        {
                            MessageBox.Show($"You must provide a valid config file path next to {arg}", "Path not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Environment.Exit(0);
                        break;
                    
                    // Create a compressed bin file from a folder
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

                    // Create a sample json file
                    case "json":
                    case "/json":
                    case "-json":
                    case "-j":
                    case "/j":
                        SettingsManager.CreateSample();
                        Environment.Exit(0);
                        break;
                   
                    // Run application in packager mode
                    case "packager":
                    case "/packager":
                    case "-packager":
                    case "/p":
                    case "-p":
                        // Always rehost the pacakager as admin because it may require to load file form setup.exe and othe stuff
                        if (!SetupManager.IsUserAdministrator())
                        {
                            Process proc = new Process
                            {
                                StartInfo = new ProcessStartInfo()
                                {
                                    UseShellExecute = true,
                                    WorkingDirectory = Environment.CurrentDirectory,
                                    FileName = Process.GetCurrentProcess().MainModule.FileName,
                                    Arguments = App.AppArgs,
                                    Verb = "runas"
                                }
                            };
                            proc.Start();
                            Environment.Exit(0);
                        }
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new PackagerForm());
                        Environment.Exit(0);
                        break;
                    
                    // Used only for rehost to admin
                    case "/install":
                        try
                        {
                            InstallArgs = Args[Index + 1].Split(',');
                            if (InstallArgs.Length < 2)
                            {
                                throw new Exception("Invalid Args");
                            }
                        }
                        catch
                        {
                            MessageBox.Show($"You must provide a list of argument for install", "Args not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(0);
                        }
                        break;

                    // Used for developement purpose to get Unistall.exe as base64
                    case "/utb64":
                        try
                        {
                            if (File.Exists(Args[Index + 1]))
                            {
                                Clipboard.SetText(PackageManager.FileToBase64(Args[Index + 1]));
                                Environment.Exit(0);
                            }
                        }
                        catch { MessageBox.Show("Provide a valid path to uninstall.exe next to /utb64 argument", "Intended to developer only", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        break;

                    // Afficher un message d'aide
                    case "help":
                    case "/help":
                    case "-help":
                    case "/?":
                    case "-?":
                        Process.Start("https://github.com/TopDeveloper29/Setup/blob/master/README.md");
                        Environment.Exit(0);
                        break;
                }
                Index++;
            }

            // Get current bin and check if it hold a package
            string ExeBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
            if (ExeBin != null && ExeBin.Contains("!pkg|START|pkg!") && ExeBin.Contains("!pkg|END|pkg!"))
            {
                if (!SetupManager.IsUserAdministrator())
                {
                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            WorkingDirectory = Environment.CurrentDirectory,
                            FileName = Process.GetCurrentProcess().MainModule.FileName,
                            Arguments = AppArgs,
                            Verb = "runas"
                        }
                    };
                    proc.Start();
                    return;
                }
                // if yes extract data of it
                try
                {
                    // Get global bin data including flag with file name
                    string EmbedPackageBin = ExeBin.Split(new string[] { "!pkg|START|pkg!" }, StringSplitOptions.None)[1].Split(new string[] { "!pkg|END|pkg!" }, StringSplitOptions.None)[0];

                    // get file name and separate flag with it to get bin of cfg
                    string SetupCfgName = EmbedPackageBin.Split(new string[] { "!cfg|" }, StringSplitOptions.None)[1].Split(new string[] { "|cfg!" }, StringSplitOptions.None)[0];
                    string json = PackageManager.Base64ToString(EmbedPackageBin.Split(new string[] { $"!cfg|{SetupCfgName}|cfg!" }, StringSplitOptions.None)[1].Split(new string[] { "!cfg|END|cfg!" }, StringSplitOptions.None)[0]);
                    SettingsManager.LoadFromJson(json);

                    // get file name and separate flag with it to get bin of .bin
                    if (EmbedPackageBin.Contains("!bin|END|bin!"))
                    {
                        CleanUpRequired = true;
                        SetupManager.SetupBinName = EmbedPackageBin.Split(new string[] { "!bin|" }, StringSplitOptions.None)[1].Split(new string[] { "|bin!" }, StringSplitOptions.None)[0];
                        PackageManager.Base64toFile(EmbedPackageBin.Split(new string[] { $"!bin|{SetupManager.SetupBinName}|bin!" }, StringSplitOptions.None)[1].Split(new string[] { "!bin|END|bin!" }, StringSplitOptions.None)[0], SetupManager.SetupBinName);
                    }
                    Thread.Sleep(1500);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,ex.Source,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            // Load default setting (if already load it skip it)
            SettingsManager.Load();

            // If argument quiet is pass run install without lauch the UI
            if (Quiet)
            {
                string InstallPath = string.Empty;
                
                // If a path is not specify in config find the default path depending of architecture
                if (string.IsNullOrWhiteSpace(SettingsManager.Current.Path))
                {
                    InstallPath = SettingsManager.FindDefaultPath(SettingsManager.Current.Architecture, SettingsManager.Current.Name, SettingsManager.Current.Publisher);
                }
                else
                {
                    InstallPath = SettingsManager.Current.Path;
                }

                // Launch Istall using setting apply by config
                SetupManager.Install(InstallPath,SettingsManager.Current.DesktopCheckBox.Checked, SettingsManager.Current.StartMenuCheckBox.Checked, SettingsManager.Current.StartUpCheckBox.Checked);
                Environment.Exit(0);
            }
            else
            {
                // If application as not be runned with /install run it normaly else just perform install (grab param from non admin UI)
                if (InstallArgs == null)
                {
                    // Open setup normaly
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SetupForm());
                }
                else
                {
                    // If user was not admin in UI it rehost application at install time and pass argument /install "Path,Desktop,StartMenu,StartUp"
                    SetupManager.Install(InstallArgs[0], bool.Parse(InstallArgs[1]), bool.Parse(InstallArgs[2]), bool.Parse(InstallArgs[3]));
                    Environment.Exit(0);
                }
            }
        }
    }
}
