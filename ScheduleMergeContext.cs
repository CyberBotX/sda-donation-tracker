using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class ScheduleMergeContext : ExternalProcessContext
	{
		public ScheduleMergeContext(TrackerContext context)
			: base(context)
		{
		}

		protected override string ExecuteProcess()
		{
			return this.Context.RunScheduleMerge();
		}
	}
}
