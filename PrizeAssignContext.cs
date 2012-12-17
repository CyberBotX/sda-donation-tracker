using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class PrizeAssignContext : ConnectionContext
	{
		public int PrizeId
		{
			get;
			private set;
		}

		public string Result
		{
			get;
			private set;
		}

		public event Action<string> Completed;

		public PrizeAssignContext(TrackerContext context, int prizeId)
			: base(context)
		{
			this.PrizeId = prizeId;
		}

		protected override void Run()
		{
			this.Result = this.Context.DrawPrize(this.PrizeId);

			if (this.Completed != null)
				this.Completed(this.Result);
		}
	}
}
