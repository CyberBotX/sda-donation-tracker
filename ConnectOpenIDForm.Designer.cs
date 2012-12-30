namespace SDA_DonationTracker
{
    partial class ConnectOpenIDForm
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
			this.EmailText = new System.Windows.Forms.TextBox();
			this.LoginButton = new System.Windows.Forms.Button();
			this.DomainLabel = new System.Windows.Forms.Label();
			this.DomainText = new System.Windows.Forms.TextBox();
			this.CancelationButton = new System.Windows.Forms.Button();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.PasswordText = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// EmailText
			// 
			this.EmailText.Location = new System.Drawing.Point(74, 38);
			this.EmailText.Name = "EmailText";
			this.EmailText.Size = new System.Drawing.Size(253, 20);
			this.EmailText.TabIndex = 1;
			// 
			// LoginButton
			// 
			this.LoginButton.Location = new System.Drawing.Point(171, 90);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(75, 23);
			this.LoginButton.TabIndex = 3;
			this.LoginButton.Text = "Log In";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
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
			this.DomainText.Location = new System.Drawing.Point(74, 12);
			this.DomainText.Name = "DomainText";
			this.DomainText.Size = new System.Drawing.Size(253, 20);
			this.DomainText.TabIndex = 0;
			// 
			// CancelationButton
			// 
			this.CancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelationButton.Location = new System.Drawing.Point(252, 90);
			this.CancelationButton.Name = "CancelationButton";
			this.CancelationButton.Size = new System.Drawing.Size(75, 23);
			this.CancelationButton.TabIndex = 4;
			this.CancelationButton.Text = "Cancel";
			this.CancelationButton.UseVisualStyleBackColor = true;
			this.CancelationButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.Location = new System.Drawing.Point(33, 41);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(35, 13);
			this.EmailLabel.TabIndex = 4;
			this.EmailLabel.Text = "Email:";
			// 
			// PasswordText
			// 
			this.PasswordText.Location = new System.Drawing.Point(74, 64);
			this.PasswordText.Name = "PasswordText";
			this.PasswordText.Size = new System.Drawing.Size(253, 20);
			this.PasswordText.TabIndex = 2;
			this.PasswordText.UseSystemPasswordChar = true;
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Location = new System.Drawing.Point(12, 67);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
			this.PasswordLabel.TabIndex = 6;
			this.PasswordLabel.Text = "Password:";
			// 
			// ConnectOpenIDManualForm
			// 
			this.AcceptButton = this.LoginButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelationButton;
			this.ClientSize = new System.Drawing.Size(339, 125);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.PasswordText);
			this.Controls.Add(this.EmailLabel);
			this.Controls.Add(this.DomainText);
			this.Controls.Add(this.CancelationButton);
			this.Controls.Add(this.DomainLabel);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.EmailText);
			this.Name = "ConnectOpenIDManualForm";
			this.Text = "ConnectOpenIDManualForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailText;
		private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label DomainLabel;
        private System.Windows.Forms.TextBox DomainText;
        private System.Windows.Forms.Button CancelationButton;
		private System.Windows.Forms.Label EmailLabel;
		private System.Windows.Forms.TextBox PasswordText;
		private System.Windows.Forms.Label PasswordLabel;
    }
}