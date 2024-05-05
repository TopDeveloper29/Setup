using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Uninstall
{
    public static class UninstallManager
    {
        public static Information Current;
        public static void Load(string json) { Current = JsonConvert.DeserializeObject<Information>(json); }

        public class Information
        {
            public string Name { get; set; }
            public string InstallPath { get; set; }
            public string DektopIcon { get; set; }
            public string StartMenuIcon { get; set; }
            public bool StartUp { get; set; }
            public AppArchitechture Architechture { get; set; }
            public List<RegistryItem> RegistryKeys { get; set; }
        }
        public static string Base64ToString(string bytes)
        {
            byte[] fileBytes = Convert.FromBase64String(bytes);
            return Encoding.UTF8.GetString(fileBytes);
        }

        // Item in setting that basicly represent a Registry key
        public class RegistryItem
        {
            public RegType Type { get; set; }
            public string Path { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
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

}
