using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	class SearchPrizeCategoryPanel : SearchPanel
	{
		public SearchPrizeCategoryPanel()
			: base(DonationModels.PrizeCategoryModel,
			new string[]
			{
				"name"
			})
		{
		}
	}
}
