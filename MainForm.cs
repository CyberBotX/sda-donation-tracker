using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SDA_DonationTracker
{
	public partial class MainForm : Form
	{
        public TrackerContext TrackerContext = new TrackerContext();

		public MainForm()
		{
			this.InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";

            this.TabControl.OnClose += OnTabClose;
            this.TabControl.ConfirmOnClose = false;
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void TrackertestManualMenuItem_Click(object sender, EventArgs e)
        {
            ConnectOpenIDManualForm form = new ConnectOpenIDManualForm() { Context = TrackerContext };
            form.ShowDialog(this);

            this.TrackerDisconnectMenuItem.Visible = TrackerContext.SessionSet;
            this.TrackertestManualMenuItem.Visible = !TrackerContext.SessionSet;
            this.searchToolStripMenuItem.Visible = TrackerContext.SessionSet;
        }

        private void TrackerDisconnectMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TrackerContext.ClearSessionId();
                this.TrackerDisconnectMenuItem.Visible = TrackerContext.SessionSet;
                this.TrackertestManualMenuItem.Visible = !TrackerContext.SessionSet;
                this.searchToolStripMenuItem.Visible = TrackerContext.SessionSet;
            }
        }

        private void donorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageEx donorTab = new TabPageEx();
            donorTab.Text = "Donor Search";
            donorTab.Name = "Donor Search";
            donorTab.Controls.Add(new SearchDonorPanel() { Context = TrackerContext, Dock = DockStyle.Fill });
            this.TabControl.TabPages.Add(donorTab);
        }

        private void OnTabClose(object sender, CloseEventArgs e)
        {
            this.TabControl.Controls.Remove(this.TabControl.TabPages[e.TabIndex]);
        }
	}
}
