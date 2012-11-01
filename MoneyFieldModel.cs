using System;

namespace SDA_DonationTracker
{
	public class MoneyFieldModel : FieldModel
	{
		public Type FieldType
		{
			get
			{
				return typeof(decimal);
			}
		}
	}
}
