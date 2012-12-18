using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public abstract class ExternalProcessContext : ConnectionContext
	{
		public event Action<string> OnComplete;

		protected abstract string ExecuteProcess();

		public ExternalProcessContext(TrackerContext context)
			: base(context)
		{
		}

		protected override void Run()
		{
			string results = this.ExecuteProcess();

			if (OnComplete != null)
			{
				this.OnComplete(results);
			}
		}
	}
}
