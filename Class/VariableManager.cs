using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup.Class
{
    internal static class VariableManager
    {
        private static Dictionary<string,string> Variables = new Dictionary<string,string>();
        public static void Set(SetupVariable Name, string Value = null)
        {
            if (Value == null) { Value = string.Empty; }
            if(Variables.ContainsKey(Name.ToString()))
            {
                Variables[Name.ToString()] = Value;
            }
            else
            {
                Variables.Add(Name.ToString(), Value);
            }
        }
        public static string Get(SetupVariable Name)
        {
            if (Variables.ContainsKey(Name.ToString()))
            {
                return Variables[Name.ToString()];
            }
            return null;
        }
        public static string Parse(string Text)
        {
            string ParsedText = Text;
            if (Variables.Count > 0)
            {
                foreach (string VariableKey in Variables.Keys)
                {
                    ParsedText = ParsedText.Replace($"[{VariableKey}]", Variables[VariableKey]);
                }
            }
            return ParsedText;
        }

    }
    public enum SetupVariable
    {
        Name,
        Version,
        InstallPath,
        Architecture,
        Publisher,
        ExecutableName
    }
}
