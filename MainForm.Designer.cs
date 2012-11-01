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
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.FileMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.TrackertestManualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SelectEventMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TrackerDisconnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SearchMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.donorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TabControl = new SDA_DonationTracker.TabCtlEx();
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
            this.TrackertestManualMenuItem,
            this.SelectEventMenuItem,
            this.TrackerDisconnectMenuItem,
            this.QuitMenuItem});
			this.FileMenuHeader.Name = "FileMenuHeader";
			this.FileMenuHeader.Size = new System.Drawing.Size(35, 20);
			this.FileMenuHeader.Text = "&File";
			// 
			// TrackertestManualMenuItem
			// 
			this.TrackertestManualMenuItem.Name = "TrackertestManualMenuItem";
			this.TrackertestManualMenuItem.Size = new System.Drawing.Size(287, 22);
			this.TrackertestManualMenuItem.Text = "Connect To trackertest.uranium-anchor.com";
			this.TrackertestManualMenuItem.Click += new System.EventHandler(this.TrackertestManualMenuItem_Click);
			// 
			// SelectEventMenuItem
			// 
			this.SelectEventMenuItem.Name = "SelectEventMenuItem";
			this.SelectEventMenuItem.Size = new System.Drawing.Size(287, 22);
			this.SelectEventMenuItem.Text = "Select Event";
			this.SelectEventMenuItem.Visible = false;
			this.SelectEventMenuItem.Click += new System.EventHandler(this.selectEventToolStripMenuItem_Click);
			// 
			// TrackerDisconnectMenuItem
			// 
			this.TrackerDisconnectMenuItem.Name = "TrackerDisconnectMenuItem";
			this.TrackerDisconnectMenuItem.Size = new System.Drawing.Size(287, 22);
			this.TrackerDisconnectMenuItem.Text = "Tracker Disconnect";
			this.TrackerDisconnectMenuItem.Visible = false;
			this.TrackerDisconnectMenuItem.Click += new System.EventHandler(this.TrackerDisconnectMenuItem_Click);
			// 
			// QuitMenuItem
			// 
			this.QuitMenuItem.Name = "QuitMenuItem";
			this.QuitMenuItem.ShortcutKeyDisplayString = "";
			this.QuitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.QuitMenuItem.Size = new System.Drawing.Size(287, 22);
			this.QuitMenuItem.Text = "&Quit";
			this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
			// 
			// SearchMenu
			// 
			this.SearchMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donorToolStripMenuItem});
			this.SearchMenu.Name = "SearchMenu";
			this.SearchMenu.Size = new System.Drawing.Size(52, 20);
			this.SearchMenu.Text = "Search";
			this.SearchMenu.Visible = false;
			// 
			// donorToolStripMenuItem
			// 
			this.donorToolStripMenuItem.Name = "donorToolStripMenuItem";
			this.donorToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.donorToolStripMenuItem.Text = "Donor";
			this.donorToolStripMenuItem.Click += new System.EventHandler(this.donorToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem TrackertestManualMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrackerDisconnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchMenu;
        private System.Windows.Forms.ToolStripMenuItem donorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectEventMenuItem;
	}
}

