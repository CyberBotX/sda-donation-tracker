using System;

namespace SDA_DonationTracker
{
	public class DateTimeFieldModel : FieldModel
	{
		public static readonly string DateFormat = "MM/dd/yyyy HH:mm:ss";

		public Type FieldType
		{
			get { return typeof(DateTime); }
		}

		public static string SerializeDate(DateTime t)
		{
			return t.ToString(DateFormat);
		}

		public static DateTime ParseDate(string s)
		{
			return DateTime.ParseExact(s, DateFormat, null);
		}

		public string Serialize(object t)
		{
			return DateTimeFieldModel.SerializeDate((DateTime)t);
			//return string.Format("{0}-{1}-{2}T{3}:{4}:{5}", t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second);
		}

		public object Parse(string s)
		{
			return DateTimeFieldModel.ParseDate(s);
		}
	}
}
