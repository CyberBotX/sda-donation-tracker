using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public static class FieldBindingHelper
	{
		public static FieldBinding CreateBindingField(FieldModel fieldModel)
		{
			if (fieldModel is StringFieldModel)
			{
				return new TextBoxBinding(new TextBox());
			}
			else if (fieldModel is DateTimeFieldModel)
			{
				return new DateTimePickerBinding(
					new DateTimePicker()
					{
						MinDate = DateTime.MinValue,
						MaxDate = DateTime.MaxValue,
					}
				);
			}
			else if (fieldModel is BooleanFieldModel)
			{
				return new CheckBoxBinding(new CheckBox());
			}
			else if (fieldModel is EnumFieldModel)
			{
				return new ComboBoxBinding(new ComboBox(), (fieldModel as EnumFieldModel).FieldType);
			}
			else if (fieldModel is MoneyFieldModel)
			{
				return new MoneyFieldBinding(new TextBox());
			}
			else
			{
				throw new Exception("Unknown model type");
			}
		}
	}
}
