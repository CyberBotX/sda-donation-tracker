using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SDA_DonationTracker
{
	public class JoinWaiter
	{
		public bool Started { get; private set; }

		public JoinWaiter(Action onCompletion)
		{
			this.ProcessesRemainingMutex = new Mutex();
			this.OnCompletion = onCompletion;
		}

		private int ProcessesRemaining;
		private Mutex ProcessesRemainingMutex;
		private Action OnCompletion;

		public void AddProcess()
		{
			this.ProcessesRemainingMutex.WaitOne();
			++this.ProcessesRemaining;
			this.ProcessesRemainingMutex.ReleaseMutex();
		}

		public void Start()
		{
			this.Started = true;
			this.CheckForCompletion();
		}

		public void ProcessComplete()
		{
			this.ProcessesRemainingMutex.WaitOne();
			--this.ProcessesRemaining;
			this.ProcessesRemainingMutex.ReleaseMutex();

			this.CheckForCompletion();
		}

		private void CheckForCompletion()
		{
			if (this.Started && this.ProcessesRemaining <= 0)
			{
				this.OnCompletion();
				this.Started = false;
			}
		}
	}
}
