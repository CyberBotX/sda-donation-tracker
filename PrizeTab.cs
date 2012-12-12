using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class PrizeTab : NewEntityTab
	{
		private EntityFormPanelConstruct PrizeForm;

		public PrizeTab(MainForm owner, TrackerContext context)
			: base(owner, context, "prize")
		{
			this.PrizeForm = new EntityFormPanelConstruct(this.ModelName,
				new string[]
				{
					"name", 
					"image",
					"category",
					"minimumbid",
					"maximumbid",
					"sumdonations",
					"randomdraw",
					"provided",
					"description",
					"winner",
					"startrun",
					"endrun",
					"starttime",
					"endtime",
					"pin",
				}, this.Context, this.Owner);

			this.SetPanel(this.PrizeForm);
			this.AddForm(this.PrizeForm.Binding);
		}
	}
}
