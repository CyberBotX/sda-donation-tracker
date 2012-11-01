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
			this.Context.SetSessionId(this.SessionIdText.Text, this.DomainText.Text);
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
