using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
    public class JTokenListElement
    {
        public JToken Source { get; private set; }
        private string[] Fields;

        public JTokenListElement(JToken source, params string[] fields)
        {
            Source = source;
            Fields = fields.ToArray();
        }

        public string Display { get { return this.ToString(); } }

        public override string ToString()
        {
            return Fields.Length > 0 ? Fields.Select(s => Source.Value<JToken>("fields").Value<string>(s)).JoinSeperated(":") : Source.ToString();
        }
    }
}
