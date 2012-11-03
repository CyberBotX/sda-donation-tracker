using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DateTimePickerBinding : FieldBinding
	{
		public DateTimePicker Picker { get; private set; }
		public Control BoundControl { get { return Picker; } }

		public DateTimePickerBinding(DateTimePicker picker)
		{
			Picker = picker;
		}

		public void LoadField(string data)
		{
			if (Picker.InvokeRequired)
				Picker.Invoke(new SetDateDelegate(InvokeSetDate),DateTimeFieldModel.ParseDate(data));
			else
				DateTimeFieldModel.ParseDate(data);
		}

		public string RetreiveField()
		{
			return DateTimeFieldModel.SerializeDate(Picker.Value);
		}

		private delegate void SetDateDelegate(DateTime t);

		private void InvokeSetDate(DateTime t)
		{
			Picker.Value = t;
		}
	}
}
