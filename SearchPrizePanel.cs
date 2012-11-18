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
	public partial class SearchPrizePanel : SearchPanel
	{
		public SearchPrizePanel()
			: base(DonationModels.PrizeModel, 
			new string[] 
			{ 
				"name",
				"description",
				"provided",
			},
			new string[]
			{
				"name",
			})
		{
			InitializeComponent();
		}
	}
}
