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
				return new TextBoxBinding(new TextBox(), readOnly: fieldModel.ReadOnly, nullable: fieldModel.Nullable, longText: strModel.LongText);
			}
			else if (fieldModel is DateTimeFieldModel)
			{
				DateTimePicker picker = new DateTimePicker();

				if (fieldName != null && fieldName.Contains("_gte"))
					picker.Value = picker.MinDate;
				else
					picker.Value = DateTime.Now;

				return new DateTimePickerBinding(picker, readOnly: fieldModel.ReadOnly, nullable: fieldModel.Nullable);
			}
			else if (fieldModel is BooleanFieldModel)
				return new CheckBoxBinding(new CheckBox(), readOnly: fieldModel.ReadOnly);
			else if (fieldModel is EnumFieldModel)
				return new ComboBoxBinding(new ComboBox(), fieldModel.FieldType, readOnly: fieldModel.ReadOnly);
			else if (fieldModel is MoneyFieldModel)
				return new MoneyFieldBinding(new TextBox(), readOnly: fieldModel.ReadOnly, allowNull: fieldModel.Nullable);
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
