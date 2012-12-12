using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class SearchChoiceOptionPanel : SearchPanel
	{
		public SearchChoiceOptionPanel()
			: base(DonationModels.ChoiceOptionModel,
			new string[]
			{
				"name",
				"choicename",
				"runname",
			})
		{
		}
	}
}
