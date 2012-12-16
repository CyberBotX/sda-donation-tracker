namespace SDA_DonationTracker
{
	partial class ProcessDonationsTaskTab2
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
			this.RootSplit = new System.Windows.Forms.SplitContainer();
			this.SearchPanelTable = new System.Windows.Forms.TableLayoutPanel();
			this.TaskList = new System.Windows.Forms.ListBox();
			this.NextButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.ModeBox = new System.Windows.Forms.ComboBox();
			this.DonationPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DonorLabel = new System.Windows.Forms.Label();
			this.AmountLabel = new System.Windows.Forms.Label();
			this.AmountText = new System.Windows.Forms.TextBox();
			this.CommentLabel = new System.Windows.Forms.Label();
			this.CommentText = new System.Windows.Forms.TextBox();
			this.ModCommentLabel = new System.Windows.Forms.Label();
			this.ModCommentText = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OpenDonationButton = new System.Windows.Forms.Button();
			this.OpenDonorButton = new System.Windows.Forms.Button();
			this.ReadStateLabel = new System.Windows.Forms.Label();
			this.CommentStateLabel = new System.Windows.Forms.Label();
			this.BidStateLabel = new System.Windows.Forms.Label();
			this.ReadStateBox = new System.Windows.Forms.ComboBox();
			this.CommentStateBox = new System.Windows.Forms.ComboBox();
			this.BidStateBox = new System.Windows.Forms.ComboBox();
			this.DonorSelector = new SDA_DonationTracker.EntitySelector();
			((System.ComponentModel.ISupportInitialize)(this.RootSplit)).BeginInit();
			this.RootSplit.Panel1.SuspendLayout();
			this.RootSplit.Panel2.SuspendLayout();
			this.RootSplit.SuspendLayout();
			this.SearchPanelTable.SuspendLayout();
			this.DonationPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootSplit
			// 
			this.RootSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootSplit.Location = new System.Drawing.Point(0, 0);
			this.RootSplit.Name = "RootSplit";
			// 
			// RootSplit.Panel1
			// 
			this.RootSplit.Panel1.Controls.Add(this.SearchPanelTable);
			// 
			// RootSplit.Panel2
			// 
			this.RootSplit.Panel2.Controls.Add(this.DonationPanel);
			this.RootSplit.Size = new System.Drawing.Size(673, 380);
			this.RootSplit.SplitterDistance = 223;
			this.RootSplit.TabIndex = 0;
			// 
			// SearchPanelTable
			// 
			this.SearchPanelTable.ColumnCount = 2;
			this.SearchPanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.SearchPanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.SearchPanelTable.Controls.Add(this.TaskList, 0, 1);
			this.SearchPanelTable.Controls.Add(this.NextButton, 1, 0);
			this.SearchPanelTable.Controls.Add(this.RefreshButton, 0, 0);
			this.SearchPanelTable.Controls.Add(this.label3, 0, 2);
			this.SearchPanelTable.Controls.Add(this.ModeBox, 1, 2);
			this.SearchPanelTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchPanelTable.Location = new System.Drawing.Point(0, 0);
			this.SearchPanelTable.Name = "SearchPanelTable";
			this.SearchPanelTable.RowCount = 3;
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.SearchPanelTable.Size = new System.Drawing.Size(223, 380);
			this.SearchPanelTable.TabIndex = 0;
			// 
			// TaskList
			// 
			this.SearchPanelTable.SetColumnSpan(this.TaskList, 2);
			this.TaskList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TaskList.FormattingEnabled = true;
			this.TaskList.Location = new System.Drawing.Point(3, 32);
			this.TaskList.Name = "TaskList";
			this.TaskList.Size = new System.Drawing.Size(217, 325);
			this.TaskList.TabIndex = 0;
			// 
			// NextButton
			// 
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NextButton.Enabled = false;
			this.NextButton.Location = new System.Drawing.Point(114, 3);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(106, 23);
			this.NextButton.TabIndex = 1;
			this.NextButton.Text = "Save";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RefreshButton.Location = new System.Drawing.Point(3, 3);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(105, 23);
			this.RefreshButton.TabIndex = 2;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 360);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Processing Mode:";
			// 
			// ModeBox
			// 
			this.ModeBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModeBox.FormattingEnabled = true;
			this.ModeBox.Location = new System.Drawing.Point(114, 363);
			this.ModeBox.Name = "ModeBox";
			this.ModeBox.Size = new System.Drawing.Size(106, 21);
			this.ModeBox.TabIndex = 7;
			// 
			// DonationPanel
			// 
			this.DonationPanel.ColumnCount = 2;
			this.DonationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.DonationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.DonationPanel.Controls.Add(this.DonorLabel, 0, 0);
			this.DonationPanel.Controls.Add(this.AmountLabel, 0, 1);
			this.DonationPanel.Controls.Add(this.AmountText, 1, 1);
			this.DonationPanel.Controls.Add(this.CommentLabel, 0, 2);
			this.DonationPanel.Controls.Add(this.CommentText, 1, 2);
			this.DonationPanel.Controls.Add(this.ModCommentLabel, 0, 3);
			this.DonationPanel.Controls.Add(this.ModCommentText, 1, 3);
			this.DonationPanel.Controls.Add(this.tableLayoutPanel1, 1, 8);
			this.DonationPanel.Controls.Add(this.ReadStateLabel, 0, 4);
			this.DonationPanel.Controls.Add(this.CommentStateLabel, 0, 5);
			this.DonationPanel.Controls.Add(this.BidStateLabel, 0, 6);
			this.DonationPanel.Controls.Add(this.ReadStateBox, 1, 4);
			this.DonationPanel.Controls.Add(this.CommentStateBox, 1, 5);
			this.DonationPanel.Controls.Add(this.BidStateBox, 1, 6);
			this.DonationPanel.Controls.Add(this.DonorSelector, 1, 0);
			this.DonationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonationPanel.Location = new System.Drawing.Point(0, 0);
			this.DonationPanel.Name = "DonationPanel";
			this.DonationPanel.RowCount = 9;
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.68965F));
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.03448F));
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.Size = new System.Drawing.Size(446, 380);
			this.DonationPanel.TabIndex = 0;
			// 
			// DonorLabel
			// 
			this.DonorLabel.AutoSize = true;
			this.DonorLabel.Location = new System.Drawing.Point(3, 0);
			this.DonorLabel.Name = "DonorLabel";
			this.DonorLabel.Size = new System.Drawing.Size(39, 13);
			this.DonorLabel.TabIndex = 0;
			this.DonorLabel.Text = "Donor:";
			// 
			// AmountLabel
			// 
			this.AmountLabel.AutoSize = true;
			this.AmountLabel.Location = new System.Drawing.Point(3, 35);
			this.AmountLabel.Name = "AmountLabel";
			this.AmountLabel.Size = new System.Drawing.Size(46, 13);
			this.AmountLabel.TabIndex = 2;
			this.AmountLabel.Text = "Amount:";
			// 
			// AmountText
			// 
			this.AmountText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AmountText.Location = new System.Drawing.Point(91, 38);
			this.AmountText.Name = "AmountText";
			this.AmountText.Size = new System.Drawing.Size(352, 20);
			this.AmountText.TabIndex = 4;
			// 
			// CommentLabel
			// 
			this.CommentLabel.AutoSize = true;
			this.CommentLabel.Location = new System.Drawing.Point(3, 61);
			this.CommentLabel.Name = "CommentLabel";
			this.CommentLabel.Size = new System.Drawing.Size(51, 13);
			this.CommentLabel.TabIndex = 5;
			this.CommentLabel.Text = "Comment";
			// 
			// CommentText
			// 
			this.CommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentText.Location = new System.Drawing.Point(91, 64);
			this.CommentText.Multiline = true;
			this.CommentText.Name = "CommentText";
			this.CommentText.Size = new System.Drawing.Size(352, 88);
			this.CommentText.TabIndex = 6;
			// 
			// ModCommentLabel
			// 
			this.ModCommentLabel.AutoSize = true;
			this.ModCommentLabel.Location = new System.Drawing.Point(3, 155);
			this.ModCommentLabel.Name = "ModCommentLabel";
			this.ModCommentLabel.Size = new System.Drawing.Size(45, 13);
			this.ModCommentLabel.TabIndex = 7;
			this.ModCommentLabel.Text = "Internal:";
			// 
			// ModCommentText
			// 
			this.ModCommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModCommentText.Location = new System.Drawing.Point(91, 158);
			this.ModCommentText.Multiline = true;
			this.ModCommentText.Name = "ModCommentText";
			this.ModCommentText.Size = new System.Drawing.Size(352, 34);
			this.ModCommentText.TabIndex = 8;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.OpenDonationButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.OpenDonorButton, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(91, 339);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 38);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// OpenDonationButton
			// 
			this.OpenDonationButton.Enabled = false;
			this.OpenDonationButton.Location = new System.Drawing.Point(143, 3);
			this.OpenDonationButton.Name = "OpenDonationButton";
			this.OpenDonationButton.Size = new System.Drawing.Size(105, 20);
			this.OpenDonationButton.TabIndex = 9;
			this.OpenDonationButton.Text = "Open Donation";
			this.OpenDonationButton.UseVisualStyleBackColor = true;
			this.OpenDonationButton.Click += new System.EventHandler(this.OpenDonationButton_Click);
			// 
			// OpenDonorButton
			// 
			this.OpenDonorButton.Enabled = false;
			this.OpenDonorButton.Location = new System.Drawing.Point(254, 3);
			this.OpenDonorButton.Name = "OpenDonorButton";
			this.OpenDonorButton.Size = new System.Drawing.Size(95, 20);
			this.OpenDonorButton.TabIndex = 10;
			this.OpenDonorButton.Text = "Open Donor";
			this.OpenDonorButton.UseVisualStyleBackColor = true;
			this.OpenDonorButton.Click += new System.EventHandler(this.OpenDonorButton_Click);
			// 
			// ReadStateLabel
			// 
			this.ReadStateLabel.AutoSize = true;
			this.ReadStateLabel.Location = new System.Drawing.Point(3, 195);
			this.ReadStateLabel.Name = "ReadStateLabel";
			this.ReadStateLabel.Size = new System.Drawing.Size(64, 13);
			this.ReadStateLabel.TabIndex = 11;
			this.ReadStateLabel.Text = "Read State:";
			// 
			// CommentStateLabel
			// 
			this.CommentStateLabel.AutoSize = true;
			this.CommentStateLabel.Location = new System.Drawing.Point(3, 222);
			this.CommentStateLabel.Name = "CommentStateLabel";
			this.CommentStateLabel.Size = new System.Drawing.Size(82, 13);
			this.CommentStateLabel.TabIndex = 12;
			this.CommentStateLabel.Text = "Comment State:";
			// 
			// BidStateLabel
			// 
			this.BidStateLabel.AutoSize = true;
			this.BidStateLabel.Location = new System.Drawing.Point(3, 249);
			this.BidStateLabel.Name = "BidStateLabel";
			this.BidStateLabel.Size = new System.Drawing.Size(50, 13);
			this.BidStateLabel.TabIndex = 13;
			this.BidStateLabel.Text = "BidState:";
			// 
			// ReadStateBox
			// 
			this.ReadStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReadStateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ReadStateBox.FormattingEnabled = true;
			this.ReadStateBox.Location = new System.Drawing.Point(91, 198);
			this.ReadStateBox.Name = "ReadStateBox";
			this.ReadStateBox.Size = new System.Drawing.Size(352, 21);
			this.ReadStateBox.TabIndex = 14;
			// 
			// CommentStateBox
			// 
			this.CommentStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentStateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CommentStateBox.FormattingEnabled = true;
			this.CommentStateBox.Location = new System.Drawing.Point(91, 225);
			this.CommentStateBox.Name = "CommentStateBox";
			this.CommentStateBox.Size = new System.Drawing.Size(352, 21);
			this.CommentStateBox.TabIndex = 15;
			// 
			// BidStateBox
			// 
			this.BidStateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BidStateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BidStateBox.FormattingEnabled = true;
			this.BidStateBox.Location = new System.Drawing.Point(91, 252);
			this.BidStateBox.Name = "BidStateBox";
			this.BidStateBox.Size = new System.Drawing.Size(352, 21);
			this.BidStateBox.TabIndex = 16;
			// 
			// DonorSelector
			// 
			this.DonorSelector.AutoSize = true;
			this.DonorSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonorSelector.Location = new System.Drawing.Point(91, 3);
			this.DonorSelector.Name = "DonorSelector";
			this.DonorSelector.Owner = null;
			this.DonorSelector.Size = new System.Drawing.Size(352, 29);
			this.DonorSelector.TabIndex = 17;
			this.DonorSelector.UseSelectionCache = false;
			this.DonorSelector.Value = null;
			// 
			// ProcessDonationsTaskTab2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RootSplit);
			this.Name = "ProcessDonationsTaskTab2";
			this.Size = new System.Drawing.Size(673, 380);
			this.RootSplit.Panel1.ResumeLayout(false);
			this.RootSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RootSplit)).EndInit();
			this.RootSplit.ResumeLayout(false);
			this.SearchPanelTable.ResumeLayout(false);
			this.SearchPanelTable.PerformLayout();
			this.DonationPanel.ResumeLayout(false);
			this.DonationPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer RootSplit;
		private System.Windows.Forms.TableLayoutPanel DonationPanel;
		private System.Windows.Forms.TableLayoutPanel SearchPanelTable;
		private System.Windows.Forms.ListBox TaskList;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.Label DonorLabel;
		private System.Windows.Forms.Label AmountLabel;
		private System.Windows.Forms.TextBox AmountText;
		private System.Windows.Forms.Label CommentLabel;
		private System.Windows.Forms.TextBox CommentText;
		private System.Windows.Forms.Label ModCommentLabel;
		private System.Windows.Forms.TextBox ModCommentText;
		private System.Windows.Forms.Button OpenDonationButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button OpenDonorButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ModeBox;
		private System.Windows.Forms.Label ReadStateLabel;
		private System.Windows.Forms.Label CommentStateLabel;
		private System.Windows.Forms.Label BidStateLabel;
		private System.Windows.Forms.ComboBox ReadStateBox;
		private System.Windows.Forms.ComboBox CommentStateBox;
		private System.Windows.Forms.ComboBox BidStateBox;
		private EntitySelector DonorSelector;
	}
}
