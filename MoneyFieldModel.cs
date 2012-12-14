using System;

namespace SDA_DonationTracker
{
	public class MoneyFieldModel : FieldModel
	{
		public MoneyFieldModel(bool readOnly = false, bool nullable = true)
		{
			this.ReadOnly = readOnly;
			this.Nullable = nullable;
		}

		public bool ReadOnly
		{
			get;
			private set;
		}

		public bool Nullable
		{
			get;
			private set;
		}

		public Type FieldType
		{
			get
			{
				return typeof(decimal);
			}
		}

		public string Serialize(object t)
		{
			return ((decimal)t).ToString();
		}

		public object Parse(string s)
		{
			return decimal.Parse(s);
		}
	}
}
