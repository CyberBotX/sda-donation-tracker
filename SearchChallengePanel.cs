using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class SearchChallengePanel : SearchPanel
	{
		public SearchChallengePanel()
			: base(DonationModels.ChallengeModel,
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
