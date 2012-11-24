using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DateTimePickerBinding : FieldBinding
	{
		public DateTimePicker Picker { get; private set; }
		public Control BoundControl { get { return this.Picker; } }

		public DateTimePickerBinding(DateTimePicker picker)
		{
			this.Picker = picker;
		}

		public void LoadField(string data)
		{
			this.Picker.InvokeEx(() => this.Picker.Value = DateTimeFieldModel.ParseDate(data));
		}

		public string RetreiveField()
		{
			if (this.Picker.Checked)
			{
				DateTime t = this.Picker.Value;
				return string.Format("{0}-{1}-{2} {3}:{4}:{5}", t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second);
			}
			else
				return "";
		}
	}
}
