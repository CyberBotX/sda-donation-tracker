using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SearchDonorTab : UserControl
	{
		public TrackerContext TrackerContext
		{
			get { return SearchDonorPanel.TrackerContext; }
			set { SearchDonorPanel.TrackerContext = value; }
		}

		public MainForm Owner { get; set; }

		public SearchDonorTab()
		{
			InitializeComponent();

			SearchDonorPanel.AddSelectionControl(OpenButton);
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			int[] selections = SearchDonorPanel.GetSelections().ToArray();

			if (selections.Length > 0)
			{
				foreach (var selection in selections)
				{
					Owner.NavigateTo("donor", selection);
				}
			}
		}
	}
}
