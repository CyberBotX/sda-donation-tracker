using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_DonationTracker
{
	public class BooleanFieldModel : FieldModel
	{
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
