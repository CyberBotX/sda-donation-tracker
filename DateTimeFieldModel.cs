using System;

namespace SDA_DonationTracker
{
	public class DateTimeFieldModel : FieldModel
	{
		public Type FieldType
		{
			get
			{
				return typeof(DateTime);
			}
		}
	}
}
