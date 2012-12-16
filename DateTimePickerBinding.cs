using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public class DateTimePickerBinding : FieldBinding
	{
		public DateTimePicker Picker { get; private set; }
		public Control BoundControl { get { return this.Picker; } }
		public bool Nullable { get; private set; }

		public DateTimePickerBinding(DateTimePicker picker, bool readOnly = false, bool nullable = true)
		{
			this.Nullable = nullable;
			this.Picker = picker;
			this.Picker.CustomFormat = DateTimeFieldModel.DateFormatFromPicker;
			this.Picker.Format = DateTimePickerFormat.Custom;
			this.Picker.ShowUpDown = true;
			this.Picker.ShowCheckBox = this.Nullable;
			this.Picker.Checked = !this.Nullable;
			this.Picker.Enabled = !readOnly;

			this.Picker.InvokeEx(() =>
				{
					this.Picker.CustomFormat = DateTimeFieldModel.DateFormatForPicker;
					this.Picker.Format = DateTimePickerFormat.Custom;
				});
		}

		public void LoadField(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				this.Picker.InvokeEx(() => 
				{
					this.Picker.Value = DateTime.Now;
					this.Picker.Checked = false;
				});
			}
			else
			{
				this.Picker.InvokeEx(() => this.Picker.Value = DateTimeFieldModel.ParseDate(data));
			}
		}

		public string RetreiveField()
		{
			if (!this.Nullable || this.Picker.Checked)
			{
				DateTime t = this.Picker.Value;
				return DateTimeFieldModel.SerializeDate(t);
			}
			else
				return null;
		}
	}
}
