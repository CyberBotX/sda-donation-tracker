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
	// TODO: figure out a way to build this from a search panel
	// Possibly by taking it as a type parameter?
	public partial class SearchDonationTab : UserControl
	{
		public MainForm Owner { get; set; }
		public TrackerContext TrackerContext
		{
			get
			{
				return this.SearchPanel.TrackerContext;
			}
			set
			{
				this.SearchPanel.TrackerContext = value;
			}
		}

		public SearchDonationTab()
		{
			InitializeComponent();
			this.SearchPanel.AddSelectionControl(this.OpenButton);
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine(string.Join("\n", this.SearchPanel.GetSelections()));
		}
	}
}
