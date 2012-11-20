namespace SDA_DonationTracker
{
	partial class PrizeTab
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.NameText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ProvidedByText = new System.Windows.Forms.TextBox();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.DescriptionText = new System.Windows.Forms.TextBox();
			this.ImageURLLabel = new System.Windows.Forms.Label();
			this.ImageURLText = new System.Windows.Forms.TextBox();
			this.WinnerLabel = new System.Windows.Forms.Label();
			this.StartGameLabel = new System.Windows.Forms.Label();
			this.EndGameLabel = new System.Windows.Forms.Label();
			this.WinnerSelector = new SDA_DonationTracker.EntitySelector();
			this.StartGameSelector = new SDA_DonationTracker.EntitySelector();
			this.EndGameSelector = new SDA_DonationTracker.EntitySelector();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 346);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.RefreshButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.SaveButton, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(565, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(112, 100);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(3, 3);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(75, 23);
			this.RefreshButton.TabIndex = 0;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(3, 32);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(3, 61);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(75, 23);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.NameText, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.ProvidedByText, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.DescriptionLabel, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.DescriptionText, 1, 3);
			this.tableLayoutPanel3.Controls.Add(this.ImageURLLabel, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.ImageURLText, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.WinnerSelector, 1, 4);
			this.tableLayoutPanel3.Controls.Add(this.WinnerLabel, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.StartGameLabel, 0, 5);
			this.tableLayoutPanel3.Controls.Add(this.EndGameLabel, 0, 6);
			this.tableLayoutPanel3.Controls.Add(this.StartGameSelector, 1, 5);
			this.tableLayoutPanel3.Controls.Add(this.EndGameSelector, 1, 6);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 9;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(556, 209);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(3, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(38, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name:";
			// 
			// NameText
			// 
			this.NameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NameText.Location = new System.Drawing.Point(76, 3);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(477, 20);
			this.NameText.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Provided By:";
			// 
			// ProvidedByText
			// 
			this.ProvidedByText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ProvidedByText.Location = new System.Drawing.Point(76, 55);
			this.ProvidedByText.Name = "ProvidedByText";
			this.ProvidedByText.Size = new System.Drawing.Size(477, 20);
			this.ProvidedByText.TabIndex = 5;
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Location = new System.Drawing.Point(3, 78);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
			this.DescriptionLabel.TabIndex = 1;
			this.DescriptionLabel.Text = "Description:";
			// 
			// DescriptionText
			// 
			this.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionText.Location = new System.Drawing.Point(76, 81);
			this.DescriptionText.Multiline = true;
			this.DescriptionText.Name = "DescriptionText";
			this.DescriptionText.Size = new System.Drawing.Size(477, 16);
			this.DescriptionText.TabIndex = 3;
			// 
			// ImageURLLabel
			// 
			this.ImageURLLabel.AutoSize = true;
			this.ImageURLLabel.Location = new System.Drawing.Point(3, 26);
			this.ImageURLLabel.Name = "ImageURLLabel";
			this.ImageURLLabel.Size = new System.Drawing.Size(64, 13);
			this.ImageURLLabel.TabIndex = 6;
			this.ImageURLLabel.Text = "Image URL:";
			// 
			// ImageURLText
			// 
			this.ImageURLText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageURLText.Location = new System.Drawing.Point(76, 29);
			this.ImageURLText.Name = "ImageURLText";
			this.ImageURLText.Size = new System.Drawing.Size(477, 20);
			this.ImageURLText.TabIndex = 7;
			// 
			// WinnerLabel
			// 
			this.WinnerLabel.AutoSize = true;
			this.WinnerLabel.Location = new System.Drawing.Point(3, 100);
			this.WinnerLabel.Name = "WinnerLabel";
			this.WinnerLabel.Size = new System.Drawing.Size(44, 13);
			this.WinnerLabel.TabIndex = 9;
			this.WinnerLabel.Text = "Winner:";
			// 
			// StartGameLabel
			// 
			this.StartGameLabel.AutoSize = true;
			this.StartGameLabel.Location = new System.Drawing.Point(3, 126);
			this.StartGameLabel.Name = "StartGameLabel";
			this.StartGameLabel.Size = new System.Drawing.Size(63, 13);
			this.StartGameLabel.TabIndex = 10;
			this.StartGameLabel.Text = "Start Game:";
			// 
			// EndGameLabel
			// 
			this.EndGameLabel.AutoSize = true;
			this.EndGameLabel.Location = new System.Drawing.Point(3, 146);
			this.EndGameLabel.Name = "EndGameLabel";
			this.EndGameLabel.Size = new System.Drawing.Size(60, 13);
			this.EndGameLabel.TabIndex = 11;
			this.EndGameLabel.Text = "End Game:";
			// 
			// WinnerSelector
			// 
			this.WinnerSelector.AutoSize = true;
			this.WinnerSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WinnerSelector.Location = new System.Drawing.Point(76, 103);
			this.WinnerSelector.Model = null;
			this.WinnerSelector.Name = "WinnerSelector";
			this.WinnerSelector.Owner = null;
			this.WinnerSelector.Size = new System.Drawing.Size(477, 20);
			this.WinnerSelector.TabIndex = 8;
			this.WinnerSelector.TrackerContext = null;
			// 
			// StartGameSelector
			// 
			this.StartGameSelector.AutoSize = true;
			this.StartGameSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StartGameSelector.Location = new System.Drawing.Point(76, 129);
			this.StartGameSelector.Model = null;
			this.StartGameSelector.Name = "StartGameSelector";
			this.StartGameSelector.Owner = null;
			this.StartGameSelector.Size = new System.Drawing.Size(477, 14);
			this.StartGameSelector.TabIndex = 12;
			this.StartGameSelector.TrackerContext = null;
			// 
			// EndGameSelector
			// 
			this.EndGameSelector.AutoSize = true;
			this.EndGameSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EndGameSelector.Location = new System.Drawing.Point(76, 149);
			this.EndGameSelector.Model = null;
			this.EndGameSelector.Name = "EndGameSelector";
			this.EndGameSelector.Owner = null;
			this.EndGameSelector.Size = new System.Drawing.Size(477, 14);
			this.EndGameSelector.TabIndex = 13;
			this.EndGameSelector.TrackerContext = null;
			// 
			// PrizeTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "PrizeTab";
			this.Size = new System.Drawing.Size(680, 346);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label DescriptionLabel;
		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.TextBox DescriptionText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ProvidedByText;
		private System.Windows.Forms.Label ImageURLLabel;
		private System.Windows.Forms.TextBox ImageURLText;
		private EntitySelector WinnerSelector;
		private System.Windows.Forms.Label WinnerLabel;
		private System.Windows.Forms.Label StartGameLabel;
		private System.Windows.Forms.Label EndGameLabel;
		private EntitySelector StartGameSelector;
		private EntitySelector EndGameSelector;
	}
}
