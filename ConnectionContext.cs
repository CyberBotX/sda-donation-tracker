using System;
using System.IO;
using System.Net;
using System.Threading;

namespace SDA_DonationTracker
{
	/**
	 * Base class for data connection requests
	 * Contains the basic machinery to allow for asynchronous data layer execution
	 */
	public abstract class ConnectionContext
	{
		public TrackerContext Context
		{
			get;
			private set;
		}
		private Thread Connection;
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
		public string ErrorString
		{
			get;
			private set;
		}

		public event Action OnBegin;
		public event Action<TrackerErrorType, string> OnError;

		public ConnectionContext(TrackerContext context)
		{
			this.Context = context;
			this.Status = ContextStatus.Idle;
			this.Connection = new Thread(this.Impl_Run);
		}

		protected abstract void Run();

		public void Begin()
		{
			this.Status = ContextStatus.Pending;
			this.ErrorString = null;
			if (this.OnBegin != null)
				this.OnBegin.Invoke();
			this.Connection.Start();
		}

		public void Abort()
		{
			if (this.Busy)
				this.Connection.Abort();
		}

		private void Impl_Run()
		{
			try
			{
				this.Status = ContextStatus.Started;
				this.Run();
				this.Status = ContextStatus.Completed;
			}
			catch (TrackerError e)
			{
				this.Status = ContextStatus.Error;
				this.ErrorString = e.Message;
				if (this.OnError != null)
					this.OnError.Invoke(e.ErrorType, e.Message);
			}
			catch (Exception e)
			{
				this.Status = ContextStatus.Error;
				this.ErrorString = e.Message;
				if (this.OnError != null)
					this.OnError.Invoke(TrackerErrorType.Unknown, this.ErrorString);
			}
		}
	}
}
