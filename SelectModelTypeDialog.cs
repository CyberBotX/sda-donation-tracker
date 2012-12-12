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
	public partial class SelectModelTypeDialog : Form
	{
		public string Selection
		{
			get;
			private set;
		}

		public SelectModelTypeDialog(IEnumerable<string> choices)
		{
			InitializeComponent();

			this.ModelTypeBox.DataSource = choices.ToArray();
			this.ModelTypeBox.SelectedItem = choices.First();
			this.Selection = null;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			this.Selection = this.ModelTypeBox.SelectedItem.ToString();
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Selection = null;
			this.Close();
		}
	}
}
