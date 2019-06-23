using Base64.Core;
using RSA.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace Krypto.UI
{
    public partial class KryptoMainForm : Form
    {
        private readonly string ENCRYPTION_INPUT_PATH;
        private readonly string ENCRYPTION_OUTPUT_PATH;
        private readonly string DECRYPTION_OUTPUT_PATH;
        private readonly Base64Encoder b64 = new Base64Encoder('+', '/', true);
        bool EncB64Enabled = false;
        bool DecB64Enabled = false;
        ToolTip tooltip = new ToolTip
        {
            AutoPopDelay = 5000,
            InitialDelay = 1000,
            ReshowDelay = 500
        };

        public KryptoMainForm(string workspace)
        {
            InitializeComponent();
            ENCRYPTION_INPUT_PATH = $@"{workspace}\msg\message";
            ENCRYPTION_OUTPUT_PATH = $@"{workspace}\msg\encrypted_message";
            DECRYPTION_OUTPUT_PATH = $@"{workspace}\msg\decrypted_message";
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
                Multiselect = false
            };

            string filename = "";

            if (fdialog.ShowDialog() == DialogResult.OK)
                filename = fdialog.FileName;

            return filename;
        }

        public byte[] ReadBytes(string filepath)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }

            return buffer;
        }

        public bool WriteBytes(string filepath, byte[] bytearray)
        {
            using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytearray, 0, bytearray.Length);
                return true;
            }
        }

        private void KryptoMainForm_Load(object sender, EventArgs e)
        {
            EncryptInputFileField.Text = ENCRYPTION_INPUT_PATH;
            EncryptOutputFileField.Text = ENCRYPTION_OUTPUT_PATH;
            DecryptInputFileField.Text = ENCRYPTION_OUTPUT_PATH;
            DecryptOutputFileField.Text = DECRYPTION_OUTPUT_PATH;
            AlphabetField1.Text = RSACore.GetAlphabet();
            AlphabetField2.Text = RSACore.GetAlphabet();
        }

        private void AlphabetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AlphabetCheckBox.Checked == true)
                AlphabetField1.ReadOnly = false;
            else
                AlphabetField1.ReadOnly = true;
        }

        private bool IsNumericInput(KeyPressEventArgs evt)
        {
            bool result = false;
            if (!char.IsControl(evt.KeyChar) && !char.IsDigit(evt.KeyChar))
                result = true;

            return result;
        }

        private void WriteText(string path, List<string> result)
        {
            StreamWriter streamwriter = new StreamWriter(path);
            foreach (string item in result)
                streamwriter.WriteLine(item);

            streamwriter.Close();
        }

        private void WriteText(string path, string result)
        {
            StreamWriter streamwriter = new StreamWriter(path);
            streamwriter.WriteLine(result);
            streamwriter.Close();
        }

        private List<string> ReadText(string path)
        {
            List<string> input = new List<string>();
            StreamReader streamreader = new StreamReader(path);

            while (!streamreader.EndOfStream)
                input.Add(streamreader.ReadLine());
            streamreader.Close();

            return input;
        }

        private string ReadTextStr(string path)
        {
            string str = "";

            StreamReader streamreader = new StreamReader(path);

            while (!streamreader.EndOfStream)
                str += streamreader.ReadLine();

            streamreader.Close();

            return str;
        }

        private void Encrypt(BigInteger e, BigInteger n, string inputpath, string outputpath, bool b64enabled)
        {
            if (b64enabled)
            {
                string message = b64.ToBase(ReadBytes(inputpath));

                List<string> result = RSACore.Encrypt(message, e, n);

                WriteText(outputpath, result);
            }
            else
            {
                string message = "";

                message = ReadTextStr(inputpath);

                List<string> result = RSACore.Encrypt(message, e, n);

                WriteText(outputpath, result);
            }
        }

        private void Decrypt(BigInteger d, BigInteger n, string inputpath, string outputpath, bool b64enabled)
        {
            string decryptedmessage = "";
            byte[] bytes;
            List<string> encryptedmessage = new List<string>();

            encryptedmessage = ReadText(inputpath);

            decryptedmessage = RSACore.Decrypt(encryptedmessage, d, n);

            if (b64enabled)
            {
                bytes = b64.FromBase(decryptedmessage);
                WriteBytes(outputpath, bytes);
            }
            else
            {
                decryptedmessage = RSACore.Decrypt(encryptedmessage, d, n);

                WriteText(outputpath, decryptedmessage);
            }
        }

        private void AlphabetField_TextChanged(object sender, EventArgs e)
        {
            RSACore.SetAlphabet(AlphabetField1.Text);
        }

        private void InputFileSelectionButton_Click(object sender, EventArgs e)
        {
            EncryptInputFileField.Text = SelectFile();
        }

        private void OutputFileSelectionButton_Click(object sender, EventArgs e)
        {
            EncryptOutputFileField.Text = SelectFile();
        }

        private void InputSelect_Click(object sender, EventArgs e)
        {
            DecryptInputFileField.Text = SelectFile();
        }

        private void OutputSelect_Click(object sender, EventArgs e)
        {
            DecryptOutputFileField.Text = SelectFile();
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

        private void EncB64_CheckedChanged(object sender, EventArgs e)
        {
            EncB64Enabled = EncB64.Checked;
        }

        private void DecB64_CheckedChanged(object sender, EventArgs e)
        {
            DecB64Enabled = DecB64.Checked;
        }

        private void EncryptButton_Click(object sender, EventArgs evt)
        {
            BigInteger e;
            BigInteger n;

            try
            {
                if ((PublicKeyE.Text == "") || (PublicKeyN.Text == ""))
                    MessageBox.Show("Please specify both p and q and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (!IsNumeric(PrivateKeyD.Text) || !IsNumeric(PrivateKeyN.Text))
                    MessageBox.Show("Non-numeric input detected! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (!File.Exists(EncryptInputFileField.Text))
                        tooltip.Show("Couldn't find this file", EncryptInputFileField);
                    else if (!File.Exists(EncryptOutputFileField.Text))
                        tooltip.Show("Couldn't find this file", EncryptOutputFileField);
                    else
                    {
                        e = BigInteger.Parse(PublicKeyE.Text);
                        n = BigInteger.Parse(PublicKeyN.Text);
                        Encrypt(e, n, EncryptInputFileField.Text, EncryptOutputFileField.Text, EncB64Enabled);
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occured. Please check whether the filled in data are coorect and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            BigInteger d;
            BigInteger n;

            try
            {
                if ((PrivateKeyD.Text == "") || (PrivateKeyN.Text == ""))
                    MessageBox.Show("Please specify both p and q and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (!IsNumeric(PrivateKeyD.Text) || !IsNumeric(PrivateKeyN.Text))
                    MessageBox.Show("Non-numeric input detected! Please double-check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (!File.Exists(EncryptInputFileField.Text))
                        tooltip.Show("Couldn't find this file", EncryptInputFileField);
                    else if ((!File.Exists(EncryptOutputFileField.Text)))
                        tooltip.Show("Couldn't find this file", EncryptOutputFileField);
                    else
                    {
                        d = BigInteger.Parse(PrivateKeyD.Text);
                        n = BigInteger.Parse(PrivateKeyN.Text);
                        Decrypt(d, n, DecryptInputFileField.Text, DecryptOutputFileField.Text, DecB64Enabled);
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occured. Please check whether the filled in data are coorect and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
