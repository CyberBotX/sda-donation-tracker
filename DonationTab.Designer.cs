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
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
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
			this.DonorLabel = new System.Windows.Forms.Label();
			this.DonorSelector = new SDA_DonationTracker.EntitySelector();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.CommentText = new System.Windows.Forms.TextBox();
			this.InternalCommentText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.BidsTable = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BidsTable)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.BidsTable, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.21763F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.78237F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 393);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.splitContainer2.Size = new System.Drawing.Size(428, 258);
			this.splitContainer2.SplitterDistance = 375;
			this.splitContainer2.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
			this.splitContainer1.Size = new System.Drawing.Size(375, 258);
			this.splitContainer1.SplitterDistance = 241;
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
			this.tableLayoutPanel2.Controls.Add(this.DonorLabel, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.DonorSelector, 1, 6);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 9;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 258);
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
			// DonorLabel
			// 
			this.DonorLabel.AutoSize = true;
			this.DonorLabel.Location = new System.Drawing.Point(3, 159);
			this.DonorLabel.Name = "DonorLabel";
			this.DonorLabel.Size = new System.Drawing.Size(39, 13);
			this.DonorLabel.TabIndex = 12;
			this.DonorLabel.Text = "Donor:";
			// 
			// DonorSelector
			// 
			this.DonorSelector.AutoSize = true;
			this.DonorSelector.DisplayFields = null;
			this.DonorSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonorSelector.Location = new System.Drawing.Point(91, 162);
			this.DonorSelector.Model = null;
			this.DonorSelector.Name = "DonorSelector";
			this.DonorSelector.Owner = null;
			this.DonorSelector.Size = new System.Drawing.Size(205, 21);
			this.DonorSelector.TabIndex = 13;
			this.DonorSelector.TrackerContext = null;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.Controls.Add(this.CommentText, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.InternalCommentText, 0, 3);
			this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 4;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(130, 258);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// CommentText
			// 
			this.tableLayoutPanel4.SetColumnSpan(this.CommentText, 2);
			this.CommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentText.Location = new System.Drawing.Point(3, 16);
			this.CommentText.Multiline = true;
			this.CommentText.Name = "CommentText";
			this.CommentText.Size = new System.Drawing.Size(186, 118);
			this.CommentText.TabIndex = 0;
			// 
			// InternalCommentText
			// 
			this.tableLayoutPanel4.SetColumnSpan(this.InternalCommentText, 2);
			this.InternalCommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InternalCommentText.Location = new System.Drawing.Point(3, 153);
			this.InternalCommentText.Multiline = true;
			this.InternalCommentText.Name = "InternalCommentText";
			this.InternalCommentText.Size = new System.Drawing.Size(186, 102);
			this.InternalCommentText.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Comment";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 137);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Internal Comment";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.RefreshButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.SaveButton, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.DeleteButton, 0, 2);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(49, 258);
			this.tableLayoutPanel3.TabIndex = 0;
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
			// BidsTable
			// 
			this.BidsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BidsTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BidsTable.Location = new System.Drawing.Point(3, 267);
			this.BidsTable.Name = "BidsTable";
			this.BidsTable.Size = new System.Drawing.Size(428, 123);
			this.BidsTable.TabIndex = 2;
			// 
			// DonationTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DonationTab";
			this.Size = new System.Drawing.Size(434, 393);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BidsTable)).EndInit();
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
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Label DonorLabel;
		private EntitySelector DonorSelector;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TextBox InternalCommentText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView BidsTable;
	}
}
