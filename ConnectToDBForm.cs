using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class ConnectToDBForm : Form
	{
		public ConnectToDBForm()
		{
			this.InitializeComponent();
		}

		private void ConnectBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
