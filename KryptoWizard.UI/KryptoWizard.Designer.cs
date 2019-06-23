namespace KryptoWizard.UI
{
    partial class KryptoWizardWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptoWizardWindow));
            this.StepOneLabel = new System.Windows.Forms.Label();
            this.StepTwoLabel = new System.Windows.Forms.Label();
            this.KeyManagerLauncher = new System.Windows.Forms.Button();
            this.KryptoLauncher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StepOneLabel
            // 
            this.StepOneLabel.AutoSize = true;
            this.StepOneLabel.Location = new System.Drawing.Point(14, 14);
            this.StepOneLabel.Name = "StepOneLabel";
            this.StepOneLabel.Size = new System.Drawing.Size(240, 13);
            this.StepOneLabel.TabIndex = 0;
            this.StepOneLabel.Text = "Step 1: generate key pairs (skip if you have them)";
            // 
            // StepTwoLabel
            // 
            this.StepTwoLabel.AutoSize = true;
            this.StepTwoLabel.Location = new System.Drawing.Point(14, 73);
            this.StepTwoLabel.Name = "StepTwoLabel";
            this.StepTwoLabel.Size = new System.Drawing.Size(301, 13);
            this.StepTwoLabel.TabIndex = 1;
            this.StepTwoLabel.Text = "Step 2: perform encryption/decryption with the generated keys";
            // 
            // KeyManagerLauncher
            // 
            this.KeyManagerLauncher.Location = new System.Drawing.Point(17, 30);
            this.KeyManagerLauncher.Name = "KeyManagerLauncher";
            this.KeyManagerLauncher.Size = new System.Drawing.Size(298, 23);
            this.KeyManagerLauncher.TabIndex = 2;
            this.KeyManagerLauncher.Text = "Open Key Manager";
            this.KeyManagerLauncher.UseVisualStyleBackColor = true;
            this.KeyManagerLauncher.Click += new System.EventHandler(this.KeyManagerLauncher_Click);
            // 
            // KryptoLauncher
            // 
            this.KryptoLauncher.Location = new System.Drawing.Point(17, 89);
            this.KryptoLauncher.Name = "KryptoLauncher";
            this.KryptoLauncher.Size = new System.Drawing.Size(298, 23);
            this.KryptoLauncher.TabIndex = 3;
            this.KryptoLauncher.Text = "Open Krypto";
            this.KryptoLauncher.UseVisualStyleBackColor = true;
            this.KryptoLauncher.Click += new System.EventHandler(this.KryptoLauncher_Click);
            // 
            // KryptoWizardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 130);
            this.Controls.Add(this.KryptoLauncher);
            this.Controls.Add(this.KeyManagerLauncher);
            this.Controls.Add(this.StepTwoLabel);
            this.Controls.Add(this.StepOneLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KryptoWizardWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Krypto Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StepOneLabel;
        private System.Windows.Forms.Label StepTwoLabel;
        private System.Windows.Forms.Button KeyManagerLauncher;
        private System.Windows.Forms.Button KryptoLauncher;
    }
}

