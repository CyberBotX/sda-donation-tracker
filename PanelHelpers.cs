using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public static class PanelHelpers
	{
		public static void DeinitializeEntitySelectors(Control panel)
		{
			if (panel is EntitySelector)
			{
				(panel as EntitySelector).Deinitialize();
			}

			foreach (Control c in panel.Controls)
			{
				DeinitializeEntitySelectors(c);
			}
		}
	}
}
