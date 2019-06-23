using RSA.Core;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace KeyManager.UI
{
    public partial class KeyManagerMainForm : Form
    {
        public KeyManagerMainForm()
        {
            InitializeComponent();
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void GenerateKeysButton_Click(object sender, EventArgs evt)
        {
            string publickey;
            string privatekey;
            BigInteger p;
            BigInteger q;
            try
            {
                p = BigInteger.Parse(TextBoxP.Text);
                q = BigInteger.Parse(TextBoxQ.Text);

                if ((TextBoxP.Text == "") || TextBoxQ.Text == "")
                {
                    MessageBox.Show("Please specify both p and q parameters and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!IsNumeric(TextBoxP.Text) || !IsNumeric(TextBoxQ.Text))
                {
                    MessageBox.Show("Non-numeric input detected! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!RSACore.IsPrime(p) || !RSACore.IsPrime(q))
                {
                    MessageBox.Show("Both p and q parameters should be prime numbers! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    KeyGenerationConsole.Items.Clear();
                    RSACore.GetEncryptionParameters(p, q, out BigInteger n, out BigInteger phi, out BigInteger d, out BigInteger e);
                    publickey = $"PUBLIC KEY (e, n): ({e}, {n})";
                    privatekey = $"PRIVATE KEY (d, n): ({d}, {n})";
                    KeyGenerationConsole.Items.Add($"p = {p}, q = {q}");
                    KeyGenerationConsole.Items.Add($"Modulus: n = {n}");
                    KeyGenerationConsole.Items.Add($"Euler's function: ф(n) = {phi}");
                    KeyGenerationConsole.Items.Add($"Public exponent: e = {e}");
                    KeyGenerationConsole.Items.Add($"Private exponent: d = {d}");
                    KeyGenerationConsole.Items.Add("-------------------------------------------------------------------------------------------");
                    KeyGenerationConsole.Items.Add(publickey);
                    KeyGenerationConsole.Items.Add(privatekey);
                    Clipboard.SetText($"{publickey}\r\n{privatekey}");
                    MessageBox.Show("Key pairs have been successfully generated and copied to clipboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("An error occured. Please check whether the filled in data are correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void KeyGenerationConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyGenerationConsole.Items.Count != 0)
            {

                if (e.Control == true && e.KeyCode == Keys.C)
                {
                    string s = KeyGenerationConsole.SelectedItem.ToString();
                    Clipboard.SetData(DataFormats.StringFormat, s);
                }
            }
        }

        private void TextBoxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBoxQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
