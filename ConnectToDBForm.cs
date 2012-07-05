using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class ConnectToDBForm : Form
	{
		private Form1 FormParent;

		public ConnectToDBForm(Form1 parent)
		{
			//this.Parent = parent;
			this.FormParent = parent;

			this.InitializeComponent();
		}

		private void ConnectBtn_Click(object sender, EventArgs e)
		{
			this.FormParent.ConnectToDB(this.ServerURLTextBox.Text, this.DatabaseNameTextBox.Text, this.UserNameTextBox.Text, this.PasswordTextBox.Text);
			this.Close();
		}
	}
}
