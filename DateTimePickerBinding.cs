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
			this.Picker.InvokeEx(() =>
				{
					this.Picker.CustomFormat = DateTimeFieldModel.DateFormatForPicker;
					this.Picker.Format = DateTimePickerFormat.Custom;
				});
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
				return DateTimeFieldModel.SerializeDate(t);
			}
			else
				return "";
		}
	}
}
