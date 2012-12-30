using System;
using System.Threading;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class ConnectOpenIDForm : Form
	{
		public TrackerContext Context;
		private MainForm MainForm;

		public ConnectOpenIDForm(MainForm mainForm)
		{
			this.MainForm = mainForm;
			this.InitializeComponent();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.DomainText.Text) ||
				string.IsNullOrWhiteSpace(this.EmailText.Text) ||
				string.IsNullOrWhiteSpace(this.PasswordText.Text))
			{
				MessageBox.Show(this, "All fields are required.", "Missing fields",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			TrackerWebBrowser Browser = new TrackerWebBrowser();
			Thread thread = new Thread(() =>
			{
				Browser.DoLogin(this.DomainText.Text.Trim(), this.EmailText.Text.Trim(),
					this.PasswordText.Text.Trim());
				Application.Run();
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			if (Browser.LoggedIn)
				this.Context.SetSessionId(Browser.SessionID, this.DomainText.Text.Trim());
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
