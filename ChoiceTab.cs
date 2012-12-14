using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ChoiceTab : EntityTab
	{
		private ChoiceEditPanel Panel;

		public ChoiceTab(MainForm owner, TrackerContext context)
			: base(owner, context, "choice")
		{
			this.Panel = new ChoiceEditPanel(this.Owner, this.Context)
			{
				Dock = DockStyle.Fill,
			};

			this.SetPanel(this.Panel);

			EntityModel donationModel = DonationModels.ChoiceModel;

			this.AddForm(this.Panel.Forms.First());
			this.AddTable(this.Panel.Tables.First(), donationModel.GetField("options") as EntitySetModel);
		}
	}
}
