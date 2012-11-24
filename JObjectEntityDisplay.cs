using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	interface JObjectEntityDisplay
	{
		string Display { get; }
		JObject Source { get; }
	}
}
