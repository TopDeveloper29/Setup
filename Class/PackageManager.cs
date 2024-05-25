using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Vestris.ResourceLib;

namespace Setup
{
    // All method related to packaging the setup or data (create bin and exe)
    internal static class PackageManager
    {
        // using Vestris.ResourceLib edit the RC_ICON of a givent setup by a new icon file
        public static void ChangeIcon(string NewExePath, string TempIconPath, int TryCount = 0)
        {
            try
            {
                    IconDirectoryResource rc = new IconDirectoryResource();
                    rc.LoadFrom(NewExePath);
                    IconFile iconFile = new IconFile(TempIconPath);
                    IconDirectoryResource iconDirectoryResource = new IconDirectoryResource(iconFile);
                    iconDirectoryResource.SaveTo(NewExePath);
            }
            catch
            {
                if (TryCount < 2)
                {
                    Thread.Sleep(1500);
                    ChangeIcon(NewExePath, TempIconPath, TryCount + 1);
                }
                else
                {
                    MessageBox.Show($"Could not write icon in {NewExePath} try create setup again", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        #region Base64 Setup.exe processing
        // Convert a file to base64 string to save in setup.exe
        public static string FileToBase64(string Path)
        {
            byte[] fileBytes = File.ReadAllBytes(Path);
            string base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }
        
        // Convert base64 string (extract form setup.exe) to file
        public static void Base64toFile(string bytes, string name)
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
            byte[] fileBytes = Convert.FromBase64String(bytes);
            File.WriteAllBytes(fullPath, fileBytes);
            if (!fullPath.ToLower().Contains("temp.json") && !fullPath.ToLower().Contains("uninstall.exe"))
            {
                File.SetAttributes(fullPath, File.GetAttributes(fullPath) | FileAttributes.Hidden);
            }
        }
        // Convert base64 string (extract form setup.exe) to string
        public static string Base64ToString(string bytes)
        {
            byte[] fileBytes = Convert.FromBase64String(bytes);
            return Encoding.UTF8.GetString(fileBytes);
        }
        #endregion

        #region File generation
        // Create a new compressed bin file that happen for example when call app with /NewBin argument
        public static void NewBin(string Path, string binname = "data.bin")
        {
            try
            {
                string binPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\{binname}";
                // If the  file already exist delete it
                if (File.Exists(binPath))
                { File.Delete(binPath); }

                // Create the compres bin file
                ZipFile.CreateFromDirectory(Path, binPath, CompressionLevel.Optimal, includeBaseDirectory: false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        // Create a new self executable setup it basicly required a config file and bin that happen for example when call app with /Setup argument
        public static void NewSelfExe(string path, string OutputDir)
        {
            // Check if file exist and it a json
            if (File.Exists(path) && path.ToLower().Contains(".json"))
            {
                // Get current binary to check if it already have flag in it if yes abord the process
                string ExeBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
                if (ExeBin != null && !ExeBin.Contains("!pkg|START|pkg!") && !ExeBin.Contains("!pkg|END|pkg!"))
                {
                    // If binary is ok start process by loading the configuration file
                    SettingsManager.Load(SetupManager.ParsePath(path));

                    // validate the datasource of the setting is a bin file it required for self executable
                    if (SettingsManager.Current.DataSource.ToLower().Contains(".bin"))
                    {
                        // Get name of the file
                        string BinName = SettingsManager.Current.DataSource.Split(new string[] { @"\" }, StringSplitOptions.None).Last();
                        string CfgName = path.Split(new string[] { @"\" }, StringSplitOptions.None).Last();

                        // if the name is temp.json it mean it come from packager then change it to config.json so the setup could load it automatically
                        if (CfgName == "temp.json") { CfgName = "config.json"; }

                        // Get the path of the futur new exe file
                        string NewExePath = $"{OutputDir}\\{Assembly.GetEntryAssembly().Location.Split(new string[] { @"\" }, StringSplitOptions.None).Last().Split('.')[0]} {SettingsManager.Current.Name}.exe";
                        // if this file already exist delete it
                        if (File.Exists(NewExePath)) { File.Delete(NewExePath); }

                        // Create a copy of current setup to the new location or at least with a new name
                        File.Copy(Assembly.GetEntryAssembly().Location, NewExePath);

                        // If config contain an icon handle it
                        if (!string.IsNullOrEmpty(SettingsManager.Current.Icon))
                        {
                            Icon icon = null;
                            if (SettingsManager.Current.Icon.Contains(".bin")) // if the icon is in bin get it form the archive else get it from it location
                            {
                                string[] Path = SetupManager.ParsePath(SettingsManager.Current.Icon).Split(new string[] { ".bin" }, StringSplitOptions.None);
                                icon = GetIcon($"{Path[0]}.bin", Path[1]);
                            }
                            else
                            {
                                icon = new Icon(SetupManager.ParsePath(SettingsManager.Current.Icon));
                            }

                            // if icon object is not null at this point we could start do stuff with it
                            if (icon != null)
                            {
                                // temporary save icon to a file since method to change icon of exe work with path to ico only
                                string TempIconPath = $"{AppDomain.CurrentDomain.BaseDirectory}_.ico";
                                using (FileStream fileStream = new FileStream(TempIconPath, FileMode.Create))
                                {
                                    icon.Save(fileStream);
                                    fileStream.Close();
                                }
                                Thread.Sleep(1000); // wait a bit to be sure the method could read both exe and ico
                                ChangeIcon(NewExePath, TempIconPath);
                                Thread.Sleep(300); // wait a bit to be sure ico is finish write to exe
                                File.Delete(TempIconPath);
                            }
                        }

                        // Here that came the magic first initialize empty string
                        string PackageHold = string.Empty;
                        PackageHold += "\n!pkg|START|pkg!\n"; // pkg flag use to get all above flag
                        PackageHold += $"!cfg|{CfgName}|cfg!\n"; // cfg flag that hold the file name and use to get start of cfg flag
                        PackageHold += FileToBase64(SetupManager.ParsePath(path)); // here it convert the config to base54 (that we retrive when reading exe)
                        PackageHold += $"\n!cfg|END|cfg!\n"; // cfg end flag use to get end of cfg flag with the start flag
                        PackageHold += $"!bin|{BinName}|bin!\n"; // bin flag that hold the file name and use to get start of bin flag
                        PackageHold += FileToBase64(SetupManager.ParsePath(SettingsManager.Current.DataSource)); // here it convert the config to base54 (that we retrive when reading exe)
                        PackageHold += $"\n!bin|END|bin!\n"; // bin end flag use to get end of bin flag with the start flag
                        PackageHold += "!pkg|END|pkg!"; // pkg end flag use to get all above flag with pkg start flag
                        
                        File.AppendAllText(NewExePath, PackageHold); // Save flag and base64 to the new setup

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
        
        // This will create an setup that will only hold config and icon but as external data source it only use in packager UI
        public static void NewExe(string path, string OutputDir)
        {
            // Refert to NewSelfExe method to aditional comment since NewExe is barely the same process in a more simple way
            if (File.Exists(path) && path.ToLower().Contains(".json"))
            {
                string ExeBin = File.ReadAllText(Assembly.GetExecutingAssembly().Location);
                if (ExeBin != null && !ExeBin.Contains("!pkg|START|pkg!") && !ExeBin.Contains("!pkg|END|pkg!"))
                {
                    // Load config file
                    SettingsManager.Load(SetupManager.ParsePath(path));

                    // File name
                    string BinName = SettingsManager.Current.DataSource.Split(new string[] { @"\" }, StringSplitOptions.None).Last();
                    string CfgName = path.Split(new string[] { @"\" }, StringSplitOptions.None).Last();
                    if (CfgName == "temp.json") { CfgName = "config.json"; }

                    // Get the good path for the new exe
                    string NewExePath = $"{OutputDir}\\{Assembly.GetEntryAssembly().Location.Split(new string[] { @"\" }, StringSplitOptions.None).Last().Split('.')[0]} {SettingsManager.Current.Name}.exe";
                   
                    // if this file alredy exist delete it
                    if (File.Exists(NewExePath)) { File.Delete(NewExePath); }
                    File.Copy(Assembly.GetEntryAssembly().Location, NewExePath);

                    // If icon set handle it
                    if (!string.IsNullOrEmpty(SettingsManager.Current.Icon))
                    {
                        Icon icon = null;
                        if (SettingsManager.Current.Icon.Contains(".bin"))
                        {
                            string[] Path = SetupManager.ParsePath(SettingsManager.Current.Icon).Split(new string[] { ".bin" }, StringSplitOptions.None);
                            icon = GetIcon($"{Path[0]}.bin", Path[1]);
                        }
                        else
                        {
                            icon = new Icon($"{OutputDir}\\{SettingsManager.Current.Icon.Replace(@".\",@"\")}");
                        }
                        if (icon != null)
                        {
                            string TempIconPath = $"{AppDomain.CurrentDomain.BaseDirectory}_.ico";
                            using (FileStream fileStream = new FileStream(TempIconPath, FileMode.Create))
                            {
                                icon.Save(fileStream);
                            }
                            Thread.Sleep(1000);
                            ChangeIcon(NewExePath, TempIconPath);
                            Thread.Sleep(300);
                            File.Delete(TempIconPath);
                        }
                    }

                    // Here the magic happen we add base64 and flag to new setup
                    string PackageHold = string.Empty;
                    PackageHold += "!pkg|START|pkg!\n";
                    PackageHold += $"!cfg|{CfgName}|cfg!\n";
                    PackageHold += FileToBase64(SetupManager.ParsePath(path));
                    PackageHold += $"\n!cfg|END|cfg!\n";
                    PackageHold += "!pkg|END|pkg!";
                    File.AppendAllText(NewExePath, PackageHold);
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
        #endregion
        
        // Get Icon object from bin archive
        public static Icon GetIcon(string path, string name)
        {
            if (!File.Exists(path))
            {
                path = SetupManager.ParsePath(@".\_.bin");
            }
            if (File.Exists(path))
            {
                using (var zip = ZipFile.OpenRead(path)) // open bin
                {
                    string correctedName = name.Substring(1); // fix name by removing first character (it a \ )

                    var file = zip.GetEntry(correctedName); // Get the file by name in the bin
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
            }
            return null;
        }
        
        // Get first exe name in the bin archive
        public static string GetFirstExeName(string path)
        {
            using (var zip = ZipFile.OpenRead(path)) // open bin file
            {
                foreach (var file in zip.Entries) // check each file in it and look for an .exe
                {
                    if (file.Name.ToLower().Contains(".exe"))
                    {
                        return file.Name; // return the first .exe that is found
                    }
                }
            }
            return "My App.exe"; // if not found return dummy exe
        }
        
        // Extract bin archive to a folder
        public static void Extract(string Source, string Destination)
        {
            // If directory exist delete it
            if (Directory.Exists(Destination))
            { Directory.Delete(Destination, true); }

            // Extract bin to the folder
            ZipFile.ExtractToDirectory(Source, Destination);
        }
    }

}
