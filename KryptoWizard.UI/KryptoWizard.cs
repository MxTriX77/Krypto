using System;
using System.IO;
using System.Windows.Forms;

namespace KryptoWizard.UI
{
    public partial class KryptoWizardWindow : Form
    {
        private readonly string workspace = Path.GetDirectoryName(Application.ExecutablePath);

        public KryptoWizardWindow()
        {
            InitializeComponent();
        }

        private void KeyManagerLauncher_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"bin\KeyManager.exe"))
                MessageBox.Show("KeyManager.exe is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Diagnostics.Process.Start(@"bin\KeyManager.exe", workspace);
        }

        private void KryptoLauncher_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"bin\Krypto.exe"))
                MessageBox.Show("Krypto.exe is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Diagnostics.Process.Start(@"bin\Krypto.exe", workspace);
        }
    }
}
