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
        private WebClientEx Client = new WebClientEx(new CookieContainer());
        public bool SessionSet { get; private set; }
        public Uri Domain { get; private set; }
        public string SessionId { get; private set; }

        public void SetSessionId(string sessionId, string domain)
        {
            ClearSessionId();

            Domain = new Uri("http://" + domain + "/");
            SessionId = sessionId;

            Cookie c = new Cookie();
            c.Name = "sessionid";
            c.Value = SessionId;
            c.Path = "/";
            c.Domain = domain;
            c.HttpOnly = true;
            
            Client.Cookies.Add(c);
            SessionSet = true;
        }

        public void ClearSessionId()
        {
            Client.Cookies = new CookieContainer();
            SessionSet = false;
        }

        private Uri CreateSearchUri(string model, IEnumerable<KeyValuePair<string, string>> searchParams)
        {
            return new Uri(Domain, "tracker/search/?type=" + model + "&" + searchParams.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Key.ToLower() + "=" + x.Value).JoinSeperated("&"));
        }

        public JArray RunSearch(string model, IEnumerable<KeyValuePair<string,string>> searchParams)
        {
            if (!SessionSet)
            {
                throw new Exception("Error, session is not set.");
            }

            Uri u = CreateSearchUri(model, searchParams);

            string data = Client.DownloadString(u);
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
