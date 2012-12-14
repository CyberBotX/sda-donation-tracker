using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	class EntityTabHelpers
	{
		private static readonly string[] NavigableEntities = new string[]
		{
			"donor",
			"donation",
			"run",
			"choice",
			"challenge",
			"prize",
			"bid",
			"prizecategory",
		};

		public static bool HasEditPanel(string modelName)
		{
			return NavigableEntities.Contains(modelName);
		}

		// eventually this should probably be replaced with a dictionary with a delegate function lookup
		// or something else cleaner
		public static EntityTab CreateEntityTab(string modelName, MainForm owner, TrackerContext context)
		{
			if (modelName.IEquals("donor"))
				return new DonorTab(owner, context);
			else if (modelName.IEquals("donation"))
				return new DonationTab(owner, context);
			else if (modelName.IEquals("prize"))
				return new PrizeTab(owner, context);
			else if (modelName.IEquals("prizecategory"))
				return new PrizeCategoryTab(owner, context);
			else if (modelName.IEquals("run"))
				return new RunTab(owner, context);
			else if (modelName.IEquals("choice"))
				return new ChoiceTab(owner, context);
			else if (modelName.IEquals("challenge"))
				return new ChallengeTab(owner, context);
			else
				throw new Exception("Error, navigation to " + modelName + " not supported");
		}
	}
}
