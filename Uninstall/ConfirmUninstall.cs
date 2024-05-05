using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uninstall
{
    public partial class ConfirmUninstall : MaterialForm
    {
        public ConfirmUninstall(string Title)
        {
            InitializeComponent();

            Text = Title;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (IsSystemInDarkMode())
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        // Grab from registry if system is in dark mode or not
        public static bool IsSystemInDarkMode()
        {
            const string keyName = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string valueName = "AppsUseLightTheme";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value is int intValue)
                    {
                        return intValue == 0;
                    }
                }
            }
            return false;
        }

        private void KeepData_CheckedChanged(object sender, EventArgs e)
        {
            if (KeepData.Checked)
            {
                YesBt.DialogResult = DialogResult.Ignore;
            }
            else
            {
                YesBt.DialogResult = DialogResult.Yes;
            }
        }
    }
}
