using System;

namespace SDA_DonationTracker
{
	public interface FieldModel
	{
		Type FieldType
		{
			get;
		}

		string Serialize(object t);
		object Parse(string s);
	}
}
