using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public static class InvokeHelper
	{
		private delegate void ActionDelegate(Action toRun);

		public static void InvokeEx(this Control self, Action toRun)
		{
			if (self.InvokeRequired)
				self.Invoke(new ActionDelegate(RunAnAction), toRun);
			else
				toRun();
		}

		private static void RunAnAction(Action toRun)
		{
			toRun();
		}
	}
}
