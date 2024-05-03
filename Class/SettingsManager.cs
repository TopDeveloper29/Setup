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
        public static Setting CurrentSetting { get; set; } = null;
        public static void Load(string Path = null)
        {
            if (CurrentSetting == null)
            {
                if (Path == null) { Path = $@"{AppDomain.CurrentDomain.BaseDirectory}\config.json"; }
                if (File.Exists(Path))
                {
                    CurrentSetting = JsonConvert.DeserializeObject<Setting>(File.ReadAllText(Path));
                }
                else
                {
                    CurrentSetting = new Setting();
                }
                if (CurrentSetting.ExecutableName == null)
                {
                    string DS = SetupManager.ParsePath(CurrentSetting.DataSource);
                    if (Directory.Exists(DS))
                    { 
                        CurrentSetting.ExecutableName = FindDefaultExe(DS);
                    }
                }
            }
        }
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
                RegistryKeys = new List<RegistryItem> { new RegistryItem { Path = @"HKLM\SOFTWARE\My App", Name = "MyMachineKey", Value = "MyMachineValue" }, new RegistryItem { Path = @"HKCU\SOFTWARE\My App", Name = "MyUserKey", Value = "MyUserValue" } }
            };
            string json = JsonConvert.SerializeObject(SampleSetting, settings);
            File.WriteAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\config.json", json);
        }
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
    }
    internal class Setting
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
    public class RegistryItem
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class CheckBoxConfig
    {
        public bool Visible { get; set; }
        public bool Enable { get; set; }
        public bool Checked { get; set; }
    }
    public enum AppArchitechture
    {
        X64,
        X86
    }
}
