using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SDA_DonationTracker
{
    public class WebClientEx : WebClient
    {
        public WebClientEx()
        {
            Cookies = new CookieContainer();
        }

        public CookieContainer Cookies{ get; private set; } 

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest r = base.GetWebRequest(address);
            var request = r as HttpWebRequest;
            if (request != null)
            {
                request.CookieContainer = Cookies;
            }
            return r;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            WebResponse response = base.GetWebResponse(request, result);
            ReadCookies(response);
            return response;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            ReadCookies(response);
            return response;
        }

        private void ReadCookies(WebResponse r)
        {
            var response = r as HttpWebResponse;
            if (response != null)
            {
                CookieCollection cookies = response.Cookies;
                Cookies.Add(cookies);
            }
        }
    }
}
