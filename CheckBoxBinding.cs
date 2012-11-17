using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class CheckBoxBinding : FieldBinding
	{
		public CheckBox CheckBox { get; private set; }
		public Control BoundControl { get { return CheckBox; } }

		public CheckBoxBinding(CheckBox checkBox)
		{
			CheckBox = checkBox;
		}

		public void LoadField(string data)
		{
			this.CheckBox.InvokeEx(() => this.CheckBox.Checked = bool.Parse(data));
		}

		public string RetreiveField()
		{
			return CheckBox.Checked.ToString();
		}
	}
}
