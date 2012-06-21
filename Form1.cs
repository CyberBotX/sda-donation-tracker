using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.StatusBarLabel.Text = "Testing...";
		}

		private void QuitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
