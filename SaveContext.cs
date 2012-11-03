using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class SaveContext : ConnectionContext
	{
		public string Model
		{
			get;
			private set;
		}
		private IEnumerable<KeyValuePair<string, string>> CreateParams;
		private JObject Result;
		public event Action<JObject> OnComplete;

		public SaveContext(TrackerContext context, string model, IEnumerable<KeyValuePair<string, string>> createParams)
			: base(context)
		{
			this.Model = model;
			this.CreateParams = createParams;
			this.Result = null;

			this.OnBegin += () =>
			{
				this.Result = null;
			};
		}

		protected override void Run()
		{
			this.Result = this.Context.RunSave(this.Model, this.CreateParams);

			if (this.OnComplete != null)
				this.OnComplete.Invoke(this.Result);
		}
	}
}
