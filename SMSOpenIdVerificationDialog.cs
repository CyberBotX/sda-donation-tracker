using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SMSOpenIdVerificationDialog : Form
	{
		public string ResultText
		{
			get;
			private set;
		}

		public SMSOpenIdVerificationDialog()
		{
			InitializeComponent();

			this.ResultText = null;
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			this.ResultText = this.SMSVerificationCodeText.Text;
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.ResultText = null;
			this.Close();
		}
	}
}
