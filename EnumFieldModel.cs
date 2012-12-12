using System;

namespace SDA_DonationTracker
{
	public class EnumFieldModel : FieldModel
	{
		public bool ReadOnly
		{
			get;
			private set;
		}

		public Type FieldType
		{
			get;
			private set;
		}

		public EnumFieldModel(Type enumType, bool readOnly = false)
		{
			this.ReadOnly = readOnly;
			this.FieldType = enumType;
		}

		public string Serialize(object t)
		{
			return t.ToString();
		}

		public object Parse(string s)
		{
			return Enum.Parse(FieldType, s);
		}
	}
}
