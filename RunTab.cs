using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class RunTab : EntityTab
	{
		private RunEditPanel RunPanel;

		public RunTab(MainForm owner, TrackerContext context)
			: base(owner, context, "run")
		{
			this.RunPanel = new RunEditPanel(context, owner)
			{
				Dock = DockStyle.Fill
			};

			this.SetPanel(this.RunPanel);

			this.AddForm(this.RunPanel.RunForm.Binding);
			this.AddTable(this.RunPanel.BidTable.Binding, this.Model.GetField("bids") as EntitySetModel);
		}

		protected override void Dispose(bool disposing)
		{
			this.RunPanel.Dispose();
			base.Dispose(disposing);
		}
	}
}
