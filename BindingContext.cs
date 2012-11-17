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
				control.InvokeEx(() => control.Enabled = false);
			});
		}

		public virtual void EnableControls()
		{
			this.AssociatedControls.ForEach(control =>
			{
				control.InvokeEx(() => control.Enabled = true);
			});
		}
	}
}
