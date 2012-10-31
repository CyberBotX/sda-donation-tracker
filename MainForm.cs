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

        public void NavigateTo(string model, int id)
        {
            if (model.Equals("donor", StringComparison.OrdinalIgnoreCase))
            {
                NavigateToDonor(id);
            }
        }

        public void NavigateToDonor(int id)
        {
            TabPageEx donorTab = new TabPageEx();
            donorTab.Text = "Donor#" + id;
            donorTab.Name = "Donor#" + id;
            donorTab.Controls.Add(new DonorTab(TrackerContext, id) { Dock = DockStyle.Fill });
            this.TabControl.TabPages.Add(donorTab);
        }

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        public void ResetMenus()
        {
            this.TrackerDisconnectMenuItem.Visible = TrackerContext.SessionSet;
            this.TrackertestManualMenuItem.Visible = !TrackerContext.SessionSet;
            this.SearchMenu.Visible = TrackerContext.SessionSet;
            this.SelectEventMenuItem.Visible = TrackerContext.SessionSet;
        }

        private void TrackertestManualMenuItem_Click(object sender, EventArgs e)
        {
            ConnectOpenIDManualForm form = new ConnectOpenIDManualForm() { Context = TrackerContext };
            form.ShowDialog(this);

            ResetMenus();
        }

        private void TrackerDisconnectMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to disconnect?", "Confirm Disconnect...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TrackerContext.ClearSessionId();
                ResetMenus();
            }
        }

        private void donorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageEx donorTab = new TabPageEx();
            donorTab.Text = "Donor Search";
            donorTab.Name = "Donor Search";
            donorTab.Controls.Add(new SearchDonorPanel(TrackerContext) { Dock = DockStyle.Fill });
            this.TabControl.TabPages.Add(donorTab);
        }

        private void OnTabClose(object sender, CloseEventArgs e)
        {
            // eventually this should ask the current tab if it wants to close first
            this.TabControl.Controls.Remove(this.TabControl.TabPages[e.TabIndex]);
        }

        private void selectEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectEventDialog dialog = new SelectEventDialog(this, TrackerContext);
            dialog.Show(this);
        }
	}
}
