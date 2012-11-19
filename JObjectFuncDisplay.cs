using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class JObjectFuncDisplay : JObjectEntityDisplay
	{
		public Func<JObject, string> Converter { get; private set; }
		public JObject Source { get; private set; }
		public String Display { get { return this.Converter(this.Source); } }

		public JObjectFuncDisplay(JObject source, Func<JObject, string> converter)
		{
			this.Source = source;
			this.Converter = converter;
		}
	}
}
