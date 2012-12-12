using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class DonorTab : NewEntityTab
	{
		private DonorEditPanel DonorPanel;

		public DonorTab(MainForm owner, TrackerContext context)
			: base(owner, context, "donor")
		{
			this.DonorPanel = new DonorEditPanel(this.Owner, this.Context);
			this.SetPanel(this.DonorPanel);
			this.AddForm(this.DonorPanel.GetDonorFormBinding());
			this.AddTable(this.DonorPanel.GetDonationsTableBinding(), this.Model.GetField("donations") as EntitySetModel);
			this.AddTable(this.DonorPanel.GetPrizeTableBinding(), this.Model.GetField("prizes") as EntitySetModel);
		}
	}
}
