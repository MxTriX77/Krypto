namespace Krypto.UI
{
    partial class KryptoMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptoMainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EncB64 = new System.Windows.Forms.CheckBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.PublicKeyN = new System.Windows.Forms.TextBox();
            this.PublicKeyE = new System.Windows.Forms.TextBox();
            this.PublicKeyLabel = new System.Windows.Forms.Label();
            this.GUISeparator = new System.Windows.Forms.Label();
            this.AlphabetField1 = new System.Windows.Forms.TextBox();
            this.AlphabetCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputFileSelectionButton = new System.Windows.Forms.Button();
            this.InputFileSelectionButton = new System.Windows.Forms.Button();
            this.OutputFileLabel = new System.Windows.Forms.Label();
            this.EncryptOutputFileField = new System.Windows.Forms.TextBox();
            this.EncryptInputFileField = new System.Windows.Forms.TextBox();
            this.InputFileLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DecB64 = new System.Windows.Forms.CheckBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.PrivateKeyN = new System.Windows.Forms.TextBox();
            this.PrivateKeyD = new System.Windows.Forms.TextBox();
            this.PrivateKeyLabel = new System.Windows.Forms.Label();
            this.GUISeparator2 = new System.Windows.Forms.Label();
            this.AlphabetField2 = new System.Windows.Forms.TextBox();
            this.CustomAlphabetCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputSelect = new System.Windows.Forms.Button();
            this.InputSelect = new System.Windows.Forms.Button();
            this.DecryptOutputFileField = new System.Windows.Forms.TextBox();
            this.DecryptInputFileField = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.SelectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.HintTip = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(5, 5);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(577, 300);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EncB64);
            this.tabPage1.Controls.Add(this.EncryptButton);
            this.tabPage1.Controls.Add(this.PublicKeyN);
            this.tabPage1.Controls.Add(this.PublicKeyE);
            this.tabPage1.Controls.Add(this.PublicKeyLabel);
            this.tabPage1.Controls.Add(this.GUISeparator);
            this.tabPage1.Controls.Add(this.AlphabetField1);
            this.tabPage1.Controls.Add(this.AlphabetCheckBox);
            this.tabPage1.Controls.Add(this.OutputFileSelectionButton);
            this.tabPage1.Controls.Add(this.InputFileSelectionButton);
            this.tabPage1.Controls.Add(this.OutputFileLabel);
            this.tabPage1.Controls.Add(this.EncryptOutputFileField);
            this.tabPage1.Controls.Add(this.EncryptInputFileField);
            this.tabPage1.Controls.Add(this.InputFileLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(569, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encryption";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EncB64
            // 
            this.EncB64.AutoSize = true;
            this.EncB64.Location = new System.Drawing.Point(7, 162);
            this.EncB64.Name = "EncB64";
            this.EncB64.Size = new System.Drawing.Size(383, 17);
            this.EncB64.TabIndex = 19;
            this.EncB64.Text = "Base64 (important for binary files and useful for texts with vast character set)";
            this.EncB64.UseVisualStyleBackColor = true;
            this.EncB64.CheckedChanged += new System.EventHandler(this.EncB64_CheckedChanged);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(7, 242);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(557, 26);
            this.EncryptButton.TabIndex = 18;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // PublicKeyN
            // 
            this.PublicKeyN.Location = new System.Drawing.Point(284, 215);
            this.PublicKeyN.Name = "PublicKeyN";
            this.PublicKeyN.Size = new System.Drawing.Size(280, 20);
            this.PublicKeyN.TabIndex = 17;
            this.PublicKeyN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PublicKeyN_KeyPress);
            // 
            // PublicKeyE
            // 
            this.PublicKeyE.Location = new System.Drawing.Point(7, 215);
            this.PublicKeyE.Name = "PublicKeyE";
            this.PublicKeyE.Size = new System.Drawing.Size(275, 20);
            this.PublicKeyE.TabIndex = 16;
            this.PublicKeyE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PublicKeyE_KeyPress);
            // 
            // PublicKeyLabel
            // 
            this.PublicKeyLabel.AutoSize = true;
            this.PublicKeyLabel.Location = new System.Drawing.Point(256, 196);
            this.PublicKeyLabel.Name = "PublicKeyLabel";
            this.PublicKeyLabel.Size = new System.Drawing.Size(56, 13);
            this.PublicKeyLabel.TabIndex = 15;
            this.PublicKeyLabel.Text = "Public key";
            // 
            // GUISeparator
            // 
            this.GUISeparator.AutoSize = true;
            this.GUISeparator.Location = new System.Drawing.Point(6, 176);
            this.GUISeparator.Name = "GUISeparator";
            this.GUISeparator.Size = new System.Drawing.Size(559, 13);
            this.GUISeparator.TabIndex = 14;
            this.GUISeparator.Text = "_________________________________________________________________________________" +
    "___________";
            // 
            // AlphabetField1
            // 
            this.AlphabetField1.Location = new System.Drawing.Point(7, 134);
            this.AlphabetField1.Name = "AlphabetField1";
            this.AlphabetField1.ReadOnly = true;
            this.AlphabetField1.Size = new System.Drawing.Size(557, 20);
            this.AlphabetField1.TabIndex = 13;
            this.AlphabetField1.TextChanged += new System.EventHandler(this.AlphabetField_TextChanged);
            // 
            // AlphabetCheckBox
            // 
            this.AlphabetCheckBox.AutoSize = true;
            this.AlphabetCheckBox.Location = new System.Drawing.Point(7, 114);
            this.AlphabetCheckBox.Name = "AlphabetCheckBox";
            this.AlphabetCheckBox.Size = new System.Drawing.Size(105, 17);
            this.AlphabetCheckBox.TabIndex = 12;
            this.AlphabetCheckBox.Text = "Custom alphabet";
            this.AlphabetCheckBox.UseVisualStyleBackColor = true;
            this.AlphabetCheckBox.CheckedChanged += new System.EventHandler(this.AlphabetCheckBox_CheckedChanged);
            // 
            // OutputFileSelectionButton
            // 
            this.OutputFileSelectionButton.Location = new System.Drawing.Point(537, 78);
            this.OutputFileSelectionButton.Name = "OutputFileSelectionButton";
            this.OutputFileSelectionButton.Size = new System.Drawing.Size(27, 20);
            this.OutputFileSelectionButton.TabIndex = 11;
            this.OutputFileSelectionButton.Text = "...";
            this.OutputFileSelectionButton.UseVisualStyleBackColor = true;
            this.OutputFileSelectionButton.Click += new System.EventHandler(this.OutputFileSelectionButton_Click);
            // 
            // InputFileSelectionButton
            // 
            this.InputFileSelectionButton.Location = new System.Drawing.Point(537, 26);
            this.InputFileSelectionButton.Name = "InputFileSelectionButton";
            this.InputFileSelectionButton.Size = new System.Drawing.Size(27, 20);
            this.InputFileSelectionButton.TabIndex = 10;
            this.InputFileSelectionButton.Text = "...";
            this.InputFileSelectionButton.UseVisualStyleBackColor = true;
            this.InputFileSelectionButton.Click += new System.EventHandler(this.InputFileSelectionButton_Click);
            // 
            // OutputFileLabel
            // 
            this.OutputFileLabel.AutoSize = true;
            this.OutputFileLabel.Location = new System.Drawing.Point(5, 62);
            this.OutputFileLabel.Name = "OutputFileLabel";
            this.OutputFileLabel.Size = new System.Drawing.Size(58, 13);
            this.OutputFileLabel.TabIndex = 9;
            this.OutputFileLabel.Text = "Output file:";
            // 
            // EncryptOutputFileField
            // 
            this.EncryptOutputFileField.Location = new System.Drawing.Point(7, 79);
            this.EncryptOutputFileField.Name = "EncryptOutputFileField";
            this.EncryptOutputFileField.Size = new System.Drawing.Size(524, 20);
            this.EncryptOutputFileField.TabIndex = 8;
            // 
            // EncryptInputFileField
            // 
            this.EncryptInputFileField.Location = new System.Drawing.Point(7, 26);
            this.EncryptInputFileField.Name = "EncryptInputFileField";
            this.EncryptInputFileField.Size = new System.Drawing.Size(524, 20);
            this.EncryptInputFileField.TabIndex = 7;
            // 
            // InputFileLabel
            // 
            this.InputFileLabel.AutoSize = true;
            this.InputFileLabel.Location = new System.Drawing.Point(4, 10);
            this.InputFileLabel.Name = "InputFileLabel";
            this.InputFileLabel.Size = new System.Drawing.Size(76, 13);
            this.InputFileLabel.TabIndex = 6;
            this.InputFileLabel.Text = "File to encrypt:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DecB64);
            this.tabPage2.Controls.Add(this.OutputLabel);
            this.tabPage2.Controls.Add(this.DecryptButton);
            this.tabPage2.Controls.Add(this.PrivateKeyN);
            this.tabPage2.Controls.Add(this.PrivateKeyD);
            this.tabPage2.Controls.Add(this.PrivateKeyLabel);
            this.tabPage2.Controls.Add(this.GUISeparator2);
            this.tabPage2.Controls.Add(this.AlphabetField2);
            this.tabPage2.Controls.Add(this.CustomAlphabetCheckBox);
            this.tabPage2.Controls.Add(this.OutputSelect);
            this.tabPage2.Controls.Add(this.InputSelect);
            this.tabPage2.Controls.Add(this.DecryptOutputFileField);
            this.tabPage2.Controls.Add(this.DecryptInputFileField);
            this.tabPage2.Controls.Add(this.InputLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(569, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decryption";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DecB64
            // 
            this.DecB64.AutoSize = true;
            this.DecB64.Location = new System.Drawing.Point(7, 162);
            this.DecB64.Name = "DecB64";
            this.DecB64.Size = new System.Drawing.Size(383, 17);
            this.DecB64.TabIndex = 32;
            this.DecB64.Text = "Base64 (important for binary files and useful for texts with vast character set)";
            this.DecB64.UseVisualStyleBackColor = true;
            this.DecB64.CheckedChanged += new System.EventHandler(this.DecB64_CheckedChanged);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(5, 62);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(58, 13);
            this.OutputLabel.TabIndex = 31;
            this.OutputLabel.Text = "Output file:";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(7, 242);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(557, 26);
            this.DecryptButton.TabIndex = 30;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // PrivateKeyN
            // 
            this.PrivateKeyN.Location = new System.Drawing.Point(284, 215);
            this.PrivateKeyN.Name = "PrivateKeyN";
            this.PrivateKeyN.Size = new System.Drawing.Size(280, 20);
            this.PrivateKeyN.TabIndex = 29;
            this.PrivateKeyN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrivateKeyN_KeyPress);
            // 
            // PrivateKeyD
            // 
            this.PrivateKeyD.Location = new System.Drawing.Point(7, 215);
            this.PrivateKeyD.Name = "PrivateKeyD";
            this.PrivateKeyD.Size = new System.Drawing.Size(275, 20);
            this.PrivateKeyD.TabIndex = 28;
            this.PrivateKeyD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrivateKeyD_KeyPress);
            // 
            // PrivateKeyLabel
            // 
            this.PrivateKeyLabel.AutoSize = true;
            this.PrivateKeyLabel.Location = new System.Drawing.Point(253, 196);
            this.PrivateKeyLabel.Name = "PrivateKeyLabel";
            this.PrivateKeyLabel.Size = new System.Drawing.Size(60, 13);
            this.PrivateKeyLabel.TabIndex = 27;
            this.PrivateKeyLabel.Text = "Private key";
            // 
            // GUISeparator2
            // 
            this.GUISeparator2.AutoSize = true;
            this.GUISeparator2.Location = new System.Drawing.Point(6, 176);
            this.GUISeparator2.Name = "GUISeparator2";
            this.GUISeparator2.Size = new System.Drawing.Size(559, 13);
            this.GUISeparator2.TabIndex = 26;
            this.GUISeparator2.Text = "_________________________________________________________________________________" +
    "___________";
            // 
            // AlphabetField2
            // 
            this.AlphabetField2.Location = new System.Drawing.Point(7, 134);
            this.AlphabetField2.Name = "AlphabetField2";
            this.AlphabetField2.ReadOnly = true;
            this.AlphabetField2.Size = new System.Drawing.Size(557, 20);
            this.AlphabetField2.TabIndex = 25;
            // 
            // CustomAlphabetCheckBox
            // 
            this.CustomAlphabetCheckBox.AutoSize = true;
            this.CustomAlphabetCheckBox.Location = new System.Drawing.Point(7, 114);
            this.CustomAlphabetCheckBox.Name = "CustomAlphabetCheckBox";
            this.CustomAlphabetCheckBox.Size = new System.Drawing.Size(105, 17);
            this.CustomAlphabetCheckBox.TabIndex = 24;
            this.CustomAlphabetCheckBox.Text = "Custom alphabet";
            this.CustomAlphabetCheckBox.UseVisualStyleBackColor = true;
            // 
            // OutputSelect
            // 
            this.OutputSelect.Location = new System.Drawing.Point(537, 78);
            this.OutputSelect.Name = "OutputSelect";
            this.OutputSelect.Size = new System.Drawing.Size(27, 20);
            this.OutputSelect.TabIndex = 23;
            this.OutputSelect.Text = "...";
            this.OutputSelect.UseVisualStyleBackColor = true;
            this.OutputSelect.Click += new System.EventHandler(this.OutputSelect_Click);
            // 
            // InputSelect
            // 
            this.InputSelect.Location = new System.Drawing.Point(537, 26);
            this.InputSelect.Name = "InputSelect";
            this.InputSelect.Size = new System.Drawing.Size(27, 20);
            this.InputSelect.TabIndex = 22;
            this.InputSelect.Text = "...";
            this.InputSelect.UseVisualStyleBackColor = true;
            this.InputSelect.Click += new System.EventHandler(this.InputSelect_Click);
            // 
            // DecryptOutputFileField
            // 
            this.DecryptOutputFileField.Location = new System.Drawing.Point(7, 79);
            this.DecryptOutputFileField.Name = "DecryptOutputFileField";
            this.DecryptOutputFileField.Size = new System.Drawing.Size(524, 20);
            this.DecryptOutputFileField.TabIndex = 21;
            // 
            // DecryptInputFileField
            // 
            this.DecryptInputFileField.Location = new System.Drawing.Point(7, 26);
            this.DecryptInputFileField.Name = "DecryptInputFileField";
            this.DecryptInputFileField.Size = new System.Drawing.Size(524, 20);
            this.DecryptInputFileField.TabIndex = 20;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(4, 10);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(76, 13);
            this.InputLabel.TabIndex = 19;
            this.InputLabel.Text = "File to decrypt:";
            // 
            // KryptoMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 308);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KryptoMainForm";
            this.Text = "Krypto";
            this.Load += new System.EventHandler(this.KryptoMainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button OutputFileSelectionButton;
        private System.Windows.Forms.Button InputFileSelectionButton;
        private System.Windows.Forms.Label OutputFileLabel;
        private System.Windows.Forms.TextBox EncryptOutputFileField;
        private System.Windows.Forms.TextBox EncryptInputFileField;
        private System.Windows.Forms.Label InputFileLabel;
        private System.Windows.Forms.TextBox AlphabetField1;
        private System.Windows.Forms.CheckBox AlphabetCheckBox;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.TextBox PublicKeyN;
        private System.Windows.Forms.TextBox PublicKeyE;
        private System.Windows.Forms.Label PublicKeyLabel;
        private System.Windows.Forms.Label GUISeparator;
        private System.Windows.Forms.OpenFileDialog SelectFileDialog;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.TextBox PrivateKeyN;
        private System.Windows.Forms.TextBox PrivateKeyD;
        private System.Windows.Forms.Label PrivateKeyLabel;
        private System.Windows.Forms.Label GUISeparator2;
        private System.Windows.Forms.TextBox AlphabetField2;
        private System.Windows.Forms.CheckBox CustomAlphabetCheckBox;
        private System.Windows.Forms.Button OutputSelect;
        private System.Windows.Forms.Button InputSelect;
        private System.Windows.Forms.TextBox DecryptOutputFileField;
        private System.Windows.Forms.TextBox DecryptInputFileField;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.CheckBox EncB64;
        private System.Windows.Forms.CheckBox DecB64;
        private System.Windows.Forms.ToolTip HintTip;
    }
}

