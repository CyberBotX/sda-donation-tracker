using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public partial class ExternalProcessTab : UserControl, ITab
	{
		public Func<ExternalProcessContext> ProcessFactory
		{
			get;
			set;
		}

		public String TaskName
		{
			get;
			set;
		}

		private ExternalProcessContext Process;

		public ExternalProcessTab()
		{
			InitializeComponent();
			this.EndProcess();
		}

		public void StartProcess()
		{
			this.ControlButton.Text = "Abort";
			this.ControlButton.Click -= this.StartProcessEvent;
			this.ControlButton.Click += this.AbortProcessEvent;
			this.StatusLabel.Text = "Running...";
			this.Process = this.ProcessFactory();
			this.Process.Completed += this.OnComplete;
			this.Process.OnError += this.OnError;
			this.Process.Begin();

			this.ProgressBar.Value = 100;
		}

		private void StartProcessEvent(object o, EventArgs e)
		{
			this.StartProcess();
		}

		private void EndProcess()
		{
			if (this.Process != null)
			{
				this.Process.Completed -= this.OnComplete;
				this.Process.OnError -= this.OnError;
			}

			this.ControlButton.InvokeEx(() =>
			{
				this.ControlButton.Click -= this.AbortProcessEvent;
				this.ControlButton.Click += this.StartProcessEvent;
				this.ControlButton.Text = "Begin";
				this.ProgressBar.Value = 0;
			});
		}

		private void AbortProcessEvent(object o, EventArgs e)
		{
			this.AbortProcess();
		}

		public void AbortProcess()
		{
			if (this.Process != null)
			{
				this.Process.Abort();
			}

			this.EndProcess();
		}

		private void OnComplete(string results)
		{
			this.ResultsText.InvokeEx(() => this.ResultsText.Text = results);
			this.StatusLabel.InvokeEx(() => this.StatusLabel.Text = "Completed");

			this.EndProcess();
		}

		private void OnError(TrackerErrorType error, string message)
		{
			this.ResultsText.InvokeEx(() => this.ResultsText.Text = message);
			this.StatusLabel.InvokeEx(() => this.StatusLabel.Text = "Error");

			this.EndProcess();
		}

		public bool ConfirmClose()
		{
			if (Process != null && Process.Busy)
			{
				return false;
			}
			else
			{
				this.EndProcess();
				return true;
			}
		}
	}
}
