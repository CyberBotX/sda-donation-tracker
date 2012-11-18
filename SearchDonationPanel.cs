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
	// TODO: 
	// - do this for all of the other entities
	// - The searching for enum values is pretty unreasonable
	// - Searching for date values doesn't work
	public partial class SearchDonationPanel : SearchPanel
	{
		public SearchDonationPanel()
			: base(DonationModels.DonationModel, 
			new string[] 
			{ 
				"domain",
				//"bidstate",
				//"commentstate",
				//"readstate",
				"amount_lte",
				"amount_gte",
				"time_lte",
				"time_gte",
				"comment",
			},
			new string[]
			{
				"donor__firstname",
				"donor__lastname",
				"amount",
				"domain",
			})
		{
			InitializeComponent();
		}
	}
}
