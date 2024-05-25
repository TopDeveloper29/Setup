using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Setup.Class
{
    internal static class UninstallManager
    {
        public static Information Current { get; set; }

        public static void Load(string Name, string installPath, string Desktop, string StartMenu, bool StartUp, AppArchitechture appArchitechture, List<RegistryItem> registryItems,List<string> Scripts)
        {
            Current = new Information();
            Current.Name = Name;
            Current.InstallPath = installPath;
            Current.DektopIcon = Desktop;
            Current.StartMenuIcon = StartMenu;
            Current.StartUp = StartUp;
            Current.Architechture = appArchitechture;
            Current.RegistryKeys = registryItems;
            Current.PowershellScripts = Scripts;
        }
        public static string ToBase64()
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
            string json = JsonConvert.SerializeObject(Current, settings);
            byte[] fileBytes = Encoding.UTF8.GetBytes(json);
            string base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }
        public class Information
        {
            public string Name { get; set; }
            public string InstallPath { get; set; }
            public string DektopIcon { get; set; }
            public string StartMenuIcon { get; set; }
            public bool StartUp { get; set; }
            public AppArchitechture Architechture { get; set; }
            public List<RegistryItem> RegistryKeys { get; set; }
            public List<string> PowershellScripts { get; set; }
        }
    }
}
