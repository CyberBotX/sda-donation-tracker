﻿using System;

namespace SDA_DonationTracker
{
	public class StringFieldModel : FieldModel
	{
		public Type FieldType
		{
			get { return typeof(string); }
		}

		public string Serialize(object t)
		{
			return t.ToString();
		}

		public object Parse(string s)
		{
			return s;
		}
	}
}
