using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
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
		}

		public void NavigateToDonor(int id)
		{
			TabPageEx donorTab = new TabPageEx()
			{
				Text = string.Format("Donor#{0}", id),
				Name = string.Format("Donor#{0}", id),
				Controls =
				{
					new DonorTab(this.TrackerContext, id)
					{
						Dock = DockStyle.Fill
					}
				}
			};
			this.TabControl.TabPages.Add(donorTab);
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
					new SearchDonorPanel(this.TrackerContext)
					{
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
	}
}
