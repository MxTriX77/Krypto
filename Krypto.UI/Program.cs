using System;
using System.IO;
using System.Windows.Forms;

namespace Krypto.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String missinglibs = "";
            bool missingflag = false;

            if (!File.Exists(@"lib\RSA.Core.dll"))
            {
                missinglibs += "\nRSA.Core.dll";
                missingflag = true;
            }

            if (!File.Exists(@"lib\KMP.Core.dll"))
            {
                missinglibs += "\nKMP.Core.dll";
                missingflag = true;
            }

            if (!File.Exists(@"lib\Base64.Core.dll"))
            {
                missinglibs += "\nBase64.Core.dll";
                missingflag = true;
            }

            if (missingflag) { MessageBox.Show($"The following core libraries are missing: {missinglibs}", "Initialization error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new KryptoMainForm());
            }
        }
    }
}
