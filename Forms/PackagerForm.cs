using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace Setup.Forms
{
    public partial class PackagerForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        // Hold if Packager create temporary file that required a clean-up at close
        public bool DataCleanRequired = false;
        public PackagerForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }
        private void PackagerForm_Load(object sender, EventArgs e)
        {
            if (SettingsManager.IsSystemInDarkMode())
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                RegistryView.BackgroundColor = Color.FromArgb(65, 65, 65);

                RegistryView.EnableHeadersVisualStyles = false;
                DataGridViewCellStyle Style;

                Style = new DataGridViewCellStyle { BackColor = Color.FromArgb(85, 85, 85), ForeColor = Color.White,SelectionBackColor = Color.FromArgb(95, 95, 95), SelectionForeColor = Color.LightGray };
                foreach (DataGridViewColumn col in RegistryView.Columns)
                {
                    col.DefaultCellStyle = Style;
                }
                foreach (DataGridViewRow row in RegistryView.Rows)
                {
                    row.DefaultCellStyle = Style;
                }

                Style = new DataGridViewCellStyle { BackColor = Color.FromArgb(54, 70, 78), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(64, 80, 88), SelectionForeColor = Color.LightGray };
                RegistryView.RowHeadersDefaultCellStyle = Style;
                RegistryView.ColumnHeadersDefaultCellStyle = Style;
                
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        // Load config file to current setting object
        public void LoadConfig(string ConfigPath)
        {
            SettingsManager.Load(ConfigPath);

            // Common information
            AppPath.Text = SettingsManager.Current.DataSource ?? string.Empty;
            AppName.Text = SettingsManager.Current.Name;
            AppVersion.Text = SettingsManager.Current.Version;
            AppPublisher.Text = SettingsManager.Current.Publisher;
            ExecutableName.Text = SettingsManager.Current.ExecutableName;
            DefaultPath_Editable.Checked = SettingsManager.Current.PathIsEditable;
            Architechture.Text = SettingsManager.Current.Architecture.ToString();
            ExecutableName.Text = SettingsManager.Current.ExecutableName ?? string.Empty;
            IconName.Text = SettingsManager.Current.Icon?.Split('\\').Last() ?? string.Empty;

            // Desktop
            Desktop_Visible.Checked = SettingsManager.Current.DesktopCheckBox.Visible;
            Desktop_Enable.Checked = SettingsManager.Current.DesktopCheckBox.Enable;
            Desktop_Checked.Checked = SettingsManager.Current.DesktopCheckBox.Checked;

            // Start-Menu
            StartMenu_Visible.Checked = SettingsManager.Current.StartMenuCheckBox.Visible;
            StartMenu_Enable.Checked = SettingsManager.Current.StartMenuCheckBox.Enable;
            StartMenu_Checked.Checked = SettingsManager.Current.StartMenuCheckBox.Checked;

            // Start-Up
            StartUp_Visible.Checked = SettingsManager.Current.StartUpCheckBox.Visible;
            StartUp_Enable.Checked = SettingsManager.Current.StartUpCheckBox.Enable;
            StartUp_Checked.Checked = SettingsManager.Current.StartUpCheckBox.Checked;

            // Default Path
            if (!string.IsNullOrWhiteSpace(SettingsManager.Current.Path))
            {
                DefaultPath_CustomMode.Checked = true;
                Default_InstallPath.Text = SettingsManager.Current.Path;
            }
            else
            {
                DefaultPath_DefaultMode.Checked = true;
                Default_InstallPath.Text = string.Empty;
            }

            // Registry keys
            RegistryView.Rows.Clear();
            if (SettingsManager.Current.RegistryKeys != null && SettingsManager.Current.RegistryKeys.Count > 0)
            {
                foreach (RegistryItem Item in SettingsManager.Current.RegistryKeys)
                {
                    RegistryView.Rows.Add(Item.Type.ToString(), Item.Path, Item.Name, Item.Value);
                }
            }
        }
        
        // Update the Current setting object and json file
        public void SaveConfig()
        {
            SettingsManager.Current = new Setting
            {
                Name = AppName.Text,
                Version = AppVersion.Text,
                Publisher = AppPublisher.Text,
                ExecutableName = ExecutableName.Text,
                PathIsEditable = DefaultPath_Editable.Checked,
                DesktopCheckBox = new CheckBoxConfig
                {
                    Visible = Desktop_Visible.Checked,
                    Enable = Desktop_Enable.Checked,
                    Checked = Desktop_Checked.Checked
                },
                StartMenuCheckBox = new CheckBoxConfig
                {
                    Visible = StartMenu_Visible.Checked,
                    Enable = StartMenu_Enable.Checked,
                    Checked = StartMenu_Checked.Checked
                },
                StartUpCheckBox = new CheckBoxConfig
                {
                    Visible = StartUp_Visible.Checked,
                    Enable = StartUp_Enable.Checked,
                    Checked = StartUp_Checked.Checked
                },
                DataSource = AppPath.Text
            };


            // Architecture
            switch (Architechture.Text.ToLower())
            {
                default:
                case "x64":
                    SettingsManager.Current.Architecture = AppArchitechture.X64;
                    break;
                case "x86":
                    SettingsManager.Current.Architecture = AppArchitechture.X86;
                    break;
            }

            // Default Path
            if (Default_InstallPath.Enabled)
            { SettingsManager.Current.Path = Default_InstallPath.Text; }
            else
            { SettingsManager.Current.Path = null; }

            // Executable Path
            if (string.IsNullOrWhiteSpace(ExecutableName.Text)) { SettingsManager.Current.ExecutableName = null; }
            else { SettingsManager.Current.ExecutableName = ExecutableName.Text; }

            // Icon Name
            if (string.IsNullOrWhiteSpace(IconName.Text)) { SettingsManager.Current.Icon = null; }
            else
            {
                if (SetupType.Text == "Setup and data folder" || SetupType.Text == "Setup, config and data folder")
                {
                    SettingsManager.Current.Icon = $@".\data\{IconName.Text}";
                }
                else
                {
                    SettingsManager.Current.Icon = $@".\data.bin\{IconName.Text}";
                }
            }

            // Registry keys
            SettingsManager.Current.RegistryKeys = null;
            if (RegistryView.Rows.Count > 1)
            {
                SettingsManager.Current.RegistryKeys = new List<RegistryItem>();
                foreach (DataGridViewRow Item in RegistryView.Rows)
                {
                    if (!Item.IsNewRow)
                    {
                        Enum.TryParse(Item.Cells[0].Value?.ToString() ?? "HKLM",out RegType Type);
                        string Path = Item.Cells[1].Value?.ToString() ?? string.Empty;
                        string Name = Item.Cells[2].Value?.ToString() ?? string.Empty;
                        string Value = Item.Cells[3].Value?.ToString() ?? string.Empty;
                        SettingsManager.Current.RegistryKeys.Add(new RegistryItem { Type = Type, Path = Path, Name = Name, Value = Value });
                    }
                }
            }
            SaveToJson();
        }
        
        // Update json file base on current setting object
        private void SaveToJson()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = { new StringEnumConverter() },
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(SettingsManager.Current, settings);
            File.WriteAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\temp.json", json);
        }

        // Enable or diable editing and exporting in the form (if a folder is not loaded)
        public void EditAndExport(bool Enable = true)
        {
            Save.Enabled = Enable;
            Body.Enabled = Enable;
            Export.Enabled = Enable;
            if (Enable == false)
            { AppPath.Text = string.Empty; }
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            // Reset the Edit and Export state to off
            EditAndExport(false);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                Filter = "Application/Setup (*.exe)|*.exe|Config File (.json)|*.json",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Grab basic information about selected file
                FileInfo fileinfo = new FileInfo(openFileDialog.FileName);

                // If file is an exe perform some test on it else it will only load json config file
                if (fileinfo.Extension == ".exe")
                {
                    // Grab binary information of a exe file
                    string ExeBin = File.ReadAllText(fileinfo.FullName);
                    
                    // Check if the binary contain pkg flag if yes process it as setup else process it as normal exe
                    if (ExeBin != null && ExeBin.Contains("!pkg|START|pkg!") && ExeBin.Contains("!pkg|END|pkg!"))
                    {
                        try
                        {
                            // Get global bin data including flag with file name
                            string EmbedPackageBin = ExeBin.Split(new string[] { "!pkg|START|pkg!" }, StringSplitOptions.None)[1].Split(new string[] { "!pkg|END|pkg!" }, StringSplitOptions.None)[0];

                            // Extract the config name and binary to a file
                            string SetupCfgName = EmbedPackageBin.Split(new string[] { "!cfg|" }, StringSplitOptions.None)[1].Split(new string[] { "|cfg!" }, StringSplitOptions.None)[0];
                            string json = PackageManager.Base64ToString(EmbedPackageBin.Split(new string[] { $"!cfg|{SetupCfgName}|cfg!" }, StringSplitOptions.None)[1].Split(new string[] { "!cfg|END|cfg!" }, StringSplitOptions.None)[0]);
                            SettingsManager.LoadFromJson(json);
                            SaveToJson();
                            LoadConfig(SetupManager.ParsePath(@".\temp.json"));

                            // Check if bin flag exist if yes extrac the bin file
                            if (EmbedPackageBin.Contains("!bin|END|bin!"))
                            {
                                DataCleanRequired = true;

                                SetupManager.SetupBinName = EmbedPackageBin.Split(new string[] { "!bin|" }, StringSplitOptions.None)[1].Split(new string[] { "|bin!" }, StringSplitOptions.None)[0];
                                PackageManager.Base64toFile(EmbedPackageBin.Split(new string[] { $"!bin|{SetupManager.SetupBinName}|bin!" }, StringSplitOptions.None)[1].Split(new string[] { "!bin|END|bin!" }, StringSplitOptions.None)[0], SetupManager.SetupBinName);

                                // Extract the binary to temporary folder
                                PackageManager.Extract(SetupManager.ParsePath($@".\{SetupManager.SetupBinName}"), SetupManager.ParsePath(@".\data"));
                                
                                // Set data source to this temporary folder
                                AppPath.Text = SetupManager.ParsePath(@".\data");

                                // Delete the bin file since it now extracted in .\data
                                File.Delete(SetupManager.ParsePath($@".\{SetupManager.SetupBinName}"));

                            }
                            else // if it as no bin flag it normaly mean the datasource is a external file or folder so let deal with it
                            {
                                DataCleanRequired = true;

                                // If datasource is a .bin extract it to temporary folder and set app path to it
                                if (SettingsManager.Current.DataSource.Contains(".bin"))
                                {
                                    string CleanBinName = SettingsManager.Current.DataSource.Replace(@".\", string.Empty);
                                    PackageManager.Extract($@"{fileinfo.Directory}\{CleanBinName}", SetupManager.ParsePath(@".\data"));
                                    AppPath.Text = SetupManager.ParsePath(@".\data");
                                }
                                else // Else if not a bin it a folder so copy the source folder next to current setup instance (temporary folder .\data)
                                {
                                    string CleanDirName = SettingsManager.Current.DataSource.Replace(@".\", string.Empty);
                                    if (Directory.Exists(SetupManager.ParsePath(@".\data")))
                                    { Directory.Delete(SetupManager.ParsePath(@".\data"), true); }
                                    SetupManager.CopyDirectoryContents($@"{fileinfo.Directory}\{CleanDirName}", SetupManager.ParsePath(@".\data"));
                                    AppPath.Text = SetupManager.ParsePath(@".\data");
                                }
                            }
                            EditAndExport();
                        }
                        catch(Exception ex)
                        { MessageBox.Show($"Canot load this setup:\n {ex.Message}"); }
                    }
                    else
                    {
                        // Grab aditional information about the file
                        FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(fileinfo.FullName);

                        // Populate field with exe information
                        AppVersion.Text = fileVersion.FileVersion;
                        AppPublisher.Text = fileVersion.CompanyName;
                        AppPath.Text = fileinfo.Directory.FullName;
                        ExecutableName.Text = fileinfo.Name;
                        AppName.Text = fileinfo.Name.Replace(fileinfo.Extension, string.Empty);

                        // Get fist icon in the folder of the exe
                        foreach (string File in Directory.GetFiles(fileinfo.Directory.FullName))
                        {
                            FileInfo iconinfo = new FileInfo(File);
                            if (iconinfo.Extension == ".ico")
                            {
                                IconName.Text = iconinfo.Name;
                                break;
                            }
                        }

                        DataCleanRequired = false;
                        
                        //Enable editing and update the current setting object and create temp.json
                        EditAndExport();
                        SaveConfig();

                    }
                }
                else
                {
                    // Load json config file
                    LoadConfig(fileinfo.FullName);
                    if (!string.IsNullOrWhiteSpace(AppPath.Text))
                    {
                        if (AppPath.Text.Contains(".bin")) // If datasource of config is a bin temporary extract it to .\data
                        {
                            DataCleanRequired = true;
                            PackageManager.Extract(SetupManager.ParsePath(AppPath.Text), SetupManager.ParsePath(@".\data"));
                            AppPath.Text = SetupManager.ParsePath(@".\data");
                        }
                        else // If not just set the path to folder
                        {
                            DataCleanRequired = false;
                            AppPath.Text = SetupManager.ParsePath(AppPath.Text);
                        }
                        EditAndExport();
                    }
                }
            }
        }        
        private void Export_Click(object sender, EventArgs e)
        {
            SaveConfig(); // Save the config with last information

            // Define some usefull path for export
            string OutputDirName = $"Setup {SettingsManager.Current.Name} {SettingsManager.Current.Version}";
            string OutputDirPath = $"{AppDomain.CurrentDomain.BaseDirectory}{OutputDirName}";
            string ConfigPath = $"{AppDomain.CurrentDomain.BaseDirectory}temp.json";

            // Delete the output directory if it exist and create empty one
            if (Directory.Exists(OutputDirPath))
            { Directory.Delete(OutputDirPath, true); }
            Directory.CreateDirectory(OutputDirPath);

            /* Do action depending of selected Setup Type
             * Always start by changing the DataSource to real one so far it was set to dummy one to alows user to reload temp.json with good information
             * Then save thease change to json
             * Next step is to copy data or create bin if applicable
             * Then create or copy the setup to output folder
             * Finaly move all aplicable file
            */
            switch (SetupType.Text)
            {
                case "Setup and data folder":
                    SettingsManager.Current.DataSource = ".\\data";
                    SaveToJson();
                    SetupManager.CopyDirectoryContents(AppPath.Text, $"{OutputDirPath}\\data");
                    PackageManager.NewExe(ConfigPath, OutputDirName);
                    break;
                case "Self Executable":
                    SettingsManager.Current.DataSource = ".\\_.bin";
                    SettingsManager.Current.Icon = SettingsManager.Current.Icon.Replace("data.bin", "_.bin");
                    SaveToJson();
                    PackageManager.NewBin(AppPath.Text, "_.bin");
                    PackageManager.NewSelfExe(ConfigPath, OutputDirName);
                    File.Delete($"{AppDomain.CurrentDomain.BaseDirectory}_.bin");
                    break;
                case "Setup and data.bin":
                    SettingsManager.Current.DataSource = ".\\data.bin";
                    SaveToJson();
                    PackageManager.NewBin(AppPath.Text, "_.bin");
                    PackageManager.NewExe(ConfigPath, OutputDirName);
                    File.Move($"{AppDomain.CurrentDomain.BaseDirectory}_.bin", $"{OutputDirPath}\\data.bin");
                    break;
                case "Setup, config and data.bin":
                    SettingsManager.Current.DataSource = ".\\data.bin";
                    SaveToJson();
                    PackageManager.NewBin(AppPath.Text, "_.bin");
                    File.Copy(Assembly.GetExecutingAssembly().Location, $"{OutputDirPath}\\Setup.exe");
                    File.Move($"{AppDomain.CurrentDomain.BaseDirectory}temp.json", $"{OutputDirPath}\\config.json");
                    File.Move($"{AppDomain.CurrentDomain.BaseDirectory}_.bin", $"{OutputDirPath}\\data.bin");
                    break;
                case "Setup, config and data folder":
                    SettingsManager.Current.DataSource = ".\\data";
                    SaveToJson();
                    SetupManager.CopyDirectoryContents(AppPath.Text, $"{OutputDirPath}\\data");
                    File.Copy(Assembly.GetExecutingAssembly().Location, $"{OutputDirPath}\\Setup.exe");
                    File.Move($"{AppDomain.CurrentDomain.BaseDirectory}temp.json", $"{OutputDirPath}\\config.json");
                    break;
            }
            // Always remove the temp.json file when export is done
            File.Delete(ConfigPath);
        }
        
        #region Event Handler for Default Mode and Path
        private void DefaultPath_DefaultMode_CheckedChanged(object sender, EventArgs e)
        {
            Default_InstallPath.Enabled = false;
            Browse_Path.Enabled = false;
            Default_InstallPath.Text = string.Empty;
        }
        private void DefaultPath_CustomMode_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
            Default_InstallPath.Enabled = true;
            Browse_Path.Enabled = true;
            Default_InstallPath.Text = SettingsManager.FindDefaultPath(SettingsManager.Current.Architecture, SettingsManager.Current.Name, SettingsManager.Current.Publisher);
        }
        private void Browse_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog
            {
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            };

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Default_InstallPath.Text = openFileDialog.SelectedPath;
            }
        }

        #endregion

        // Save config to temp.json (it can be reload by user to continue editing it after close)
        private void Save_Click(object sender, EventArgs e) { SaveConfig(); }
        
        // Basicly if data clean is required do it on closing
        private void PackagerForm_FormClosing(object sender, FormClosingEventArgs e) { if (DataCleanRequired){ Directory.Delete(AppPath.Text, true); } }

        private void RemoveReg_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in RegistryView.SelectedRows)
            {
                RegistryView.Rows.Remove(Row);
            }
        }
    }
}
