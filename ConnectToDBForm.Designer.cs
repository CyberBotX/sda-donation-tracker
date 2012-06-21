using System.ComponentModel;

namespace SDA_DonationTracker
{
	partial class ConnectToDBForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ServerURLLabel = new System.Windows.Forms.Label();
			this.ServerURLTextBox = new System.Windows.Forms.TextBox();
			this.DatabaseNameLabel = new System.Windows.Forms.Label();
			this.DatabaseNameTextBox = new System.Windows.Forms.TextBox();
			this.UserNameLabel = new System.Windows.Forms.Label();
			this.UserNameTextBox = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ServerURLLabel
			// 
			this.ServerURLLabel.Location = new System.Drawing.Point(12, 15);
			this.ServerURLLabel.Name = "ServerURLLabel";
			this.ServerURLLabel.Size = new System.Drawing.Size(87, 13);
			this.ServerURLLabel.TabIndex = 0;
			this.ServerURLLabel.Text = "Server URL:";
			this.ServerURLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ServerURLTextBox
			// 
			this.ServerURLTextBox.Location = new System.Drawing.Point(105, 12);
			this.ServerURLTextBox.Name = "ServerURLTextBox";
			this.ServerURLTextBox.Size = new System.Drawing.Size(200, 20);
			this.ServerURLTextBox.TabIndex = 1;
			// 
			// DatabaseNameLabel
			// 
			this.DatabaseNameLabel.Location = new System.Drawing.Point(12, 41);
			this.DatabaseNameLabel.Name = "DatabaseNameLabel";
			this.DatabaseNameLabel.Size = new System.Drawing.Size(87, 13);
			this.DatabaseNameLabel.TabIndex = 2;
			this.DatabaseNameLabel.Text = "Database Name:";
			this.DatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DatabaseNameTextBox
			// 
			this.DatabaseNameTextBox.Location = new System.Drawing.Point(105, 38);
			this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
			this.DatabaseNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.DatabaseNameTextBox.TabIndex = 3;
			// 
			// UserNameLabel
			// 
			this.UserNameLabel.Location = new System.Drawing.Point(12, 67);
			this.UserNameLabel.Name = "UserNameLabel";
			this.UserNameLabel.Size = new System.Drawing.Size(87, 13);
			this.UserNameLabel.TabIndex = 4;
			this.UserNameLabel.Text = "User Name:";
			this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// UserNameTextBox
			// 
			this.UserNameTextBox.Location = new System.Drawing.Point(105, 64);
			this.UserNameTextBox.Name = "UserNameTextBox";
			this.UserNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.UserNameTextBox.TabIndex = 5;
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.Location = new System.Drawing.Point(12, 93);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(87, 13);
			this.PasswordLabel.TabIndex = 6;
			this.PasswordLabel.Text = "Password:";
			this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Location = new System.Drawing.Point(105, 90);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(200, 20);
			this.PasswordTextBox.TabIndex = 7;
			this.PasswordTextBox.UseSystemPasswordChar = true;
			// 
			// ConnectBtn
			// 
			this.ConnectBtn.Location = new System.Drawing.Point(149, 116);
			this.ConnectBtn.Name = "ConnectBtn";
			this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
			this.ConnectBtn.TabIndex = 8;
			this.ConnectBtn.Text = "Connect";
			this.ConnectBtn.UseVisualStyleBackColor = true;
			this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(230, 116);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// ConnectToDBForm
			// 
			this.AcceptButton = this.ConnectBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(317, 151);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.ConnectBtn);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.UserNameTextBox);
			this.Controls.Add(this.UserNameLabel);
			this.Controls.Add(this.DatabaseNameTextBox);
			this.Controls.Add(this.DatabaseNameLabel);
			this.Controls.Add(this.ServerURLTextBox);
			this.Controls.Add(this.ServerURLLabel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectToDBForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connect to Database...";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ServerURLLabel;
		private System.Windows.Forms.TextBox ServerURLTextBox;
		private System.Windows.Forms.Label DatabaseNameLabel;
		private System.Windows.Forms.TextBox DatabaseNameTextBox;
		private System.Windows.Forms.Label UserNameLabel;
		private System.Windows.Forms.TextBox UserNameTextBox;
		private System.Windows.Forms.Label PasswordLabel;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.Button ConnectBtn;
		private System.Windows.Forms.Button CancelBtn;
	}
}