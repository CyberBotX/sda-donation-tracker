using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class SearchContext : ConnectionContext
	{
		public string Model
		{
			get;
			private set;
		}
		public IEnumerable<KeyValuePair<string, string>> SearchParams
		{
			get;
			private set;
		}
		public JArray Result
		{
			get;
			private set;
		}
		public event Action<JArray> OnComplete;

		public SearchContext(TrackerContext context, string model, IEnumerable<KeyValuePair<string, string>> searchParams)
			: base(context)
		{
			this.Model = model;
			this.SearchParams = searchParams;
			this.Result = null;

			this.OnBegin += () =>
				{
					this.Result = null;
				};
		}

		protected override void Run()
		{
			this.Result = this.Context.RunSearch(this.Model, this.SearchParams);

			if (this.OnComplete != null)
					this.OnComplete.Invoke(this.Result);
		}
	}
}
