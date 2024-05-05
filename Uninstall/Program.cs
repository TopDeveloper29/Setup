using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uninstall
{
    public class Program
    {
        // Main entry point of application
        [STAThread]
        public static void Main(string[] Args)
        {
            Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            // Handle asembly resolving to alow application run withoud dll next to it
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;

            // Run the real Main function in Uninstall.cs
            Uninstall.Main(Args);
        }

        // Event hanlder to resolve DLL path
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(args.Name);

            var path = assemblyName.Name + ".dll";
            if (!assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture))
            {
                path = $"{assemblyName.CultureInfo}\\${path}";
            }

            var stream = executingAssembly.GetManifestResourceStream(path);
            if (stream == null)
                return null;

            var assemblyRawBytes = new byte[stream.Length];
            stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
            return Assembly.Load(assemblyRawBytes);
        }
    }
}
