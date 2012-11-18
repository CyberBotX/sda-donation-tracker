using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace SDA_DonationTracker
{
	// TODO:
	// - OnError should maybe also include a way to grab the response data, since
	// it often includes useful info (such as json responses).
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
		public event Action OnError;

		public ConnectionContext(TrackerContext context)
		{
			this.Context = context;
			this.Status = ContextStatus.Idle;
			this.Connection = new Thread(Impl_Run);
		}

		protected abstract void Run();

		public void Begin()
		{
			this.Status = ContextStatus.Pending;
			this.ErrorString = null;
			if (OnBegin != null)
				OnBegin.Invoke();
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
				Run();
				this.Status = ContextStatus.Completed;
			}
			catch (WebException e)
			{
				this.Status = ContextStatus.Error;

				StreamReader rdr = new StreamReader(e.Response.GetResponseStream());
				string str = rdr.ReadToEnd();
				Console.WriteLine(str[0]);
				this.ErrorString = e.Message;
				if (OnError != null)
					OnError.Invoke();
			}
			catch (Exception e)
			{
				this.Status = ContextStatus.Error;
				this.ErrorString = e.Message;
				if (OnError != null)
					OnError.Invoke();
			}
		}
	}
}
