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
	public partial class ChipinMergeTab : ExternalProcessTab
	{
		public TrackerContext Context
		{
			get;
			set;
		}

		public ChipinMergeTab()
		{
			InitializeComponent();

			this.ProcessFactory = this.CreateChipinMerge;
		}

		public ExternalProcessContext CreateChipinMerge()
		{
			return this.Context.DeferredChipinMerge();
		}
	}
}
