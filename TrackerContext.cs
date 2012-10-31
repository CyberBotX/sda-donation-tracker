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
        public bool SessionSet { get { return ClientCookie != null; } }
        public Uri Domain { get; private set; }
        public string SessionId { get; private set; }
        public int EventId { get; set; }

        public TrackerContext()
        {
            EventId = 0;
        }

        public void SetSessionId(string sessionId, string domain)
        {
            ClearSessionId();

            Domain = new Uri("http://" + domain + "/");
            SessionId = sessionId;

            ClientCookie = new Cookie();
            ClientCookie.Name = "sessionid";
            ClientCookie.Value = SessionId;
            ClientCookie.Path = "/";
            ClientCookie.Domain = domain;
            ClientCookie.HttpOnly = true;

            JArray results = RunSearch("event", Util.CreateSearchParams());
            
            if (results.Count > 0)
            {
                EventId = results.Select(x => x.Value<int>("id")).Aggregate(0, (x, y) => Math.Max(x, y));
            }
        }

        public void ClearSessionId()
        {
            ClientCookie = null;
        }

        public bool IsEventModel(string model)
        {
            foreach (var v in EventModels)
            {
                if (string.Equals(v, model, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private Uri CreateSearchUri(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
        {
            return new Uri(Domain, "tracker/search/?type=" + model + "&" + searchParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Key.ToLower() + "=" + x.Value).JoinSeperated("&"));
        }

        private WebClientEx CreateClient()
        {
            var client = new WebClientEx();
            client.Cookies.Add(ClientCookie);
            return client;
        }

        public JArray RunSearch(string model, IEnumerable<KeyValuePair<string,string>> searchParams)
        {
            if (IsEventModel(model))
            {
                searchParams.Concat1(new KeyValuePair<string, string>("event", EventId.ToString()));
            }
            
            if (!SessionSet)
            {
                throw new Exception("Error, session is not set.");
            }

            Uri u = CreateSearchUri(model, searchParams);

            var client = CreateClient();

            string data = client.DownloadString(u);
            JArray result = JArray.Parse(data);

            return result;
        }

        public SearchContext DeferredSearch(string model, IEnumerable<KeyValuePair<string,string>> searchParams)
        {
            if (!SessionSet)
            {
                return null;
            }

            return new SearchContext(this, model, searchParams);
        }
    }
}
