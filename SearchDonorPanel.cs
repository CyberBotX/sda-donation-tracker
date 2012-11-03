using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SearchDonorPanel : SearchPanel
	{
		public SearchDonorPanel()
			: base(DonationModels.DonorModel, 
			new string[] 
			{ 
				"firstname", "lastname", "alias", "email"
			}, 
			new string[] 
			{ 
				"firstname", "lastname"
			})
		{
		}
	}
}
