using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	interface JObjectEntityDisplay
	{
		string Display { get; }
		JObject Source { get; }
	}
}
