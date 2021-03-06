﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class ChipinMergeContext : ExternalProcessContext
	{
		public ChipinMergeContext(TrackerContext context)
			: base(context)
		{
		}

		protected override string ExecuteProcess()
		{
			return this.Context.RunChipinMerge();
		}
	}
}
