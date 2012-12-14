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

		// Technically, booleans could be nullable, but I don't have a convenient way to represent
		// that in the UI at the moment
		public bool Nullable
		{
			get
			{
				return false;
			}
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
