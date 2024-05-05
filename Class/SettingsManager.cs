using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Setup
{
    internal static class SettingsManager
    {
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
        
        // The current setting the app as load
        public static Setting Current { get; set; } = null;

        // Populate current setting ExecutableName whit default one if it was null
        private static void PopulateExeIfPathNull()
        {
            if (Current.ExecutableName == null)
            {
                string DS = SetupManager.ParsePath(Current.DataSource);
                if (Directory.Exists(DS) || File.Exists(DS))
                {
                    Current.ExecutableName = FindDefaultExe(DS);
                }
            }
        }

        // Load setting from a config file
        public static void Load(string Path = null)
        {
            if (Current == null)
            {
                if (Path == null) { Path = $@"{AppDomain.CurrentDomain.BaseDirectory}\config.json"; }
                if (File.Exists(Path))
                {
                    LoadFromJson(File.ReadAllText(Path));
                }
                else
                {
                    Current = new Setting();
                    PopulateExeIfPathNull();
                }

            }
        }

        // Load setting from json
        public static void LoadFromJson(string Json)
        {
            Current = JsonConvert.DeserializeObject<Setting>(Json);
            PopulateExeIfPathNull();
        }
        
        // Export a sample config.json when passing /json argument
        public static void CreateSample()
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

            Setting SampleSetting = new Setting {
                Path = FindDefaultPath(AppArchitechture.X64, "My App", "My Compagny"),
                StartMenuCheckBox = new CheckBoxConfig { Checked = true },
                RegistryKeys = new List<RegistryItem> { new RegistryItem { Type = RegType.HKLM, Path = @"SOFTWARE\My App", Name = "MyMachineKey", Value = "MyMachineValue" }, new RegistryItem { Type = RegType.HKCU, Path = @"SOFTWARE\My App", Name = "MyUserKey", Value = "MyUserValue" } }
            };
            string json = JsonConvert.SerializeObject(SampleSetting, settings);
            File.WriteAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\config.json", json);
        }

        #region Find default value for setting
        public static string FindDefaultExe(string DataPath)
        {
            if (DataPath.ToLower().Contains(".bin"))
            {
                return PackageManager.GetFirstExeName(DataPath);
            }
            else
            {
                foreach(var file in Directory.GetFiles(DataPath))
                {
                    FileInfo info = new FileInfo(file);
                    if (info.Extension == "exe")
                    {
                        return info.Name;
                    }
                }
                return "My App.exe";
            }
        }
        public static string FindDefaultDataSource()
        {
            if (File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\data.bin"))
            {
                return $@".\data.bin";
            }
            else if (Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\data"))
            {
                return $@".\data";
            }
            else
            {
                return string.Empty;
            }

        }
        public static string FindDefaultPath(AppArchitechture Architechture, string Name,string Publisher)
        {
            string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            switch (Architechture)
            {
                case AppArchitechture.X64:
                    BasePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).Replace(" (x86)", string.Empty);
                    break;
                case AppArchitechture.X86:
                    BasePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    break;
            }

            return $@"{BasePath}\{Publisher}\{Name}";
        }
        #endregion
    }

    // The setting object that saved as json in config.json file
    public class Setting
    {
        public string Name { get; set; } = "My App";
        public string Version { get; set; } = "1.0.0.0";
        public string Publisher { get; set; } = "My Compagny";
        public string Icon { get; set; } = string.Empty;
        public string DataSource { get; set; } = SettingsManager.FindDefaultDataSource();
        public string ExecutableName { get; set; } = null;
        public AppArchitechture Architecture { get; set; } = AppArchitechture.X64;
        public string Path { get; set; } = string.Empty;
        public bool PathIsEditable { get; set; } = true;
        public CheckBoxConfig DesktopCheckBox { get; set; } = new CheckBoxConfig { Enable = true, Checked = false, Visible = false };
        public CheckBoxConfig StartMenuCheckBox { get; set; } = new CheckBoxConfig { Enable = true, Checked = false, Visible = false };
        public CheckBoxConfig StartUpCheckBox { get; set; } = new CheckBoxConfig { Enable = true, Checked = false, Visible = false };
        public List<RegistryItem> RegistryKeys { get; set; }
    }
    
    // Item in setting that basicly represent a Registry key
    public class RegistryItem
    {
        public RegType Type { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    // Item in setting that bascily reprensen some property of a checkbox that user can configure
    public class CheckBoxConfig
    {
        public bool Visible { get; set; }
        public bool Enable { get; set; }
        public bool Checked { get; set; }
    }
    
    // App architechture X64 or X86
    public enum AppArchitechture
    {
        X64,
        X86
    }

    // Reg item location availaible HKLM and HKCU *** To implement HKLU and HKU ***
    public enum RegType { HKLM, HKCU, HKLU, HKU }

}
