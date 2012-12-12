using System;

namespace SDA_DonationTracker
{
	public class BooleanFieldModel : FieldModel
	{
		public BooleanFieldModel(bool readOnly = false)
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
			get { return typeof(bool); }
		}

		public string Serialize(object t)
		{
			return t.ToString();
		}

		public object Parse(string s)
		{
			return bool.Parse(s);
		}
	}
}
