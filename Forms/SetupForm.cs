using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
            try
            {
                if (SettingsManager.CurrentSetting.PathIsEditable == false)
                {
                    InstallPath.ReadOnly = true;
                    Browse.Enabled = false;
                }

                Text = $"Install {SettingsManager.CurrentSetting.Name} from {SettingsManager.CurrentSetting.Publisher} Version: {SettingsManager.CurrentSetting.Version}";
                Desktop.Visible = SettingsManager.CurrentSetting.DesktopCheckBox.Visible;
                Desktop.Enabled = SettingsManager.CurrentSetting.DesktopCheckBox.Enable;
                Desktop.Checked = SettingsManager.CurrentSetting.DesktopCheckBox.Checked;
                StartMenu.Visible = SettingsManager.CurrentSetting.StartMenuCheckBox.Visible;
                StartMenu.Enabled = SettingsManager.CurrentSetting.StartMenuCheckBox.Enable;
                StartMenu.Checked = SettingsManager.CurrentSetting.StartMenuCheckBox.Checked;
                startup.Visible = SettingsManager.CurrentSetting.StartUpCheckBox.Visible;
                startup.Enabled = SettingsManager.CurrentSetting.StartUpCheckBox.Enable;
                startup.Checked = SettingsManager.CurrentSetting.StartUpCheckBox.Checked;

                if (string.IsNullOrWhiteSpace(SettingsManager.CurrentSetting.Path))
                {
                    InstallPath.Text = SettingsManager.FindDefaultPath(SettingsManager.CurrentSetting.Architecture, SettingsManager.CurrentSetting.Name, SettingsManager.CurrentSetting.Publisher);
                }
                else
                {
                    InstallPath.Text = SettingsManager.CurrentSetting.Path;
                }

                if (!string.IsNullOrEmpty(SettingsManager.CurrentSetting.Icon))
                {
                    if (SettingsManager.CurrentSetting.Icon.Contains(".bin"))
                    {
                        string[] Path = SetupManager.ParsePath(SettingsManager.CurrentSetting.Icon).Split(new string[] { ".bin" }, StringSplitOptions.None);
                        Icon = PackageManager.GetIcon($"{Path[0]}.bin", Path[1]);
                        ShowIcon = true;
                    }
                    else
                    {
                        Icon = new Icon(SetupManager.ParsePath(SettingsManager.CurrentSetting.Icon));
                        ShowIcon = true;
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Cancel_Click(object sender, EventArgs e) { Environment.Exit(0); }
        private void Install_Click(object sender, EventArgs e)
        {
            SetupManager.Install(InstallPath.Text,Desktop.Checked,StartMenu.Checked,startup.Checked);
            Environment.Exit(0);
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = InstallPath.Text;
            folderBrowserDialog.ShowDialog();
            InstallPath.Text = $"{folderBrowserDialog.SelectedPath}\\{SettingsManager.CurrentSetting.Publisher}\\{SettingsManager.CurrentSetting.Name}";
        }
    }
}
