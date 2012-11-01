using System.Collections.Generic;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class BindingContext
	{
		private List<Control> AssociatedControls = new List<Control>();

		public void AddAssociatedControl(Control toAdd)
		{
			this.AssociatedControls.Add(toAdd);
		}

		public virtual void DisableControls()
		{
			this.AssociatedControls.ForEach(control =>
			{
				if (control.InvokeRequired)
					control.Invoke(new ControlCallback(this.DisableControl), control);
				else
					this.DisableControl(control);
			});
		}

		public virtual void EnableControls()
		{
			this.AssociatedControls.ForEach(control =>
			{
				if (control.InvokeRequired)
					control.Invoke(new ControlCallback(this.EnableControl), control);
				else
					this.EnableControl(control);
			});
		}

		protected delegate void ControlCallback(Control c);

		protected void DisableControl(Control c)
		{
			c.Enabled = false;
		}

		protected void EnableControl(Control c)
		{
			c.Enabled = true;
		}
	}
}
