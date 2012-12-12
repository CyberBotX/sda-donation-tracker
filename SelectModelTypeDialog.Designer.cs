namespace SDA_DonationTracker
{
	partial class SelectModelTypeDialog
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
			this.ModelTypeBox = new System.Windows.Forms.ComboBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ModelTypeBox
			// 
			this.ModelTypeBox.FormattingEnabled = true;
			this.ModelTypeBox.Location = new System.Drawing.Point(12, 32);
			this.ModelTypeBox.Name = "ModelTypeBox";
			this.ModelTypeBox.Size = new System.Drawing.Size(279, 21);
			this.ModelTypeBox.TabIndex = 0;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(135, 73);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 1;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(216, 73);
			this.CloseButton.Name = "CancelButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 2;
			this.CloseButton.Text = "Cancel";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SelectModelTypeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 108);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.ModelTypeBox);
			this.Name = "SelectModelTypeDialog";
			this.Text = "SelectModelTypeDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox ModelTypeBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CloseButton;
	}
}