using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	// TODO: figure out a reasonable way to deal with tabbing:
	// - when you open a tab for an already open entity it should navigate to it and refresh it
	// - there should be a way to cut down on the repetitious code between different tab initializations
	// - Tab name should change after saving a new donor/whatever entity tab
	public partial class MainForm : Form
	{
		public TrackerContext TrackerContext = new TrackerContext();

		public MainForm()
		{
			this.InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";

			this.TabControl.OnClose += this.OnTabClose;
			this.TabControl.ConfirmOnClose = false;
		}

		public void NavigateTo(string model, int id)
		{
			if (model.Equals("donor", StringComparison.OrdinalIgnoreCase))
				this.NavigateToDonor(id);
			else if (model.Equals("donation", StringComparison.OrdinalIgnoreCase))
				this.NavigateToDonation(id);
			else
				throw new Exception("Error, navigation to " + model + " not supported");
		}

		public void NavigateToDonor(int id)
		{
			DonorTab form = new DonorTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill
			};

			TabPageEx donorTab = new TabPageEx()
			{
				Text = string.Format("Donor#{0}", id),
				Name = string.Format("Donor#{0}", id),
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donorTab);
			this.TabControl.SelectTab(donorTab);
			form.RefreshData();
		}

		public void NavigateToDonation(int id)
		{
			DonationTab form = new DonationTab()
			{
				Id = id,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill
			};

			TabPageEx donationTab = new TabPageEx()
			{
				Text = string.Format("Donation#{0}", id),
				Name = string.Format("Donation#{0}", id),
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donationTab);
			this.TabControl.SelectTab(donationTab);
			form.RefreshData();
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void ResetMenus()
		{
			this.TrackerDisconnectMenuItem.Visible = this.TrackerContext.SessionSet;
			this.TrackertestManualMenuItem.Visible = !this.TrackerContext.SessionSet;
			this.SearchMenu.Visible = this.TrackerContext.SessionSet;
			this.SelectEventMenuItem.Visible = this.TrackerContext.SessionSet;
			this.CreateMenu.Visible = this.TrackerContext.SessionSet;
		}

		private void TrackertestManualMenuItem_Click(object sender, EventArgs e)
		{
			ConnectOpenIDManualForm form = new ConnectOpenIDManualForm()
			{
				Context = this.TrackerContext
			};
			form.ShowInTaskbar = false;
			form.ShowDialog(this);

			this.ResetMenus();
		}

		private void TrackerDisconnectMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				this.TrackerContext.ClearSessionId();
				this.ResetMenus();
			}
		}

		private void donorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx donorTab = new TabPageEx()
			{
				Text = "Donor Search",
				Name = "Donor Search",
				Controls =
				{
					new SearchTab(new SearchDonorPanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(donorTab);
		}

		private void OnTabClose(object sender, CloseEventArgs e)
		{
			// eventually this should ask the current tab if it wants to close first
			this.TabControl.Controls.Remove(this.TabControl.TabPages[e.TabIndex]);
		}

		private void selectEventToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectEventDialog dialog = new SelectEventDialog(this, this.TrackerContext);
			dialog.ShowInTaskbar = false;
			dialog.Show(this);
		}

		private void donationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPageEx donorTab = new TabPageEx()
			{
				Text = "Donation Search",
				Name = "Donation Search",
				Controls =
				{
					new SearchTab(new SearchDonationPanel())
					{
						TrackerContext = this.TrackerContext,
						Owner = this,
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(donorTab);
		}
		
		private void CreateDonorMenuItem_Click(object sender, EventArgs e)
		{
			DonorTab form = new DonorTab()
			{
				Id = null,
				TrackerContext = this.TrackerContext,
				Dock = DockStyle.Fill
			};

			TabPageEx donorTab = new TabPageEx()
			{
				Text = string.Format("New Donor"),
				Name = string.Format("New Donor"),
				Controls =
				{
					form
				}
			};

			this.TabControl.TabPages.Add(donorTab);
			this.TabControl.SelectTab(donorTab);
		}
	}
}
