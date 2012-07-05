using System.ComponentModel;

namespace SDA_DonationTracker
{
	partial class Form1
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
			this.TabControl = new System.Windows.Forms.TabControl();
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.FileMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.ConnectToDBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DisconnectFromDBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusBar.SuspendLayout();
			this.MenuBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 251);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(292, 22);
			this.StatusBar.TabIndex = 1;
			// 
			// StatusBarLabel
			// 
			this.StatusBarLabel.Name = "StatusBarLabel";
			this.StatusBarLabel.Size = new System.Drawing.Size(0, 17);
			this.StatusBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TabControl
			// 
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Location = new System.Drawing.Point(0, 24);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(292, 227);
			this.TabControl.TabIndex = 0;
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuHeader,
            this.helpToolStripMenuItem});
			this.MenuBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.MenuBar.Size = new System.Drawing.Size(292, 24);
			this.MenuBar.TabIndex = 2;
			// 
			// FileMenuHeader
			// 
			this.FileMenuHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToDBMenuItem,
            this.DisconnectFromDBMenuItem,
            this.QuitMenuItem});
			this.FileMenuHeader.Name = "FileMenuHeader";
			this.FileMenuHeader.Size = new System.Drawing.Size(35, 20);
			this.FileMenuHeader.Text = "&File";
			// 
			// ConnectToDBMenuItem
			// 
			this.ConnectToDBMenuItem.Name = "ConnectToDBMenuItem";
			this.ConnectToDBMenuItem.Size = new System.Drawing.Size(212, 22);
			this.ConnectToDBMenuItem.Text = "&Connect to Database...";
			this.ConnectToDBMenuItem.Click += new System.EventHandler(this.ConnectToDBMenuItem_Click);
			// 
			// DisconnectFromDBMenuItem
			// 
			this.DisconnectFromDBMenuItem.Name = "DisconnectFromDBMenuItem";
			this.DisconnectFromDBMenuItem.Size = new System.Drawing.Size(212, 22);
			this.DisconnectFromDBMenuItem.Text = "&Disconnect from Database...";
			this.DisconnectFromDBMenuItem.Visible = false;
			this.DisconnectFromDBMenuItem.Click += new System.EventHandler(this.DisconnectFromDBMenuItem_Click);
			// 
			// QuitMenuItem
			// 
			this.QuitMenuItem.Name = "QuitMenuItem";
			this.QuitMenuItem.ShortcutKeyDisplayString = "";
			this.QuitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.QuitMenuItem.Size = new System.Drawing.Size(212, 22);
			this.QuitMenuItem.Text = "&Quit";
			this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.TabControl);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.MenuBar);
			this.DoubleBuffered = true;
			this.HelpButton = true;
			this.MainMenuStrip = this.MenuBar;
			this.Name = "Form1";
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
		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem FileMenuHeader;
		private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ConnectToDBMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DisconnectFromDBMenuItem;
	}
}

