using System;
using System.IO;
using System.Windows.Forms;

namespace Krypto.UI
{
    public static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string missinglibs = "";
            bool missingflag = false;

            if (!File.Exists($@"{args[0]}\bin\lib\RSA.Core.dll"))
            {
                missinglibs += $@"{Environment.NewLine}{args[0]}\bin\lib\RSA.Core.dll";
                missingflag = true;
            }

            if (!File.Exists($@"{args[0]}\bin\lib\KMP.Core.dll"))
            {
                missinglibs += $@"{Environment.NewLine}{args[0]}\bin\lib\KMP.Core.dll";
                missingflag = true;
            }

            if (!File.Exists($@"{args[0]}\bin\lib\Base64.Core.dll"))
            {
                missinglibs += $@"{Environment.NewLine}{args[0]}\bin\lib\Base64.Core.dll";
                missingflag = true;
            }

            if (missingflag)
                MessageBox.Show($"The following core libraries are missing: {missinglibs}", "Initialization error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new KryptoMainForm(args[0]));
            }
        }
    }
}
