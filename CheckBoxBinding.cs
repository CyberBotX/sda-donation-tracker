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
			if (CheckBox.InvokeRequired)
				CheckBox.Invoke(new SetCheckboxDelegate(SetCheckboxValue), data);
			else
				SetCheckboxValue(data);

		}

		public string RetreiveField()
		{
			return CheckBox.Checked.ToString();
		}

		private delegate void SetCheckboxDelegate(string data);

		private void SetCheckboxValue(string data)
		{
			CheckBox.Checked = bool.Parse(data);
		}
	}
}
