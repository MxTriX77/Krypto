using System;
using System.Windows.Forms;
using System.IO;

namespace KeyManager.UI
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists(@"lib\RSA.Core.dll"))
            { 
                MessageBox.Show("RSA.Core.dll wasn't found!", "Initialization error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new KeyManagerMainForm());
            }
        }
    }
}
