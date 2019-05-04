using RSA.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypto.UI
{
    public partial class KryptoMainForm : Form
    {
        private const string ENCRYPTION_INPUT_PATH = @"msg\msg.txt";
        private const string ENCRYPTION_OUTPUT_PATH = @"msg\encryptedmsg.txt";
        private const string DECRYPTION_OUTPUT_PATH = @"msg\decryptedmsg.txt";

        public KryptoMainForm()
        {
            InitializeComponent();
        }

        private bool IsNumericInput(KeyPressEventArgs evt)
        {
            bool result = false;
            if (!char.IsControl(evt.KeyChar) && !char.IsDigit(evt.KeyChar))
                result = true;

            return result;
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private string SelectFile()
        {
            OpenFileDialog fdialog = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = true
            };

            string filename = "";

            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                filename = fdialog.FileName;
            }

            return filename;
        }

        private void KryptoMainForm_Load(object sender, EventArgs e)
        {
            FileInfo encryptioninput = new FileInfo(ENCRYPTION_INPUT_PATH);
            FileInfo encryptionoutput = new FileInfo(ENCRYPTION_OUTPUT_PATH);
            FileInfo deryptioninput = new FileInfo(ENCRYPTION_OUTPUT_PATH);
            FileInfo decryptionoutput = new FileInfo(DECRYPTION_OUTPUT_PATH);
            EncryptInputFileField.Text = encryptioninput.FullName;
            OutputFileField.Text = encryptionoutput.FullName;
            DecryptInputFileField.Text = deryptioninput.FullName;
            DecryptOutputFileField.Text = decryptionoutput.FullName;
            AlphabetField1.Text = RSACore.GetAlphabet();
            AlphabetField2.Text = RSACore.GetAlphabet();
        }

        private void AlphabetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AlphabetCheckBox.Checked == true)
                AlphabetField1.ReadOnly = false;
            else AlphabetField1.ReadOnly = true;
        }

        private void AlphabetField_TextChanged(object sender, EventArgs e)
        {
            RSACore.SetAlphabet(AlphabetField1.Text);
        }

        private void EncryptButton_Click(object sender, EventArgs evt)
        {
            try
            {
                string encryptedmessage = "";
                BigInteger e = BigInteger.Parse(PublicKeyE.Text);
                BigInteger n = BigInteger.Parse(PublicKeyN.Text);

                if ((PrivateKeyD.Text == "") || PrivateKeyN.Text == "")
                {
                    MessageBox.Show("Please specify both p and q and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!IsNumeric(PrivateKeyD.Text) || !IsNumeric(PrivateKeyN.Text))
                {
                    MessageBox.Show("Non-numeric input detected! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    StreamReader streamreader = new StreamReader(ENCRYPTION_INPUT_PATH);

                    while (!streamreader.EndOfStream)
                    {
                        encryptedmessage += streamreader.ReadLine();
                    }

                    streamreader.Close();

                    List<string> result = RSACore.RSAEncrypt(encryptedmessage, e, n);

                    StreamWriter streamwriter = new StreamWriter(ENCRYPTION_OUTPUT_PATH);
                    foreach (string item in result)
                    {
                        streamwriter.WriteLine(item);
                    }

                    streamwriter.Close();
                }
            }
            catch
            {
                MessageBox.Show("An error occured. Please check whether the filled in data are coorect and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InputFileSelectionButton_Click(object sender, EventArgs e)
        {
            EncryptInputFileField.Text = SelectFile();
        }

        private void OutputFileSelectionButton_Click(object sender, EventArgs e)
        {
            OutputFileField.Text = SelectFile();
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger p = BigInteger.Parse(PrivateKeyD.Text);
                BigInteger q = BigInteger.Parse(PrivateKeyN.Text);

                if ((PrivateKeyD.Text == "") || PrivateKeyN.Text == "")
                {
                    MessageBox.Show("Please specify both p and q and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!IsNumeric(PrivateKeyD.Text) || !IsNumeric(PrivateKeyN.Text))
                {
                    MessageBox.Show("Non-numeric input detected! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string decryptedmessage;
                    BigInteger d = BigInteger.Parse(PrivateKeyD.Text);
                    BigInteger n = BigInteger.Parse(PrivateKeyN.Text);

                    List<string> encryptedmessage = new List<string>();

                    StreamReader streamreader = new StreamReader(ENCRYPTION_OUTPUT_PATH);

                    while (!streamreader.EndOfStream)
                    {
                        encryptedmessage.Add(streamreader.ReadLine());
                    }
                    streamreader.Close();

                    decryptedmessage = RSACore.RSADecrypt(encryptedmessage, d, n);

                    StreamWriter streamwriter = new StreamWriter(DECRYPTION_OUTPUT_PATH);
                    streamwriter.WriteLine(decryptedmessage);
                    streamwriter.Close();
                }

            }
            catch
            {
                MessageBox.Show("An error occured. Please check whether the filled in data are coorect and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void PublicKeyE_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumericInput(e);
        }

        private void PublicKeyN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumericInput(e);
        }

        private void PrivateKeyD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumericInput(e);
        }

        private void PrivateKeyN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumericInput(e);
        }
    }
}
