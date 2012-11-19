using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public static class FieldBindingHelper
	{
		public static FieldBinding CreateBindingField(FieldModel fieldModel, string fieldName = null, TrackerContext context = null, MainForm owner = null)
		{
			if (fieldModel is StringFieldModel)
			{
				return new TextBoxBinding(new TextBox());
			}
			else if (fieldModel is DateTimeFieldModel)
			{
				DateTimePicker picker = new DateTimePicker()
				{
					CustomFormat = "yyyy/MM/dd HH:mm:ss",
					Format = DateTimePickerFormat.Custom,
					ShowUpDown = true,
				};

				if (fieldName != null && fieldName.Contains("_gte"))
				{
					picker.Value = picker.MinDate;
				}
				else
				{
					picker.Value = DateTime.Now;
				}

				return new DateTimePickerBinding(picker);
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
			else if (fieldModel is EntityFieldModel)
			{
				EntitySelector selector = new EntitySelector()
				{
					Owner = owner,
				};
				if (context != null)
				{
					selector.Initialize(context, (fieldModel as EntityFieldModel).ModelName);
				}
				else
				{
					throw new Exception("Error, trying to create entity selector without context");
				}
				return new EntitySelectorBinding(selector);
			}
			else
			{
				throw new Exception("Unknown model type");
			}
		}
	}
}
