using System;

namespace SDA_DonationTracker
{
	public class EnumFieldModel : FieldModel
	{
		public Type FieldType
		{
			get;
			private set;
		}

		public EnumFieldModel(Type enumType)
		{
			this.FieldType = enumType;
		}
	}
}
