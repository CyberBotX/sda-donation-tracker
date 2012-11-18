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
		public string EventName { get; set; }

		public TrackerContext()
		{
			this.EventId = 0;
			this.EventName = null;
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
				this.EventId = results.Select(x => x.Value<int>("pk")).Max();
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
			return new Uri(Domain, "tracker/search/" + StringParams(model, searchParams));
		}

		private string StringParams(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			return string.Format("type={0}&{1}", model, string.Join("&", searchParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => (x.Key.Equals("domainId") ? x.Key : x.Key.ToLower()) + "=" + Uri.EscapeDataString(x.Value))));
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
				searchParams = searchParams.Concat1(new KeyValuePair<string, string>("event", this.EventName));

			if (!this.SessionSet)
				throw new Exception("Error, session is not set.");

			Uri u = new Uri(Domain, "tracker/search/"); //this.CreateSearchUri(model, searchParams);

			WebClientEx client = this.CreateClient();

			string paramsString = StringParams(model, searchParams);

			string response = client.DownloadString(new Uri(u, "?" + paramsString));

			return JArray.Parse(response);
		}

		public JObject RunSave(string model, IEnumerable<KeyValuePair<string, string>> saveParams)
		{
			if (this.IsEventModel(model))
				saveParams = saveParams.Concat1(new KeyValuePair<string, string>("event", this.EventId.ToString()));

			if (!this.SessionSet)
				throw new Exception("Error, session is not set.");

			Uri u;

			if (saveParams.Any(p => string.Equals(p.Key, "id", StringComparison.OrdinalIgnoreCase)))
			{
				u = new Uri(Domain, "tracker/edit/");
			}
			else
			{
				u = new Uri(Domain, "tracker/add/");
			}

			WebClientEx client = this.CreateClient();

			string response = client.UploadString(u, "POST", StringParams(model, saveParams));

			return JArray.Parse(response).Value<JObject>(0);
		}

		public JObject RunDelete(string model, int id)
		{
			if (!this.SessionSet)
				throw new Exception("Error, session is not set.");

			Dictionary<string,string> deleteParams = new Dictionary<string,string>()
			{
				{ "id", id.ToString() },
			};

			Uri u = new Uri(Domain, "tracker/delete/");

			WebClientEx client = this.CreateClient();

			string response = client.UploadString(u, "POST", StringParams(model, deleteParams));

			return JObject.Parse(response);
		}

		public SearchContext DeferredSearch(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			if (!this.SessionSet)
				return null;

			return new SearchContext(this, model, searchParams);
		}

		public SaveContext DeferredSave(string model, IEnumerable<KeyValuePair<string, string>> saveParams)
		{
			if (!this.SessionSet)
				return null;

			return new SaveContext(this, model, saveParams);
		}

		public DeleteContext DeferredDelete(string model, int id)
		{
			if (!this.SessionSet)
				return null;

			return new DeleteContext(this, model, id);
		}
	}
}
