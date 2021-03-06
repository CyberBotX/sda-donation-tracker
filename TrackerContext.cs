﻿using System;
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
				return this.CurrentEvent == null ? null : this.CurrentEvent.GetId();
			}
		}

		public string EventName
		{
			get
			{
				return this.CurrentEvent == null ? null : this.CurrentEvent.GetField("name");
			}
		}

		public string ShortEventName
		{
			get
			{
				return this.CurrentEvent == null ? null : this.CurrentEvent.GetField("short");
			}
		}

		private JObject CurrentEvent;

		public void SetCurrentEvent(JObject eventObj)
		{
			this.CurrentEvent = eventObj;
			this.ResetEntityCaches();

			if (this.EventChanged != null)
				this.EventChanged(this);
		}

		public TrackerContext()
		{
			this.CurrentEvent = null;
			this.EntityCaches = new Dictionary<string, EntitySelectionCache>();
		}

		public void SetSessionId(string sessionId, string domain, string subdomain)
		{
			this.ClearSessionId();

			this.Domain = new Uri(string.Format("http://{0}/{1}/", domain, subdomain));
			this.SessionId = sessionId;

			this.ClientCookie = new Cookie()
			{
				Name = "sessionid",
				Value = this.SessionId,
				Path = "/",
				Domain = domain,
				HttpOnly = true
			};

			JArray results = this.RunSearch("event", Util.CreateRequestParams());

			if (results.Count > 0)
			{
				this.SetCurrentEvent(results.Select(x => (x as JObject)).Aggregate((x, y) => DateTimeFieldModel.ParseDate(x.GetField("date")).CompareTo(DateTimeFieldModel.ParseDate(y.GetField("date"))) >= 0 ? x : y));
			}
		}

		public event Action<TrackerContext> EventChanged;

		private void ResetEntityCaches()
		{
			this.EntityCaches = DonationModels.GetModels().Select(m => new EntitySelectionCache(this, m.ModelName)).ToDictionary(c => c.ModelName);

			if (this.EventId != null)
			{
				this.EntityCaches["choiceoption"].RequestRefresh();
				this.EntityCaches["challenge"].RequestRefresh();
				this.EntityCaches["run"].RequestRefresh();
				this.EntityCaches["prizecategory"].RequestRefresh();
        this.EntityCaches["prize"].RequestRefresh();
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
			return new Uri(Domain, "search/" + SearchParams(model, searchParams));
		}

		private string StringParams(IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			string result = string.Format("{0}", string.Join("&", searchParams.Select(x => (x.Key.Equals("domainId") ? x.Key : x.Key.ToLower()) + "=" + (x.Value == null ? "None" : Uri.EscapeDataString(x.Value)))));
			return result;
		}

		private string SearchParams(string modelName, IEnumerable<KeyValuePair<string, string>> searchParams)
		{
			string result = StringParams(searchParams.Concat1(new KeyValuePair<string, string>("type", modelName)));
			return result;
			//result = string.Format("{0}", string.Join("&", searchParams.Select(x => (x.Key.Equals("domainId") ? x.Key : x.Key.ToLower()) + "=" + (x.Value == null ? "None" : Uri.EscapeDataString(x.Value)))));

			//return string.Format("type={0}&{1}", modelName, result);
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

			Uri u = new Uri(Domain, "search/"); //this.CreateSearchUri(model, searchParams);

			WebClientEx client = this.CreateClient();

			string paramsString = SearchParams(model, searchParams);
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
				u = new Uri(Domain, "edit/");
			}
			else
			{
				u = new Uri(Domain, "add/");
			}

			WebClientEx client = this.CreateClient();

			string response = null;

			try
			{
				string parameters = SearchParams(model, saveParams);
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

			Uri u = new Uri(Domain, "delete/");

			WebClientEx client = this.CreateClient();
			string response = null;

			try
			{
				response = client.UploadString(u, "POST", SearchParams(model, deleteParams));
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			return JObject.Parse(response);
		}

		public string RunScheduleMerge()
		{
			Uri u = new Uri(Domain, "merge_schedule/" + this.EventId.ToString());
			WebClientEx client = this.CreateClient();

			string response = null;

			try
			{
				response = client.DownloadString(u);
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			return response;
		}

		public string RunChipinMerge()
		{
			string parameters = this.StringParams(Util.CreateRequestParams("action", "merge", "event", this.ShortEventName));

			Uri u = new Uri(Domain, "chipin/?event=" + Uri.EscapeUriString(this.ShortEventName));
			WebClientEx client = this.CreateClient();

			string response = null;

			try
			{
				response = client.DownloadString(u);
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			return response;
		}

		public string DrawPrize(int prizeId)
		{
			Uri u = new Uri(Domain, "draw_prize/" + prizeId.ToString());

			string response = null;
			WebClientEx client = this.CreateClient();

			try
			{
				response = client.DownloadString(u);
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			JObject keyInfo = JObject.Parse(response);

			string key = keyInfo.Value<string>("key");

			try
			{
				response = client.UploadString(u, "POST", "key=" + key);
			}
			catch (WebException e)
			{
				this.HandleWebException(e);
			}

			return response;
		}

		public ScheduleMergeContext DeferredScheduleMerge()
		{
			return new ScheduleMergeContext(this);
		}

		public ChipinMergeContext DeferredChipinMerge()
		{
			return new ChipinMergeContext(this);
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

		public PrizeAssignContext DeferredPrizeAssign(int prizeId)
		{
			if (!this.SessionSet)
				return null;

			return new PrizeAssignContext(this, prizeId);
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
