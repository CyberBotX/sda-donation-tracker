using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SDA_DonationTracker
{
	public class TrackerContext
	{
		private static readonly string[] EventModels = { "choice", "challenge", "choicebid", "challengebid", "donation", "prize", "run" };

		private Cookie ClientCookie = null;
		public bool SessionSet
		{
			get
			{
				return this.ClientCookie != null;
			}
		}
		public Uri Domain
		{
			get;
			private set;
		}
		public string SessionId
		{
			get;
			private set;
		}
		public int EventId
		{
			get;
			set;
		}

		public TrackerContext()
		{
			this.EventId = 0;
		}

		public void SetSessionId(string sessionId, string domain)
		{
			this.ClearSessionId();

			this.Domain = new Uri(string.Format("http://{0}/", domain));
			this.SessionId = sessionId;

			this.ClientCookie = new Cookie()
			{
				Name = "sessionid",
				Value = this.SessionId,
				Path = "/",
				Domain = domain,
				HttpOnly = true
			};

			JArray results = this.RunSearch("event", Util.CreateSearchParams());

			if (results.Count > 0)
				this.EventId = results.Select(x => x.Value<int>("id")).Max();
		}

		public void ClearSessionId()
		{
			this.ClientCookie = null;
		}

		public bool IsEventModel(string model)
		{
			foreach (string v in TrackerContext.EventModels)
				if (string.Equals(v, model, StringComparison.OrdinalIgnoreCase))
					return true;

			return false;
		}

		private Uri CreateSearchUri(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			return new Uri(Domain, string.Format("tracker/search/?type={0}&{1}", model,
				string.Join("&", searchParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Key.ToLower() + "=" + x.Value))));
		}

		private WebClientEx CreateClient()
		{
			WebClientEx client = new WebClientEx();
			client.Cookies.Add(this.ClientCookie);
			return client;
		}

		public JArray RunSearch(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			if (this.IsEventModel(model))
				searchParams.Concat1(new KeyValuePair<string, string>("event", this.EventId.ToString()));

			if (!this.SessionSet)
				throw new Exception("Error, session is not set.");

			Uri u = this.CreateSearchUri(model, searchParams);

			WebClientEx client = this.CreateClient();

			string data = client.DownloadString(u);

			return JArray.Parse(data);
		}

		public SearchContext DeferredSearch(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			if (!this.SessionSet)
				return null;

			return new SearchContext(this, model, searchParams);
		}
	}
}
