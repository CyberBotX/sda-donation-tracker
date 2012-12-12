using System;

namespace SDA_DonationTracker
{
	public class MoneyFieldModel : FieldModel
	{
		public MoneyFieldModel(bool readOnly = false)
		{
			this.ReadOnly = readOnly;
		}

		public bool ReadOnly
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
