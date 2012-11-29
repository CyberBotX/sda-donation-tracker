using System;

namespace SDA_DonationTracker
{
	public class DateTimeFieldModel : FieldModel
	{
		public static readonly string DateFormatFromServer = "MM/dd/yyyy HH:mm:ss";
		public static readonly string DateFormatFromPicker = "yyyy-MM-dd HH:mm:ss";
		public static readonly string DateFormatForPicker = "yyyy/MM/dd HH:mm:ss";

		public Type FieldType
		{
			get { return typeof(DateTime); }
		}

		public static string SerializeDate(DateTime t)
		{
			return TimeZoneInfo.ConvertTimeToUtc(t, TimeZoneInfo.Local).ToString(DateFormatFromPicker);
		}

		public static DateTime ParseDate(string s)
		{
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.ParseExact(s, DateFormatFromServer, null), TimeZoneInfo.Local);
		}

		public string Serialize(object t)
		{
			return DateTimeFieldModel.SerializeDate((DateTime)t);
		}

		public object Parse(string s)
		{
			return DateTimeFieldModel.ParseDate(s);
		}
	}
}
