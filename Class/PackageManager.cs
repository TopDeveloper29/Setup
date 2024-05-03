using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Setup
{
    internal static class PackageManager
    {
        public static string FileToByte(string Path)
        {
            byte[] fileBytes = File.ReadAllBytes(Path);
            string base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }
        public static void BytesToFile(string bytes, string name)
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
            byte[] fileBytes = Convert.FromBase64String(bytes);
            File.WriteAllBytes(fullPath, fileBytes);
            File.SetAttributes(fullPath, File.GetAttributes(fullPath) | FileAttributes.Hidden);
        }
        public static void NewExe(string path)
        {
            if (path.ToLower().Contains(".json"))
            {
                string ExeBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
                if (ExeBin != null && !ExeBin.Contains("!pkg|START|pkg!") && !ExeBin.Contains("!pkg|END|pkg!"))
                {
                    SettingsManager.Load(SetupManager.ParsePath(path));
                    if (SettingsManager.CurrentSetting.DataSource.ToLower().Contains(".bin"))
                    {
                        string CfgName = path.Split(new string[] { @"\" }, StringSplitOptions.None)[1];
                        string BinName = SettingsManager.CurrentSetting.DataSource.Split(new string[] { @"\" }, StringSplitOptions.None)[1];
                        string NewExePath = $"{AppDomain.CurrentDomain.BaseDirectory}{Assembly.GetEntryAssembly().Location.Split(new string[] { @"\" }, StringSplitOptions.None).Last().Split('.')[0]} {SettingsManager.CurrentSetting.Name}.exe";
                        File.Copy(Assembly.GetEntryAssembly().Location, NewExePath);
                        string PackageHold = string.Empty;
                        PackageHold += "!pkg|START|pkg!\n";
                        PackageHold += $"!cfg|{CfgName}|cfg!\n";
                        PackageHold += FileToByte(SetupManager.ParsePath(path));
                        PackageHold += $"\n!cfg|END|cfg!\n";
                        PackageHold += $"!bin|{BinName}|bin!\n";
                        PackageHold += FileToByte(SetupManager.ParsePath(SettingsManager.CurrentSetting.DataSource));
                        PackageHold += $"\n!bin|END|bin!\n";
                        PackageHold += "!pkg|END|pkg!";
                        File.AppendAllText(NewExePath, PackageHold);
                    }
                    else
                    {
                        MessageBox.Show("Your datasource must be a .bin file", "Wrong datasource", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Your using an setup that alredy hold a package, please an empty setup file", "Invalid Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must provide an valid config.json file", "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void NewBin(string Path)
        {
            try
            {
                string zipPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\data.zip";
                string binPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\data.bin";
                ZipFile.CreateFromDirectory(Path, zipPath, CompressionLevel.Optimal, includeBaseDirectory: false);
                if (File.Exists(binPath))
                { File.Delete(binPath); }
                File.Move(zipPath, binPath);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }    
        }
        public static Icon GetIcon(string path, string name)
        {
            using (var zip = ZipFile.OpenRead(path))
            {
                string correctedName = name.Substring(1);

                var file = zip.GetEntry(correctedName);
                if (file != null)
                {
                    // Save the stream to a temporary file
                    string tempFilePath = Path.GetTempFileName();
                    using (Stream stream = file.Open())
                    using (FileStream fileStream = File.Create(tempFilePath))
                    {
                        stream.CopyTo(fileStream);
                    }

                    // Create an Icon from the temporary file
                    return new Icon(tempFilePath);
                }
            }
            return null;
        }
        public static string GetFirstExeName(string path)
        {
            using (var zip = ZipFile.OpenRead(path))
            {
                foreach (var file in zip.Entries)
                {
                    if (file.Name.ToLower().Contains(".exe"))
                    {
                        return file.Name;
                    }
                }
            }
            return "My App.exe";
        }
        public static void Extract(string Source, string Destination) { ZipFile.ExtractToDirectory(Source, Destination); }
    }

}
