using System;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	public static class FieldBindingHelper
	{
		public static FieldBinding CreateBindingField(FieldModel fieldModel, string fieldName = null, TrackerContext context = null, MainForm owner = null)
		{
			if (fieldModel is StringFieldModel)
			{
				StringFieldModel strModel = fieldModel as StringFieldModel;
				return new TextBoxBinding(new TextBox()
					{
						Multiline = strModel.LongText,
						ReadOnly = strModel.ReadOnly,
					});
			}
			else if (fieldModel is DateTimeFieldModel)
			{
				DateTimePicker picker = new DateTimePicker()
				{
					CustomFormat = DateTimeFieldModel.DateFormatFromPicker,
					Format = DateTimePickerFormat.Custom,
					ShowUpDown = true,
					ShowCheckBox = true,
					Checked = false,
					Enabled = !fieldModel.ReadOnly,
				};

				if (fieldName != null && fieldName.Contains("_gte"))
					picker.Value = picker.MinDate;
				else
					picker.Value = DateTime.Now;

				return new DateTimePickerBinding(picker);
			}
			else if (fieldModel is BooleanFieldModel)
				return new CheckBoxBinding(new CheckBox() { Enabled = !fieldModel.ReadOnly });
			else if (fieldModel is EnumFieldModel)
				return new ComboBoxBinding(new ComboBox() { Enabled = !fieldModel.ReadOnly }, (fieldModel as EnumFieldModel).FieldType);
			else if (fieldModel is MoneyFieldModel)
			{
				TextBox box = new TextBox() { ReadOnly = fieldModel.ReadOnly };

				box.GotFocus += (o, e) =>
				{
					Console.WriteLine("Money box focus");
				};

				box.LostFocus += (o, e) =>
				{
					Console.WriteLine("Money box lost focus");
				};

				box.Click += (o, e) =>
				{
					Console.WriteLine("Money box click");
				};

				return new MoneyFieldBinding(box);
			}
			else if (fieldModel is EntityFieldModel)
			{
				EntityFieldModel entityField = fieldModel as EntityFieldModel;
				EntitySelector selector = new EntitySelector()
				{
					Owner = owner,
					UseSelectionCache = DonationModels.IsCachingEntity(entityField.ModelName),
				};
				if (context != null)
					selector.Initialize(context, entityField.ModelName);
				else
					throw new Exception("Error, trying to create entity selector without context");
				return new EntitySelectorBinding(selector);
			}
			else
				throw new Exception("Unknown model type");
		}
	}
}
