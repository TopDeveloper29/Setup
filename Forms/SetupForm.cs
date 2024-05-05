using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Setup
{
    public partial class SetupForm : MaterialForm
    {

        public SetupForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (SettingsManager.IsSystemInDarkMode())
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            try
            {
                // Populate all data with loaded config
                if (SettingsManager.Current.PathIsEditable == false)
                {
                    InstallPath.ReadOnly = true;
                    Browse.Enabled = false;
                }

                Text = $"Install {SettingsManager.Current.Name} from {SettingsManager.Current.Publisher} Version: {SettingsManager.Current.Version}";
                Desktop.Visible = SettingsManager.Current.DesktopCheckBox.Visible;
                Desktop.Enabled = SettingsManager.Current.DesktopCheckBox.Enable;
                Desktop.Checked = SettingsManager.Current.DesktopCheckBox.Checked;
                StartMenu.Visible = SettingsManager.Current.StartMenuCheckBox.Visible;
                StartMenu.Enabled = SettingsManager.Current.StartMenuCheckBox.Enable;
                StartMenu.Checked = SettingsManager.Current.StartMenuCheckBox.Checked;
                StartUp.Visible = SettingsManager.Current.StartUpCheckBox.Visible;
                StartUp.Enabled = SettingsManager.Current.StartUpCheckBox.Enable;
                StartUp.Checked = SettingsManager.Current.StartUpCheckBox.Checked;

                // if path is null populate it now with default
                if (string.IsNullOrWhiteSpace(SettingsManager.Current.Path))
                {
                    InstallPath.Text = SettingsManager.FindDefaultPath(SettingsManager.Current.Architecture, SettingsManager.Current.Name, SettingsManager.Current.Publisher);
                }
                else
                {
                    InstallPath.Text = SettingsManager.Current.Path;
                }

                // Get current depending if it in bin or else where
                if (!string.IsNullOrEmpty(SettingsManager.Current.Icon))
                {
                    if (SettingsManager.Current.Icon.Contains(".bin"))
                    {
                        string[] Path = SetupManager.ParsePath(SettingsManager.Current.Icon).Split(new string[] { ".bin" }, StringSplitOptions.None);
                        Icon = PackageManager.GetIcon($"{Path[0]}.bin", Path[1]);
                        ShowIcon = true;
                        AppIcon.Image = Icon.ToBitmap();
                    }
                    else
                    {
                        Icon = new Icon(SetupManager.ParsePath(SettingsManager.Current.Icon));
                        AppIcon.Image = Icon.ToBitmap();
                        ShowIcon = true;
                    }
                }
                else
                {
                    Header.Controls.Remove(AppIcon);
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        // Close setup without installing
        private void Cancel_Click(object sender, EventArgs e) { Close(); }

        // Perforn install and close setup 
        private void Install_Click(object sender, EventArgs e)
        {
            SetupManager.Install(InstallPath.Text,Desktop.Checked,StartMenu.Checked,StartUp.Checked);
            Close();
        }

        // Show the folder dialog
        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = InstallPath.Text;
            folderBrowserDialog.ShowDialog();
            InstallPath.Text = $"{folderBrowserDialog.SelectedPath}\\{SettingsManager.Current.Publisher}\\{SettingsManager.Current.Name}";
        }

        // If clean-up is required do it on clossing
        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (App.CleanUpRequired)
            {
                if (SetupManager.SetupBinName != null)
                {
                    File.Delete(SetupManager.ParsePath($@".\{SetupManager.SetupBinName}"));
                }
                App.CleanUpRequired = false;
            }
        }
    }
}
