using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class SearchRunPanel : SearchPanel
	{
		public SearchRunPanel()
			: base(
				DonationModels.RunModel,
				new string[]
				{
					"name",
					"runner",
					"description",
				})
		{
			InitializeComponent();
		}
	}
}
