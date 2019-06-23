namespace KeyManager.UI
{
    partial class KeyManagerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyManagerMainForm));
            this.KryptoKeyManagerPanel = new System.Windows.Forms.Panel();
            this.KeyGenerationConsole = new System.Windows.Forms.ListBox();
            this.TextBoxQ = new System.Windows.Forms.TextBox();
            this.TextBoxP = new System.Windows.Forms.TextBox();
            this.LabelQ = new System.Windows.Forms.Label();
            this.LabelP = new System.Windows.Forms.Label();
            this.GenerateKeysButton = new System.Windows.Forms.Button();
            this.KryptoKeyManagerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptoKeyManagerPanel
            // 
            this.KryptoKeyManagerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KryptoKeyManagerPanel.Controls.Add(this.KeyGenerationConsole);
            this.KryptoKeyManagerPanel.Controls.Add(this.TextBoxQ);
            this.KryptoKeyManagerPanel.Controls.Add(this.TextBoxP);
            this.KryptoKeyManagerPanel.Controls.Add(this.LabelQ);
            this.KryptoKeyManagerPanel.Controls.Add(this.LabelP);
            this.KryptoKeyManagerPanel.Controls.Add(this.GenerateKeysButton);
            this.KryptoKeyManagerPanel.Location = new System.Drawing.Point(3, 4);
            this.KryptoKeyManagerPanel.Name = "KryptoKeyManagerPanel";
            this.KryptoKeyManagerPanel.Size = new System.Drawing.Size(308, 258);
            this.KryptoKeyManagerPanel.TabIndex = 0;
            // 
            // KeyGenerationConsole
            // 
            this.KeyGenerationConsole.FormattingEnabled = true;
            this.KeyGenerationConsole.Location = new System.Drawing.Point(3, 92);
            this.KeyGenerationConsole.Name = "KeyGenerationConsole";
            this.KeyGenerationConsole.Size = new System.Drawing.Size(300, 134);
            this.KeyGenerationConsole.TabIndex = 5;
            this.KeyGenerationConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyGenerationConsole_KeyDown);
            // 
            // TextBoxQ
            // 
            this.TextBoxQ.Location = new System.Drawing.Point(3, 65);
            this.TextBoxQ.Name = "TextBoxQ";
            this.TextBoxQ.Size = new System.Drawing.Size(300, 20);
            this.TextBoxQ.TabIndex = 4;
            this.TextBoxQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQ_KeyPress);
            // 
            // TextBoxP
            // 
            this.TextBoxP.Location = new System.Drawing.Point(3, 22);
            this.TextBoxP.Name = "TextBoxP";
            this.TextBoxP.Size = new System.Drawing.Size(300, 20);
            this.TextBoxP.TabIndex = 3;
            this.TextBoxP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxP_KeyPress);
            // 
            // LabelQ
            // 
            this.LabelQ.AutoSize = true;
            this.LabelQ.Location = new System.Drawing.Point(4, 49);
            this.LabelQ.Name = "LabelQ";
            this.LabelQ.Size = new System.Drawing.Size(16, 13);
            this.LabelQ.TabIndex = 2;
            this.LabelQ.Text = "q:";
            // 
            // LabelP
            // 
            this.LabelP.AutoSize = true;
            this.LabelP.Location = new System.Drawing.Point(4, 6);
            this.LabelP.Name = "LabelP";
            this.LabelP.Size = new System.Drawing.Size(16, 13);
            this.LabelP.TabIndex = 1;
            this.LabelP.Text = "p:";
            // 
            // GenerateKeysButton
            // 
            this.GenerateKeysButton.Location = new System.Drawing.Point(2, 230);
            this.GenerateKeysButton.Name = "GenerateKeysButton";
            this.GenerateKeysButton.Size = new System.Drawing.Size(301, 23);
            this.GenerateKeysButton.TabIndex = 0;
            this.GenerateKeysButton.Text = "Generate Keys";
            this.GenerateKeysButton.UseVisualStyleBackColor = true;
            this.GenerateKeysButton.Click += new System.EventHandler(this.GenerateKeysButton_Click);
            // 
            // KeyManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 269);
            this.Controls.Add(this.KryptoKeyManagerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KeyManagerMainForm";
            this.Text = "Krypto Key Manager";
            this.KryptoKeyManagerPanel.ResumeLayout(false);
            this.KryptoKeyManagerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel KryptoKeyManagerPanel;
        private System.Windows.Forms.Label LabelQ;
        private System.Windows.Forms.Label LabelP;
        private System.Windows.Forms.Button GenerateKeysButton;
        private System.Windows.Forms.TextBox TextBoxP;
        private System.Windows.Forms.TextBox TextBoxQ;
        private System.Windows.Forms.ListBox KeyGenerationConsole;
    }
}

