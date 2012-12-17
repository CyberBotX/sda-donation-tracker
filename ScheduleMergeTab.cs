using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	class ScheduleMergeTab : ExternalProcessTab
	{
		public TrackerContext Context
		{
			get;
			set;
		}

		public ScheduleMergeTab()
		{
			this.ProcessFactory = this.CreateScheduleMerge;
			this.TaskName = "Schedule Merge";
		}

		public ExternalProcessContext CreateScheduleMerge()
		{
			return this.Context.DeferredScheduleMerge();
		}
	}
}
