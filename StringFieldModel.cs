using System;

namespace SDA_DonationTracker
{
	public class StringFieldModel : FieldModel
	{
		public bool LongText { get; private set; }

		public StringFieldModel(bool longText = false, bool readOnly = false)
		{
			this.LongText = longText;
			this.ReadOnly = readOnly;
		}

		public Type FieldType
		{
			get { return typeof(string); }
		}

		public bool ReadOnly
		{
			get;
			private set;
		}

		public string Serialize(object t)
		{
			return t.ToString();
		}

		public object Parse(string s)
		{
			return s;
		}
	}
}
