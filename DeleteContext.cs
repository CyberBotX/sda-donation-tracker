using System;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class DeleteContext : ConnectionContext
	{
		public int Id { get; private set; }
		public string Model { get; private set; }
		public JObject Result { get; private set; }

		public DeleteContext(TrackerContext context, string model, int id)
			: base(context)
		{
			this.Id = id;
			this.Model = model;

			this.OnBegin += () =>
			{
				this.Result = null;
			};
		}

		public event Action<JObject> OnComplete;

		protected override void Run()
		{
			this.Result = this.Context.RunDelete(this.Model, this.Id);

			if (this.OnComplete != null)
				this.OnComplete.Invoke(this.Result);
		}
	}
}
