using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class ChallengeTab : EntityTab
	{
		private ChallengeEditPanel Panel;

		public ChallengeTab(MainForm owner, TrackerContext context)
			: base(owner, context, "challenge")
		{
			this.Panel = new ChallengeEditPanel(this.Owner, this.Context)
			{
				Dock = DockStyle.Fill,
			};

			this.SetPanel(this.Panel);

			EntityModel donationModel = DonationModels.ChoiceModel;

			this.AddForm(this.Panel.Forms.First());
		}
	}
}
