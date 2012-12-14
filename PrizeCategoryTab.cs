using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class PrizeCategoryTab : EntityTab
	{
		private EntityFormPanelConstruct FormPanel;

		public PrizeCategoryTab(MainForm owner, TrackerContext context)
			: base(owner, context, "prizecategory")
		{
			this.FormPanel = new EntityFormPanelConstruct("prizecategory",
				new string[] { "name" },
				this.Context,
				this.Owner)
				{
					Dock = DockStyle.Fill,
				};

			this.SetPanel(this.FormPanel);
			this.AddForm(this.FormPanel.Binding);
		}
	}
}
