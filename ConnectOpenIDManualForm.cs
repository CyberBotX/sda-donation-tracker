using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class ConnectOpenIDManualForm : Form
	{
		public TrackerContext Context;

		public ConnectOpenIDManualForm()
		{
			this.InitializeComponent();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.DomainText.Text) || string.IsNullOrWhiteSpace(this.SessionIdText.Text))
			{
				MessageBox.Show(this, "All fields are required.", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.Context.SetSessionId(this.SessionIdText.Text.Trim(), this.DomainText.Text.Trim());
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
