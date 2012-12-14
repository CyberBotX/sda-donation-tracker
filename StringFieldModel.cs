using System;

namespace SDA_DonationTracker
{
	public class StringFieldModel : FieldModel
	{
		public bool LongText { get; private set; }

		public StringFieldModel(bool longText = false, bool readOnly = false, bool nullable = true)
		{
			this.LongText = longText;
			this.ReadOnly = readOnly;
			this.Nullable = nullable;
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

		public bool Nullable
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
