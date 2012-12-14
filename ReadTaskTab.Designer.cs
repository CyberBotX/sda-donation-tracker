namespace SDA_DonationTracker
{
	partial class ReadTaskTab
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
			this.DonationPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DonorLabel = new System.Windows.Forms.Label();
			this.AmountLabel = new System.Windows.Forms.Label();
			this.DonorNameText = new System.Windows.Forms.TextBox();
			this.AmountText = new System.Windows.Forms.TextBox();
			this.CommentLabel = new System.Windows.Forms.Label();
			this.CommentText = new System.Windows.Forms.TextBox();
			this.ModCommentLabel = new System.Windows.Forms.Label();
			this.ModCommentText = new System.Windows.Forms.TextBox();
			this.OpenDonationButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OpenDonorButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MinimumAmountText = new System.Windows.Forms.TextBox();
			this.ModeBox = new System.Windows.Forms.ComboBox();
			this.MinimumMinutesText = new System.Windows.Forms.TextBox();
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
			this.SearchPanelTable.Controls.Add(this.label1, 0, 2);
			this.SearchPanelTable.Controls.Add(this.label2, 0, 3);
			this.SearchPanelTable.Controls.Add(this.label3, 0, 4);
			this.SearchPanelTable.Controls.Add(this.MinimumAmountText, 1, 2);
			this.SearchPanelTable.Controls.Add(this.ModeBox, 1, 4);
			this.SearchPanelTable.Controls.Add(this.MinimumMinutesText, 1, 3);
			this.SearchPanelTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchPanelTable.Location = new System.Drawing.Point(0, 0);
			this.SearchPanelTable.Name = "SearchPanelTable";
			this.SearchPanelTable.RowCount = 5;
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.SearchPanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
			this.TaskList.Size = new System.Drawing.Size(217, 285);
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
			this.NextButton.Text = "Mark As Read";
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
			// DonationPanel
			// 
			this.DonationPanel.ColumnCount = 2;
			this.DonationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.DonationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.DonationPanel.Controls.Add(this.DonorLabel, 0, 0);
			this.DonationPanel.Controls.Add(this.AmountLabel, 0, 1);
			this.DonationPanel.Controls.Add(this.DonorNameText, 1, 0);
			this.DonationPanel.Controls.Add(this.AmountText, 1, 1);
			this.DonationPanel.Controls.Add(this.CommentLabel, 0, 2);
			this.DonationPanel.Controls.Add(this.CommentText, 1, 2);
			this.DonationPanel.Controls.Add(this.ModCommentLabel, 0, 3);
			this.DonationPanel.Controls.Add(this.ModCommentText, 1, 3);
			this.DonationPanel.Controls.Add(this.tableLayoutPanel1, 1, 4);
			this.DonationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonationPanel.Location = new System.Drawing.Point(0, 0);
			this.DonationPanel.Name = "DonationPanel";
			this.DonationPanel.RowCount = 5;
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.DonationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
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
			this.AmountLabel.Location = new System.Drawing.Point(3, 26);
			this.AmountLabel.Name = "AmountLabel";
			this.AmountLabel.Size = new System.Drawing.Size(46, 13);
			this.AmountLabel.TabIndex = 2;
			this.AmountLabel.Text = "Amount:";
			// 
			// DonorNameText
			// 
			this.DonorNameText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DonorNameText.Location = new System.Drawing.Point(60, 3);
			this.DonorNameText.Name = "DonorNameText";
			this.DonorNameText.ReadOnly = true;
			this.DonorNameText.Size = new System.Drawing.Size(383, 20);
			this.DonorNameText.TabIndex = 3;
			// 
			// AmountText
			// 
			this.AmountText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AmountText.Location = new System.Drawing.Point(60, 29);
			this.AmountText.Name = "AmountText";
			this.AmountText.ReadOnly = true;
			this.AmountText.Size = new System.Drawing.Size(383, 20);
			this.AmountText.TabIndex = 4;
			// 
			// CommentLabel
			// 
			this.CommentLabel.AutoSize = true;
			this.CommentLabel.Location = new System.Drawing.Point(3, 52);
			this.CommentLabel.Name = "CommentLabel";
			this.CommentLabel.Size = new System.Drawing.Size(51, 13);
			this.CommentLabel.TabIndex = 5;
			this.CommentLabel.Text = "Comment";
			// 
			// CommentText
			// 
			this.CommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentText.Location = new System.Drawing.Point(60, 55);
			this.CommentText.Multiline = true;
			this.CommentText.Name = "CommentText";
			this.CommentText.ReadOnly = true;
			this.CommentText.Size = new System.Drawing.Size(383, 201);
			this.CommentText.TabIndex = 6;
			// 
			// ModCommentLabel
			// 
			this.ModCommentLabel.AutoSize = true;
			this.ModCommentLabel.Location = new System.Drawing.Point(3, 259);
			this.ModCommentLabel.Name = "ModCommentLabel";
			this.ModCommentLabel.Size = new System.Drawing.Size(45, 13);
			this.ModCommentLabel.TabIndex = 7;
			this.ModCommentLabel.Text = "Internal:";
			// 
			// ModCommentText
			// 
			this.ModCommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModCommentText.Location = new System.Drawing.Point(60, 262);
			this.ModCommentText.Multiline = true;
			this.ModCommentText.Name = "ModCommentText";
			this.ModCommentText.ReadOnly = true;
			this.ModCommentText.Size = new System.Drawing.Size(383, 83);
			this.ModCommentText.TabIndex = 8;
			// 
			// OpenDonationButton
			// 
			this.OpenDonationButton.Enabled = false;
			this.OpenDonationButton.Location = new System.Drawing.Point(174, 3);
			this.OpenDonationButton.Name = "OpenDonationButton";
			this.OpenDonationButton.Size = new System.Drawing.Size(105, 20);
			this.OpenDonationButton.TabIndex = 9;
			this.OpenDonationButton.Text = "Open Donation";
			this.OpenDonationButton.UseVisualStyleBackColor = true;
			this.OpenDonationButton.Click += new System.EventHandler(this.OpenDonationButton_Click);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(60, 351);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 26);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// OpenDonorButton
			// 
			this.OpenDonorButton.Enabled = false;
			this.OpenDonorButton.Location = new System.Drawing.Point(285, 3);
			this.OpenDonorButton.Name = "OpenDonorButton";
			this.OpenDonorButton.Size = new System.Drawing.Size(95, 20);
			this.OpenDonorButton.TabIndex = 10;
			this.OpenDonorButton.Text = "Open Donor";
			this.OpenDonorButton.UseVisualStyleBackColor = true;
			this.OpenDonorButton.Click += new System.EventHandler(this.OpenDonorButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 320);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Minimum Amount:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 340);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Minimum Time (minutes):";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 360);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Mode:";
			// 
			// MinimumAmountText
			// 
			this.MinimumAmountText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MinimumAmountText.Location = new System.Drawing.Point(114, 323);
			this.MinimumAmountText.Name = "MinimumAmountText";
			this.MinimumAmountText.Size = new System.Drawing.Size(106, 20);
			this.MinimumAmountText.TabIndex = 6;
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
			// MinimumMinutesText
			// 
			this.MinimumMinutesText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MinimumMinutesText.Location = new System.Drawing.Point(114, 343);
			this.MinimumMinutesText.Name = "MinimumMinutesText";
			this.MinimumMinutesText.Size = new System.Drawing.Size(106, 20);
			this.MinimumMinutesText.TabIndex = 8;
			// 
			// ReadTaskTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RootSplit);
			this.Name = "ReadTaskTab";
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
		private System.Windows.Forms.TextBox DonorNameText;
		private System.Windows.Forms.TextBox AmountText;
		private System.Windows.Forms.Label CommentLabel;
		private System.Windows.Forms.TextBox CommentText;
		private System.Windows.Forms.Label ModCommentLabel;
		private System.Windows.Forms.TextBox ModCommentText;
		private System.Windows.Forms.Button OpenDonationButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button OpenDonorButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox MinimumAmountText;
		private System.Windows.Forms.ComboBox ModeBox;
		private System.Windows.Forms.TextBox MinimumMinutesText;
	}
}
