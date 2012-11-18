using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public static class JObjectEntityHelpers
	{
		public static void SetField(this JObject self, string name, string value)
		{
			JObject fields = self.Value<JObject>("fields");
			fields.SetField(name, value);
		}
	}
}
