using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SDA_DonationTracker
{
	public partial class Form1 : Form
	{
		public MySqlConnection mySqlConn;

		private class MySQLMenus : IDisposable
		{
			private Form1 Parent;
			private ToolStripMenuItem SearchMenuHeader;
			private ToolStripMenuItem SearchDonorMenuItem;
			private ToolStripMenuItem SearchDonationMenuItem;
			private ToolStripMenuItem SearchRunMenuItem;
			private ToolStripMenuItem SearchBidMenuItem;
			private ToolStripMenuItem SearchPrizeMenuItem;
			private ToolStripMenuItem CreateMenuHeader;
			private ToolStripMenuItem CreateNewDonorMenuItem;
			private ToolStripMenuItem CreateNewRunMenuItem;
			private ToolStripMenuItem CreateNewPrizeMenuItem;
			private ToolStripMenuItem TasksMenuHeader;
			private ToolStripMenuItem ReadDonationsMenuItem;
			private ToolStripMenuItem ProcessBidsMenuItem;
			private ToolStripMenuItem ChipinMenuHeader;
			private ToolStripMenuItem MergeFromTextMenuItem;
			private ToolStripMenuItem MergeFromFileMenuItem;
			private ToolStripMenuItem MergeFromChipinMenuItem;

			public MySQLMenus(Form1 parent)
			{
				this.Parent = parent;

				this.SearchMenuHeader = new ToolStripMenuItem();
				this.SearchDonorMenuItem = new ToolStripMenuItem();
				this.SearchDonationMenuItem = new ToolStripMenuItem();
				this.SearchRunMenuItem = new ToolStripMenuItem();
				this.SearchBidMenuItem = new ToolStripMenuItem();
				this.SearchPrizeMenuItem = new ToolStripMenuItem();
				this.CreateMenuHeader = new ToolStripMenuItem();
				this.CreateNewDonorMenuItem = new ToolStripMenuItem();
				this.CreateNewRunMenuItem = new ToolStripMenuItem();
				this.CreateNewPrizeMenuItem = new ToolStripMenuItem();
				this.TasksMenuHeader = new ToolStripMenuItem();
				this.ReadDonationsMenuItem = new ToolStripMenuItem();
				this.ProcessBidsMenuItem = new ToolStripMenuItem();
				this.ChipinMenuHeader = new ToolStripMenuItem();
				this.MergeFromTextMenuItem = new ToolStripMenuItem();
				this.MergeFromFileMenuItem = new ToolStripMenuItem();
				this.MergeFromChipinMenuItem = new ToolStripMenuItem();

				this.SearchMenuHeader.DropDownItems.AddRange(new ToolStripItem[] { this.SearchDonorMenuItem, this.SearchDonationMenuItem, this.SearchRunMenuItem, this.SearchBidMenuItem, this.SearchPrizeMenuItem });
				this.SearchMenuHeader.Name = "SearchMenuHeader";
				this.SearchMenuHeader.Text = "&Search";

				this.SearchDonorMenuItem.Name = "SearchDonorMenuItem";
				this.SearchDonorMenuItem.Text = "Search &Donor...";

				this.SearchDonationMenuItem.Name = "SearchDonationMenuItem";
				this.SearchDonationMenuItem.Text = "Search Dona&tion...";

				this.SearchRunMenuItem.Name = "SearchRunMenuItem";
				this.SearchRunMenuItem.Text = "Search &Run...";

				this.SearchBidMenuItem.Name = "SearchBidMenuItem";
				this.SearchBidMenuItem.Text = "Search &Bid...";

				this.SearchPrizeMenuItem.Name = "SearchPrizeMenuItem";
				this.SearchPrizeMenuItem.Text = "Search &Prize...";

				this.CreateMenuHeader.DropDownItems.AddRange(new ToolStripItem[] { this.CreateNewDonorMenuItem, this.CreateNewRunMenuItem, this.CreateNewPrizeMenuItem });
				this.CreateMenuHeader.Name = "CreateMenuHeader";
				this.CreateMenuHeader.Text = "C&reate";

				this.CreateNewDonorMenuItem.Name = "CreateNewDonorMenuItem";
				this.CreateNewDonorMenuItem.Text = "Create New &Donor";

				this.CreateNewRunMenuItem.Name = "CreateNewRunMenuItem";
				this.CreateNewRunMenuItem.Text = "Create New &Run";

				this.CreateNewPrizeMenuItem.Name = "CreateNewPrizeMenuItem";
				this.CreateNewPrizeMenuItem.Text = "Create New &Prize";

				this.TasksMenuHeader.DropDownItems.AddRange(new ToolStripItem[] { this.ReadDonationsMenuItem, this.ProcessBidsMenuItem });
				this.TasksMenuHeader.Name = "TasksMenuHeader";
				this.TasksMenuHeader.Text = "&Task";

				this.ReadDonationsMenuItem.Name = "ReadDonationsMenuItem";
				this.ReadDonationsMenuItem.Text = "&Read Donations...";

				this.ProcessBidsMenuItem.Name = "ProcessBidsMenuItem";
				this.ProcessBidsMenuItem.Text = "&Process Bids...";

				this.ChipinMenuHeader.DropDownItems.AddRange(new ToolStripItem[] { this.MergeFromTextMenuItem, this.MergeFromFileMenuItem, this.MergeFromChipinMenuItem });
				this.ChipinMenuHeader.Name = "ChipinMenuHeader";
				this.ChipinMenuHeader.Text = "&Chipin";

				this.MergeFromTextMenuItem.Name = "MergeFromTextMenuItem";
				this.MergeFromTextMenuItem.Text = "Merge from &Text...";

				this.MergeFromFileMenuItem.Name = "MergeFromFileMenuItem";
				this.MergeFromFileMenuItem.Text = "Merge from &File...";

				this.MergeFromChipinMenuItem.Name = "MergeFromChipinMenuItem";
				this.MergeFromChipinMenuItem.Text = "Merge from &Chipin website";
				this.MergeFromChipinMenuItem.Enabled = false;

				parent.MenuBar.Items.Insert(1, this.SearchMenuHeader);
				parent.MenuBar.Items.Insert(2, this.CreateMenuHeader);
				parent.MenuBar.Items.Insert(3, this.TasksMenuHeader);
				parent.MenuBar.Items.Insert(4, this.ChipinMenuHeader);
			}

			public void Dispose()
			{
				this.Parent.MenuBar.Items.Remove(this.SearchMenuHeader);
				this.Parent.MenuBar.Items.Remove(this.CreateMenuHeader);
				this.Parent.MenuBar.Items.Remove(this.TasksMenuHeader);
				this.Parent.MenuBar.Items.Remove(this.ChipinMenuHeader);
			}
		}

		private MySQLMenus mySqlMenus;

		public Form1()
		{
			this.InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ConnectToDBMenuItem_Click(object sender, EventArgs e)
		{
			ConnectToDBForm connectToDBForm = new ConnectToDBForm(this);
			connectToDBForm.ShowDialog(this);
		}

		private void DisconnectFromDBMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				this.mySqlConn.Close();
				this.mySqlConn.Dispose();

				this.mySqlMenus.Dispose();
				this.ConnectToDBMenuItem.Visible = true;
				this.DisconnectFromDBMenuItem.Visible = false;
			}
		}

		public void ConnectToDB(string serverName, string database, string userName, string password)
		{
			try
			{
				this.mySqlConn = new MySqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3}", serverName, database, userName, password));
				this.mySqlConn.Open();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			this.mySqlMenus = new MySQLMenus(this);
			this.ConnectToDBMenuItem.Visible = false;
			this.DisconnectFromDBMenuItem.Visible = true;
		}
	}
}
