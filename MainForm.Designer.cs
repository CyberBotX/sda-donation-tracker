using System.ComponentModel;

namespace SDA_DonationTracker
{
	partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.StatusBar = new System.Windows.Forms.StatusStrip();
      this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.MenuBar = new System.Windows.Forms.MenuStrip();
      this.FileMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
      this.TrackerOpenIDConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SelectEventMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TrackerDisconnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SearchMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.donorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.donationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.prizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.prizeCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.choiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.challengeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CreateMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.CreateDonorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.donationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.prizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.prizeCategoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.choiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.challengeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.TasksMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.readTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.processDonationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.processDonations2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.chipinMergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.scheduleMergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TabControl = new SDA_DonationTracker.TabCtlEx();
      this.ManualConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.StatusBar.SuspendLayout();
      this.MenuBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // StatusBar
      // 
      this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel});
      this.StatusBar.Location = new System.Drawing.Point(0, 351);
      this.StatusBar.Name = "StatusBar";
      this.StatusBar.Size = new System.Drawing.Size(592, 22);
      this.StatusBar.TabIndex = 1;
      // 
      // StatusBarLabel
      // 
      this.StatusBarLabel.Name = "StatusBarLabel";
      this.StatusBarLabel.Size = new System.Drawing.Size(0, 17);
      this.StatusBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // MenuBar
      // 
      this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuHeader,
            this.SearchMenu,
            this.CreateMenu,
            this.TasksMenu,
            this.helpToolStripMenuItem});
      this.MenuBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.MenuBar.Location = new System.Drawing.Point(0, 0);
      this.MenuBar.Name = "MenuBar";
      this.MenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.MenuBar.Size = new System.Drawing.Size(592, 24);
      this.MenuBar.TabIndex = 2;
      // 
      // FileMenuHeader
      // 
      this.FileMenuHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrackerOpenIDConnectMenuItem,
            this.ManualConnectMenuItem,
            this.SelectEventMenuItem,
            this.TrackerDisconnectMenuItem,
            this.QuitMenuItem});
      this.FileMenuHeader.Name = "FileMenuHeader";
      this.FileMenuHeader.Size = new System.Drawing.Size(35, 20);
      this.FileMenuHeader.Text = "&File";
      // 
      // TrackertestManualMenuItem
      // 
      this.TrackerOpenIDConnectMenuItem.Name = "TrackertestManualMenuItem";
      this.TrackerOpenIDConnectMenuItem.Size = new System.Drawing.Size(208, 22);
      this.TrackerOpenIDConnectMenuItem.Text = "Connect to Tracker Website";
      this.TrackerOpenIDConnectMenuItem.Click += new System.EventHandler(this.TrackertestManualMenuItem_Click);
      // 
      // SelectEventMenuItem
      // 
      this.SelectEventMenuItem.Name = "SelectEventMenuItem";
      this.SelectEventMenuItem.Size = new System.Drawing.Size(208, 22);
      this.SelectEventMenuItem.Text = "Select Event";
      this.SelectEventMenuItem.Visible = false;
      this.SelectEventMenuItem.Click += new System.EventHandler(this.selectEventToolStripMenuItem_Click);
      // 
      // TrackerDisconnectMenuItem
      // 
      this.TrackerDisconnectMenuItem.Name = "TrackerDisconnectMenuItem";
      this.TrackerDisconnectMenuItem.Size = new System.Drawing.Size(208, 22);
      this.TrackerDisconnectMenuItem.Text = "Tracker Disconnect";
      this.TrackerDisconnectMenuItem.Visible = false;
      this.TrackerDisconnectMenuItem.Click += new System.EventHandler(this.TrackerDisconnectMenuItem_Click);
      // 
      // QuitMenuItem
      // 
      this.QuitMenuItem.Name = "QuitMenuItem";
      this.QuitMenuItem.ShortcutKeyDisplayString = "";
      this.QuitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.QuitMenuItem.Size = new System.Drawing.Size(208, 22);
      this.QuitMenuItem.Text = "&Quit";
      this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
      // 
      // SearchMenu
      // 
      this.SearchMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donorToolStripMenuItem,
            this.donationToolStripMenuItem,
            this.prizeToolStripMenuItem,
            this.prizeCategoryToolStripMenuItem,
            this.runToolStripMenuItem,
            this.choiceToolStripMenuItem,
            this.challengeToolStripMenuItem});
      this.SearchMenu.Name = "SearchMenu";
      this.SearchMenu.Size = new System.Drawing.Size(52, 20);
      this.SearchMenu.Text = "Search";
      this.SearchMenu.Visible = false;
      // 
      // donorToolStripMenuItem
      // 
      this.donorToolStripMenuItem.Name = "donorToolStripMenuItem";
      this.donorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.donorToolStripMenuItem.Text = "Donor";
      this.donorToolStripMenuItem.Click += new System.EventHandler(this.donorToolStripMenuItem_Click);
      // 
      // donationToolStripMenuItem
      // 
      this.donationToolStripMenuItem.Name = "donationToolStripMenuItem";
      this.donationToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.donationToolStripMenuItem.Text = "Donation";
      this.donationToolStripMenuItem.Click += new System.EventHandler(this.donationToolStripMenuItem_Click);
      // 
      // prizeToolStripMenuItem
      // 
      this.prizeToolStripMenuItem.Name = "prizeToolStripMenuItem";
      this.prizeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.prizeToolStripMenuItem.Text = "Prize";
      this.prizeToolStripMenuItem.Click += new System.EventHandler(this.prizeToolStripMenuItem_Click);
      // 
      // prizeCategoryToolStripMenuItem
      // 
      this.prizeCategoryToolStripMenuItem.Name = "prizeCategoryToolStripMenuItem";
      this.prizeCategoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.prizeCategoryToolStripMenuItem.Text = "PrizeCategory";
      this.prizeCategoryToolStripMenuItem.Click += new System.EventHandler(this.prizeCategoryToolStripMenuItem_Click);
      // 
      // runToolStripMenuItem
      // 
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.runToolStripMenuItem.Text = "Run";
      this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
      // 
      // choiceToolStripMenuItem
      // 
      this.choiceToolStripMenuItem.Name = "choiceToolStripMenuItem";
      this.choiceToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.choiceToolStripMenuItem.Text = "Choice";
      this.choiceToolStripMenuItem.Click += new System.EventHandler(this.choiceToolStripMenuItem_Click);
      // 
      // challengeToolStripMenuItem
      // 
      this.challengeToolStripMenuItem.Name = "challengeToolStripMenuItem";
      this.challengeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
      this.challengeToolStripMenuItem.Text = "Challenge";
      this.challengeToolStripMenuItem.Click += new System.EventHandler(this.challengeToolStripMenuItem_Click);
      // 
      // CreateMenu
      // 
      this.CreateMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateDonorMenuItem,
            this.donationToolStripMenuItem1,
            this.prizeToolStripMenuItem1,
            this.prizeCategoryToolStripMenuItem1,
            this.runToolStripMenuItem1,
            this.choiceToolStripMenuItem1,
            this.challengeToolStripMenuItem1});
      this.CreateMenu.Name = "CreateMenu";
      this.CreateMenu.Size = new System.Drawing.Size(52, 20);
      this.CreateMenu.Text = "Create";
      this.CreateMenu.Visible = false;
      // 
      // CreateDonorMenuItem
      // 
      this.CreateDonorMenuItem.Name = "CreateDonorMenuItem";
      this.CreateDonorMenuItem.Size = new System.Drawing.Size(145, 22);
      this.CreateDonorMenuItem.Text = "Donor";
      this.CreateDonorMenuItem.Click += new System.EventHandler(this.CreateDonorMenuItem_Click);
      // 
      // donationToolStripMenuItem1
      // 
      this.donationToolStripMenuItem1.Name = "donationToolStripMenuItem1";
      this.donationToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.donationToolStripMenuItem1.Text = "Donation";
      this.donationToolStripMenuItem1.Click += new System.EventHandler(this.donationToolStripMenuItem1_Click);
      // 
      // prizeToolStripMenuItem1
      // 
      this.prizeToolStripMenuItem1.Name = "prizeToolStripMenuItem1";
      this.prizeToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.prizeToolStripMenuItem1.Text = "Prize";
      this.prizeToolStripMenuItem1.Click += new System.EventHandler(this.prizeToolStripMenuItem1_Click);
      // 
      // prizeCategoryToolStripMenuItem1
      // 
      this.prizeCategoryToolStripMenuItem1.Name = "prizeCategoryToolStripMenuItem1";
      this.prizeCategoryToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.prizeCategoryToolStripMenuItem1.Text = "Prize Category";
      this.prizeCategoryToolStripMenuItem1.Click += new System.EventHandler(this.prizeCategoryToolStripMenuItem1_Click);
      // 
      // runToolStripMenuItem1
      // 
      this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
      this.runToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.runToolStripMenuItem1.Text = "Run";
      this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
      // 
      // choiceToolStripMenuItem1
      // 
      this.choiceToolStripMenuItem1.Name = "choiceToolStripMenuItem1";
      this.choiceToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.choiceToolStripMenuItem1.Text = "Choice";
      this.choiceToolStripMenuItem1.Click += new System.EventHandler(this.choiceToolStripMenuItem1_Click);
      // 
      // challengeToolStripMenuItem1
      // 
      this.challengeToolStripMenuItem1.Name = "challengeToolStripMenuItem1";
      this.challengeToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
      this.challengeToolStripMenuItem1.Text = "Challenge";
      this.challengeToolStripMenuItem1.Click += new System.EventHandler(this.challengeToolStripMenuItem1_Click);
      // 
      // TasksMenu
      // 
      this.TasksMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readTaskToolStripMenuItem,
            this.processDonationsToolStripMenuItem,
            this.processDonations2ToolStripMenuItem,
            this.chipinMergeToolStripMenuItem,
            this.scheduleMergeToolStripMenuItem});
      this.TasksMenu.Name = "TasksMenu";
      this.TasksMenu.Size = new System.Drawing.Size(46, 20);
      this.TasksMenu.Text = "Tasks";
      this.TasksMenu.Visible = false;
      // 
      // readTaskToolStripMenuItem
      // 
      this.readTaskToolStripMenuItem.Name = "readTaskToolStripMenuItem";
      this.readTaskToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.readTaskToolStripMenuItem.Text = "Read Task";
      this.readTaskToolStripMenuItem.Click += new System.EventHandler(this.readTaskToolStripMenuItem_Click);
      // 
      // processDonationsToolStripMenuItem
      // 
      this.processDonationsToolStripMenuItem.Name = "processDonationsToolStripMenuItem";
      this.processDonationsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.processDonationsToolStripMenuItem.Text = "Process Donations";
      this.processDonationsToolStripMenuItem.Click += new System.EventHandler(this.processDonationsToolStripMenuItem_Click);
      // 
      // processDonations2ToolStripMenuItem
      // 
      this.processDonations2ToolStripMenuItem.Name = "processDonations2ToolStripMenuItem";
      this.processDonations2ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.processDonations2ToolStripMenuItem.Text = "Process Donations 2";
      this.processDonations2ToolStripMenuItem.Click += new System.EventHandler(this.processDonations2ToolStripMenuItem_Click);
      // 
      // chipinMergeToolStripMenuItem
      // 
      this.chipinMergeToolStripMenuItem.Name = "chipinMergeToolStripMenuItem";
      this.chipinMergeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.chipinMergeToolStripMenuItem.Text = "Chipin Merge";
      this.chipinMergeToolStripMenuItem.Click += new System.EventHandler(this.chipinMergeToolStripMenuItem_Click_1);
      // 
      // scheduleMergeToolStripMenuItem
      // 
      this.scheduleMergeToolStripMenuItem.Name = "scheduleMergeToolStripMenuItem";
      this.scheduleMergeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.scheduleMergeToolStripMenuItem.Text = "Schedule Merge";
      this.scheduleMergeToolStripMenuItem.Click += new System.EventHandler(this.scheduleMergeToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      // 
      // TabControl
      // 
      this.TabControl.ConfirmOnClose = true;
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
      this.TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TabControl.ItemSize = new System.Drawing.Size(230, 24);
      this.TabControl.Location = new System.Drawing.Point(0, 24);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(592, 327);
      this.TabControl.TabIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // ManualConnectMenuItem
      // 
      this.ManualConnectMenuItem.Name = "ManualConnectMenuItem";
      this.ManualConnectMenuItem.Size = new System.Drawing.Size(208, 22);
      this.ManualConnectMenuItem.Text = "Manually Set Session Id";
      this.ManualConnectMenuItem.Click += new System.EventHandler(this.manuallySetSessionIdToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(592, 373);
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.StatusBar);
      this.Controls.Add(this.MenuBar);
      this.DoubleBuffered = true;
      this.HelpButton = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.MenuBar;
      this.Name = "MainForm";
      this.Text = "SDA Donation Tracker";
      this.StatusBar.ResumeLayout(false);
      this.StatusBar.PerformLayout();
      this.MenuBar.ResumeLayout(false);
      this.MenuBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
		private TabCtlEx TabControl;
		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem FileMenuHeader;
		private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrackerOpenIDConnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrackerDisconnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchMenu;
        private System.Windows.Forms.ToolStripMenuItem donorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectEventMenuItem;
		private System.Windows.Forms.ToolStripMenuItem donationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CreateMenu;
		private System.Windows.Forms.ToolStripMenuItem CreateDonorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem donationToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem prizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem prizeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem choiceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem choiceToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem challengeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem challengeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem prizeCategoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem prizeCategoryToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem TasksMenu;
		private System.Windows.Forms.ToolStripMenuItem readTaskToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem processDonationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem processDonations2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem chipinMergeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scheduleMergeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ManualConnectMenuItem;
	}
}

