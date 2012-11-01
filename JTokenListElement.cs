using System.Linq;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class JTokenListElement
	{
		public JToken Source
		{
			get;
			private set;
		}
		private string[] Fields;

		public JTokenListElement(JToken source, params string[] fields)
		{
			this.Source = source;
			this.Fields = fields;
		}

		public string Display
		{
			get
			{
				return this.ToString();
			}
		}

		public override string ToString()
		{
			return this.Fields.Length > 0 ? string.Join(":", this.Fields.Select(s => this.Source.Value<JToken>("fields").Value<string>(s))) : this.Source.ToString();
		}
	}
}
