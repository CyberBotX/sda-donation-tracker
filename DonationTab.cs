using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DonationTab : EntityTab
	{
		private DonationEditPanel Panel;

		public DonationTab(MainForm owner, TrackerContext context)
			: base(owner, context, "donation")
		{
			this.Panel = new DonationEditPanel(this.Owner, this.Context)
			{
				Dock = DockStyle.Fill,
			};

			this.SetPanel(this.Panel);

			EntityModel donationModel = DonationModels.DonationModel;

			this.AddForm(this.Panel.Forms.First());
			this.AddTable(this.Panel.Tables.First(), donationModel.GetField("bids") as EntitySetModel);
		}
	}
}