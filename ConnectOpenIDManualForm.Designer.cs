namespace SDA_DonationTracker
{
    partial class ConnectOpenIDManualForm
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
            this.SessionIdText = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SessionIdLabel = new System.Windows.Forms.Label();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.DomainText = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SessionIdText
            // 
            this.SessionIdText.Location = new System.Drawing.Point(80, 50);
            this.SessionIdText.Name = "SessionIdText";
            this.SessionIdText.Size = new System.Drawing.Size(253, 20);
            this.SessionIdText.TabIndex = 1;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(161, 76);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Log In";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SessionIdLabel
            // 
            this.SessionIdLabel.AutoSize = true;
            this.SessionIdLabel.Location = new System.Drawing.Point(12, 50);
            this.SessionIdLabel.Name = "SessionIdLabel";
            this.SessionIdLabel.Size = new System.Drawing.Size(56, 13);
            this.SessionIdLabel.TabIndex = 2;
            this.SessionIdLabel.Text = "SessionId:";
            // 
            // DomainLabel
            // 
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Location = new System.Drawing.Point(22, 15);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(46, 13);
            this.DomainLabel.TabIndex = 3;
            this.DomainLabel.Text = "Domain:";
            // 
            // DomainText
            // 
            this.DomainText.Location = new System.Drawing.Point(80, 15);
            this.DomainText.Name = "DomainText";
            this.DomainText.Size = new System.Drawing.Size(253, 20);
            this.DomainText.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(242, 76);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConnectOpenIDManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 111);
            this.Controls.Add(this.DomainText);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DomainLabel);
            this.Controls.Add(this.SessionIdLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.SessionIdText);
            this.Name = "ConnectOpenIDManualForm";
            this.Text = "ConnectOpenIDManualForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SessionIdText;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label SessionIdLabel;
        private System.Windows.Forms.Label DomainLabel;
        private System.Windows.Forms.TextBox DomainText;
        private System.Windows.Forms.Button CancelButton;
    }
}