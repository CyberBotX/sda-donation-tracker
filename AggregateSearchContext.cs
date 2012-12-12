using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace SDA_DonationTracker
{
	public class AggregateSearchContext
	{
		private JoinWaiter waiter;
		private Mutex AccessControl;
		private JArray Data;
		private SearchContext[] Contexts;
		private List<TrackerError> Errors;

		public AggregateSearchContext(params SearchContext[] contexts)
			: this(contexts as IEnumerable<SearchContext>)
		{
		}

		public AggregateSearchContext(IEnumerable<SearchContext> contexts)
		{
			this.Contexts = contexts.ToArray();
			this.Data = new JArray();
			this.waiter = new JoinWaiter(this.OnComplete);
			this.AccessControl = new Mutex();
			this.Errors = new List<TrackerError>();
		}

		public void Begin()
		{
			foreach (var context in this.Contexts)
			{
				waiter.AddProcess();
				context.OnComplete += this.AddContents;
				context.OnError += this.Failure;
				context.Begin();
			}

			waiter.Start();
		}

		private void Failure(TrackerErrorType error, string message)
		{
			try
			{
				this.AccessControl.WaitOne();
				this.Errors.Add(new TrackerError(error, message));
			}
			finally
			{
				this.AccessControl.ReleaseMutex();
			}

			waiter.ProcessComplete();
		}

		private void AddContents(JArray results)
		{
			try
			{
				this.AccessControl.WaitOne();

				foreach (JObject obj in results)
					this.Data.Add(obj);
			}
			finally
			{
				this.AccessControl.ReleaseMutex();
			}

			waiter.ProcessComplete();
		}

		private void OnComplete()
		{
			if (this.Errors.Count == 0)
			{
				if (this.Completed != null)
					this.Completed(this.Data);
			}
			else
			{
				if (this.Error != null)
					this.Error(this.Errors);
			}
		}

		public event Action<JArray> Completed;
		public event Action<IEnumerable<TrackerError>> Error;
	}
}
