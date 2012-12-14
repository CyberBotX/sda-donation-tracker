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

		// Technically, these could be nullable, but I don't have a way to represent it in the UI easily
		// (furthermore, the preferred way to handle this is to just use another enum member)
		public bool Nullable
		{
			get
			{
				return false;
			}
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
