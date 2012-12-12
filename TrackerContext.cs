using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SDA_DonationTracker
{
	public class TrackerContext
	{
		private static readonly string[] EventSearchModels = { "choiceoption", "choice", "challenge", "choicebid", "challengebid", "donation", "prize", "run" };
		private static readonly string[] EventSaveModels = { "run", "prize", "donation" };

		private Dictionary<string, EntitySelectionCache> EntityCaches;

		private Cookie ClientCookie = null;
		private int? _EventId;

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
		public int? EventId
		{
			get
			{
				return _EventId;
			}
			set
			{
				_EventId = value;
				this.ResetEntityCaches();
			}
		}

		public TrackerContext()
		{
			this.EventId = null;
			this.EntityCaches = new Dictionary<string, EntitySelectionCache>();
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
				this.EventId = results.Select(x => (x as JObject)).Aggregate((x, y) => DateTimeFieldModel.ParseDate(x.GetField("date")).CompareTo(DateTimeFieldModel.ParseDate(x.GetField("date"))) >= 0 ? x : y).GetId() ?? 0;
		}

		private void ResetEntityCaches()
		{
			this.EntityCaches = DonationModels.GetModels().Select(m => new EntitySelectionCache(this, m.ModelName)).ToDictionary(c => c.ModelName);

			if (this.EventId != null)
			{
				this.EntityCaches["choiceoption"].RequestRefresh();
				this.EntityCaches["challenge"].RequestRefresh();
				this.EntityCaches["run"].RequestRefresh();
				this.EntityCaches["prizecategory"].RequestRefresh();
			}
		}

		public void ClearSessionId()
		{
			this.ClientCookie = null;
			this.EntityCaches = new Dictionary<string, EntitySelectionCache>();
		}

		public bool IsEventSearchModel(string model)
		{
			foreach (string v in TrackerContext.EventSearchModels)
				if (string.Equals(v, model, StringComparison.OrdinalIgnoreCase))
					return true;

			return false;
		}

		public bool IsEventSaveModel(string model)
		{
			foreach (string v in TrackerContext.EventSaveModels)
				if (string.Equals(v, model, StringComparison.OrdinalIgnoreCase))
					return true;

			return false;
		}

		private Uri CreateSearchUri(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			return new Uri(Domain, "tracker/search/" + StringParams(model, searchParams));
		}

		private string StringParams(string modelName, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			string result = "";

			result = string.Format("{0}", string.Join("&", searchParams.Select(x => (x.Key.Equals("domainId") ? x.Key : x.Key.ToLower()) + "=" + (x.Value == null ? "None" : Uri.EscapeDataString(x.Value)))));

			return string.Format("type={0}&{1}", modelName, result);
		}

		private WebClientEx CreateClient()
		{
			WebClientEx client = new WebClientEx();
			client.Cookies.Add(this.ClientCookie);
			return client;
		}

		public JArray RunIdSearch(string model, int id)
		{
			return this.RunSearch(model, Util.CreateIdSearch(id), true);
		}

		public JArray RunSearch(string model, IEnumerable<KeyValuePair<string, string>> searchParams, bool singleSearch = false)
		{
			if (this.IsEventSearchModel(model))
				searchParams = searchParams.Concat1(new KeyValuePair<string, string>("event", this.EventId.ToString()));

			if (!this.SessionSet)
				throw new TrackerError(TrackerErrorType.NoConnection, "Error, session is not set.");

			Uri u = new Uri(Domain, "tracker/search/"); //this.CreateSearchUri(model, searchParams);

			WebClientEx client = this.CreateClient();

			string paramsString = StringParams(model, searchParams);
			string response = null;

			try
			{
				response = client.DownloadString(new Uri(u, "?" + paramsString));
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}
			JArray result = JArray.Parse(response);

			if (singleSearch && result.Count != 1)
				throw new TrackerError(TrackerErrorType.InstanceDoesNotExist, model + " with id = " + searchParams.Where(p => p.Key.IEquals("id")).Single().Value + " does not exist.");

			return result;
		}

		private void HandleWebException(WebException e)
		{
			StreamReader rdr = new StreamReader(e.Response.GetResponseStream());

			string message = rdr.ReadToEnd();

			if (e.Status == WebExceptionStatus.ProtocolError && message.Trim()[0] == '{')
			{
				JObject data = JObject.Parse(message);

				string errorString = string.Join("\n", data.GetErrorFields().Select(x => x.Key + ": " + x.Value));

				throw new TrackerError(TrackerErrorType.InvalidField, errorString);
			}
			else
			{
				throw TrackerError.ParseErrorResponse(message);
			}
		}

		public JObject RunSave(string model, IEnumerable<KeyValuePair<string, string>> saveParams)
		{
			if (this.IsEventSaveModel(model))
				saveParams = saveParams.Concat1(new KeyValuePair<string, string>("event", this.EventId.ToString()));

			if (string.Equals(model, "run", StringComparison.OrdinalIgnoreCase))
				saveParams = saveParams.Concat1(new KeyValuePair<string, string>("sortkey", "0"));

			if (!this.SessionSet)
				throw new TrackerError(TrackerErrorType.NoConnection, "Error, session is not set.");

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

			string response = null;

			try
			{
				string parameters = StringParams(model, saveParams);
				response = client.UploadString(u, "POST", parameters);
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

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
			string response = null;

			try
			{
				response = client.UploadString(u, "POST", StringParams(model, deleteParams));
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			return JObject.Parse(response);
		}

		public SearchContext DeferredIdSearch(string model, int id)
		{
			if (!this.SessionSet)
				return null;

			return new SearchContext(this, model, Util.CreateIdSearch(id), true);
		}

		public SearchContext DeferredSearch(string model, IEnumerable<KeyValuePair<string, string>> searchParams, bool singleSearch = false)
		{
			if (!this.SessionSet)
				return null;

			return new SearchContext(this, model, searchParams, singleSearch);
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

		public EntitySelectionCache GetEntitySelectionCache(string model)
		{
			EntitySelectionCache result;
			
			if (this.EntityCaches.TryGetValue(model, out result))
				return result;
			else
				return null;
		}
	}
}
