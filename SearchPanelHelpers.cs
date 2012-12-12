using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public static class SearchPanelHelpers
	{
		private static readonly string[] SearchModels = new string[]
		{
			"donor",
			"donation",
			"run",
			"choice",
			"challenge",
			"choiceoption",
			"prize",
			"prizecategory",
		};

		public static bool HasSearchPanel(string modelName)
		{
			return SearchModels.Contains(modelName.ToLower());
		}

		public static SearchPanel CreatePanelForModel(string modelName)
		{
			if (modelName.IEquals("donor"))
			{
				return new SearchDonorPanel();
			}
			else if (modelName.IEquals("donation"))
			{
				return new SearchDonationPanel();
			}
			else if (modelName.IEquals("run"))
			{
				return new SearchRunPanel();
			}
			else if (modelName.IEquals("prize"))
			{
				return new SearchPrizePanel();
			}
			else if (modelName.IEquals("prizecategory"))
			{
				return new SearchPrizeCategoryPanel();
			}
			else if (modelName.IEquals("choice"))
			{
				return new SearchChoicePanel();
			}
			else if (modelName.IEquals("challenge"))
			{
				return new SearchChallengePanel();
			}
			else if (modelName.IEquals("choiceoption"))
			{
				return new SearchChoiceOptionPanel();
			}
			else
			{
				throw new Exception("No search panel exists for model " + modelName);
			}
		}
	}
}
