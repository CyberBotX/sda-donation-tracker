namespace SDA_DonationTracker
{
	partial class RunTab
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.StartTimeLabel = new System.Windows.Forms.Label();
			this.EndTimeLabel = new System.Windows.Forms.Label();
			this.RunnersLabel = new System.Windows.Forms.Label();
			this.NameText = new System.Windows.Forms.TextBox();
			this.RunnersText = new System.Windows.Forms.TextBox();
			this.DescriptionText = new System.Windows.Forms.TextBox();
			this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
			this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(557, 347);
			this.splitContainer1.SplitterDistance = 208;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Size = new System.Drawing.Size(557, 135);
			this.splitContainer2.SplitterDistance = 380;
			this.splitContainer2.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.EndTimeLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.StartTimeLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.RunnersLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.NameText, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.RunnersText, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.DescriptionText, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.StartTimePicker, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.EndTimePicker, 1, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 208);
			this.tableLayoutPanel1.TabIndex = 0;
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
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Location = new System.Drawing.Point(3, 52);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
			this.DescriptionLabel.TabIndex = 1;
			this.DescriptionLabel.Text = "Description";
			// 
			// StartTimeLabel
			// 
			this.StartTimeLabel.AutoSize = true;
			this.StartTimeLabel.Location = new System.Drawing.Point(3, 94);
			this.StartTimeLabel.Name = "StartTimeLabel";
			this.StartTimeLabel.Size = new System.Drawing.Size(58, 13);
			this.StartTimeLabel.TabIndex = 2;
			this.StartTimeLabel.Text = "Start Time:";
			// 
			// EndTimeLabel
			// 
			this.EndTimeLabel.AutoSize = true;
			this.EndTimeLabel.Location = new System.Drawing.Point(3, 120);
			this.EndTimeLabel.Name = "EndTimeLabel";
			this.EndTimeLabel.Size = new System.Drawing.Size(55, 13);
			this.EndTimeLabel.TabIndex = 3;
			this.EndTimeLabel.Text = "End Time:";
			// 
			// RunnersLabel
			// 
			this.RunnersLabel.AutoSize = true;
			this.RunnersLabel.Location = new System.Drawing.Point(3, 26);
			this.RunnersLabel.Name = "RunnersLabel";
			this.RunnersLabel.Size = new System.Drawing.Size(50, 13);
			this.RunnersLabel.TabIndex = 4;
			this.RunnersLabel.Text = "Runners:";
			// 
			// NameText
			// 
			this.NameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NameText.Location = new System.Drawing.Point(69, 3);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(377, 20);
			this.NameText.TabIndex = 5;
			// 
			// RunnersText
			// 
			this.RunnersText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RunnersText.Location = new System.Drawing.Point(69, 29);
			this.RunnersText.Name = "RunnersText";
			this.RunnersText.Size = new System.Drawing.Size(377, 20);
			this.RunnersText.TabIndex = 6;
			// 
			// DescriptionText
			// 
			this.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionText.Location = new System.Drawing.Point(69, 55);
			this.DescriptionText.Multiline = true;
			this.DescriptionText.Name = "DescriptionText";
			this.DescriptionText.Size = new System.Drawing.Size(377, 36);
			this.DescriptionText.TabIndex = 7;
			// 
			// StartTimePicker
			// 
			this.StartTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.StartTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.StartTimePicker.Location = new System.Drawing.Point(69, 97);
			this.StartTimePicker.Name = "StartTimePicker";
			this.StartTimePicker.ShowUpDown = true;
			this.StartTimePicker.Size = new System.Drawing.Size(377, 20);
			this.StartTimePicker.TabIndex = 8;
			// 
			// EndTimePicker
			// 
			this.EndTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.EndTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.EndTimePicker.Location = new System.Drawing.Point(69, 123);
			this.EndTimePicker.Name = "EndTimePicker";
			this.EndTimePicker.ShowUpDown = true;
			this.EndTimePicker.Size = new System.Drawing.Size(377, 20);
			this.EndTimePicker.TabIndex = 9;
			// 
			// RefreshButton
			// 
			this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RefreshButton.Location = new System.Drawing.Point(26, 3);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(75, 23);
			this.RefreshButton.TabIndex = 10;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(26, 32);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 11;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteButton.Location = new System.Drawing.Point(26, 61);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(75, 23);
			this.DeleteButton.TabIndex = 12;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer3.Size = new System.Drawing.Size(557, 208);
			this.splitContainer3.SplitterDistance = 449;
			this.splitContainer3.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.RefreshButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.SaveButton, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(104, 208);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// RunTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "RunTab";
			this.Size = new System.Drawing.Size(557, 347);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label EndTimeLabel;
		private System.Windows.Forms.Label StartTimeLabel;
		private System.Windows.Forms.Label DescriptionLabel;
		private System.Windows.Forms.Label RunnersLabel;
		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.TextBox RunnersText;
		private System.Windows.Forms.TextBox DescriptionText;
		private System.Windows.Forms.DateTimePicker StartTimePicker;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.DateTimePicker EndTimePicker;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

	}
}
