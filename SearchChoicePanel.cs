using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class SearchChoicePanel : SearchPanel
	{
		public SearchChoicePanel()
			: base(DonationModels.ChoiceModel,
			new string[]
			{
				"name",
				"description",
				"runname",
			})
		{
		}
	}
}
