using System;

namespace SDA_DonationTracker
{
	public interface FieldModel
	{
		Type FieldType
		{
			get;
		}

		bool ReadOnly
		{
			get;
		}

		bool Nullable
		{
			get;
		}

		string Serialize(object t);
		object Parse(string s);
	}
}
