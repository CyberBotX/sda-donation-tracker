namespace SDA_DonationTracker
{
	partial class DonationTab
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.DomainText = new System.Windows.Forms.TextBox();
			this.DomainLabel = new System.Windows.Forms.Label();
			this.TimeLabel = new System.Windows.Forms.Label();
			this.TimePicker = new System.Windows.Forms.DateTimePicker();
			this.AmountLabel = new System.Windows.Forms.Label();
			this.AmountText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BidStateBox = new System.Windows.Forms.ComboBox();
			this.ReadStateLabel = new System.Windows.Forms.Label();
			this.ReadStateBox = new System.Windows.Forms.ComboBox();
			this.CommentStateBox = new System.Windows.Forms.ComboBox();
			this.CommentStateLabel = new System.Windows.Forms.Label();
			this.CommentText = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.21763F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.78237F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 363);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.CommentText);
			this.splitContainer1.Size = new System.Drawing.Size(544, 237);
			this.splitContainer1.SplitterDistance = 299;
			this.splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.DomainText, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.DomainLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.TimeLabel, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.TimePicker, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.AmountLabel, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.AmountText, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.BidStateBox, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.ReadStateLabel, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.ReadStateBox, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.CommentStateBox, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.CommentStateLabel, 0, 5);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(299, 161);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// DomainText
			// 
			this.DomainText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DomainText.Location = new System.Drawing.Point(91, 3);
			this.DomainText.Name = "DomainText";
			this.DomainText.ReadOnly = true;
			this.DomainText.Size = new System.Drawing.Size(205, 20);
			this.DomainText.TabIndex = 0;
			// 
			// DomainLabel
			// 
			this.DomainLabel.AutoSize = true;
			this.DomainLabel.Location = new System.Drawing.Point(3, 0);
			this.DomainLabel.Name = "DomainLabel";
			this.DomainLabel.Size = new System.Drawing.Size(46, 13);
			this.DomainLabel.TabIndex = 1;
			this.DomainLabel.Text = "Domain:";
			// 
			// TimeLabel
			// 
			this.TimeLabel.AutoSize = true;
			this.TimeLabel.Location = new System.Drawing.Point(3, 26);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(79, 13);
			this.TimeLabel.TabIndex = 2;
			this.TimeLabel.Text = "TimeReceived:";
			// 
			// TimePicker
			// 
			this.TimePicker.CustomFormat = "yyyy/MM/dd hh:mm:ss";
			this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TimePicker.Location = new System.Drawing.Point(91, 29);
			this.TimePicker.Name = "TimePicker";
			this.TimePicker.ShowUpDown = true;
			this.TimePicker.Size = new System.Drawing.Size(200, 20);
			this.TimePicker.TabIndex = 3;
			// 
			// AmountLabel
			// 
			this.AmountLabel.AutoSize = true;
			this.AmountLabel.Location = new System.Drawing.Point(3, 52);
			this.AmountLabel.Name = "AmountLabel";
			this.AmountLabel.Size = new System.Drawing.Size(46, 13);
			this.AmountLabel.TabIndex = 4;
			this.AmountLabel.Text = "Amount:";
			// 
			// AmountText
			// 
			this.AmountText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AmountText.Location = new System.Drawing.Point(91, 55);
			this.AmountText.Name = "AmountText";
			this.AmountText.Size = new System.Drawing.Size(205, 20);
			this.AmountText.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Bid State:";
			// 
			// BidStateBox
			// 
			this.BidStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BidStateBox.FormattingEnabled = true;
			this.BidStateBox.Location = new System.Drawing.Point(91, 81);
			this.BidStateBox.Name = "BidStateBox";
			this.BidStateBox.Size = new System.Drawing.Size(205, 21);
			this.BidStateBox.TabIndex = 7;
			// 
			// ReadStateLabel
			// 
			this.ReadStateLabel.AutoSize = true;
			this.ReadStateLabel.Location = new System.Drawing.Point(3, 105);
			this.ReadStateLabel.Name = "ReadStateLabel";
			this.ReadStateLabel.Size = new System.Drawing.Size(64, 13);
			this.ReadStateLabel.TabIndex = 8;
			this.ReadStateLabel.Text = "Read State:";
			// 
			// ReadStateBox
			// 
			this.ReadStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReadStateBox.FormattingEnabled = true;
			this.ReadStateBox.Location = new System.Drawing.Point(91, 108);
			this.ReadStateBox.Name = "ReadStateBox";
			this.ReadStateBox.Size = new System.Drawing.Size(205, 21);
			this.ReadStateBox.TabIndex = 9;
			// 
			// CommentStateBox
			// 
			this.CommentStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentStateBox.FormattingEnabled = true;
			this.CommentStateBox.Location = new System.Drawing.Point(91, 135);
			this.CommentStateBox.Name = "CommentStateBox";
			this.CommentStateBox.Size = new System.Drawing.Size(205, 21);
			this.CommentStateBox.TabIndex = 10;
			// 
			// CommentStateLabel
			// 
			this.CommentStateLabel.AutoSize = true;
			this.CommentStateLabel.Location = new System.Drawing.Point(3, 132);
			this.CommentStateLabel.Name = "CommentStateLabel";
			this.CommentStateLabel.Size = new System.Drawing.Size(82, 13);
			this.CommentStateLabel.TabIndex = 11;
			this.CommentStateLabel.Text = "Comment State:";
			// 
			// CommentText
			// 
			this.CommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentText.Location = new System.Drawing.Point(0, 0);
			this.CommentText.Multiline = true;
			this.CommentText.Name = "CommentText";
			this.CommentText.Size = new System.Drawing.Size(241, 237);
			this.CommentText.TabIndex = 0;
			// 
			// DonationTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DonationTab";
			this.Size = new System.Drawing.Size(550, 363);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox DomainText;
		private System.Windows.Forms.Label DomainLabel;
		private System.Windows.Forms.Label TimeLabel;
		private System.Windows.Forms.DateTimePicker TimePicker;
		private System.Windows.Forms.Label AmountLabel;
		private System.Windows.Forms.TextBox AmountText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox BidStateBox;
		private System.Windows.Forms.Label ReadStateLabel;
		private System.Windows.Forms.ComboBox ReadStateBox;
		private System.Windows.Forms.ComboBox CommentStateBox;
		private System.Windows.Forms.Label CommentStateLabel;
		private System.Windows.Forms.TextBox CommentText;
	}
}
