using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class SearchContext
	{
		public TrackerContext Context
		{
			get;
			private set;
		}
		private Thread Connection;
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
		public bool Completed
		{
			get
			{
				return this.Status == ContextStatus.Completed;
			}
		}
		public bool Error
		{
			get
			{
				return this.Status == ContextStatus.Error;
			}
		}
		public bool Busy
		{
			get
			{
				return this.Status == ContextStatus.Pending || this.Status == ContextStatus.Started;
			}
		}
		public ContextStatus Status
		{
			get;
			private set;
		}
		public string ErrorString;
		public event Action<JArray> OnComplete;

		public SearchContext(TrackerContext context, string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			this.Context = context;
			this.Model = model;
			this.SearchParams = searchParams;
			this.Result = null;
			this.ErrorString = null;
			this.Status = ContextStatus.Idle;
			this.Connection = new Thread(this.Impl_RunSearch);
		}

		public void Begin()
		{
			this.Status = ContextStatus.Pending;
			this.Result = null;
			this.ErrorString = null;
			this.Connection.Start();
		}

		public void Abort()
		{
			if (this.Busy)
				this.Connection.Abort();
		}

		private void Impl_RunSearch()
		{
			try
			{
				this.Status = ContextStatus.Started;
				this.Result = this.Context.RunSearch(this.Model, this.SearchParams);
				this.Status = ContextStatus.Completed;

				if (this.OnComplete != null)
					this.OnComplete.Invoke(this.Result);
			}
			catch (Exception e)
			{
				this.ErrorString = e.Message;
			}
		}
	}
}
