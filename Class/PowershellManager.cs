using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Setup.Class
{
    internal class PowershellManager
    {
        public static void Run(string Script)
        {
            Process Powershell = new Process();
            Powershell.StartInfo = new ProcessStartInfo
            {
                FileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\System32\WindowsPowerShell\v1.0\powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -WindowStyle Hidden -NonInteractive -NoProfile -NoLogo -EncodedCommand \"{Encode(Script)}\"",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Powershell.Start();
            Powershell.WaitForExit();
        }
        private static string Encode(string Scripts)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(Scripts);
            return Convert.ToBase64String(bytes);
        }

    }
}
