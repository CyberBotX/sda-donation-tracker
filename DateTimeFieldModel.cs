using System;

namespace SDA_DonationTracker
{
	public class DateTimeFieldModel : FieldModel
	{
		public static readonly string DateFormatFromServer = "MM/dd/yyyy HH:mm:ss";
		public static readonly string DateFormatFromPicker = "yyyy-MM-dd HH:mm:ss";
		public static readonly string DateFormatForPicker = "yyyy/MM/dd HH:mm:ss";

		public DateTimeFieldModel(bool readOnly = false)
		{
			this.ReadOnly = readOnly;
		}

		public Type FieldType
		{
			get { return typeof(DateTime); }
		}

		public bool ReadOnly
		{
			get;
			private set;
		}

		public static string SerializeDate(DateTime t)
		{
			return TimeZoneInfo.ConvertTimeToUtc(t, TimeZoneInfo.Local).ToString(DateFormatFromPicker) + "Z";
		}

		public static DateTime ParseDate(string s)
		{
			if (s.EndsWith("Z"))
			{
				s = s.Substring(0, s.Length - 1);
			}

			if (string.IsNullOrEmpty(s))
			{
				return DateTime.Now;
			}

			DateTime result;

			if (DateTime.TryParseExact(s, DateFormatFromServer, null, System.Globalization.DateTimeStyles.None, out result) ||
				DateTime.TryParseExact(s, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out result) ||
				DateTime.TryParseExact(s, DateFormatFromPicker, null, System.Globalization.DateTimeStyles.None, out result))
			{
				return TimeZoneInfo.ConvertTimeFromUtc(result, TimeZoneInfo.Local);
			}
			else
			{
				return DateTime.Now;
			}
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
