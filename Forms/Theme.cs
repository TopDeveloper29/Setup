using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup
{
    public static class Theme
    {
        public static MaterialSkinManager Manager = MaterialSkinManager.Instance;
        public static void Init(MaterialForm Form)
        {
            Manager.AddFormToManage(Form);
            if (SettingsManager.IsSystemInDarkMode())
            {
                Manager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                Manager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            Manager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
    }
}
