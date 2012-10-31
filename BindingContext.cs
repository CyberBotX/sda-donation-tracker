using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
    public class BindingContext
    {
        private List<Control> AssociatedControls = new List<Control>();

        public void AddAssociatedControl(Control toAdd)
        {
            AssociatedControls.Add(toAdd);
        }

        public virtual void DisableControls()
        {
            foreach (var control in AssociatedControls)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new ControlCallback(DisableControl), control);
                }
                else
                {
                    DisableControl(control);
                }
            }
        }

        public virtual void EnableControls()
        {
            foreach (var control in AssociatedControls)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new ControlCallback(EnableControl), control);
                }
                else
                {
                    EnableControl(control);
                }
            }
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
