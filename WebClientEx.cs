using System;
using System.Net;

namespace SDA_DonationTracker
{
	public class WebClientEx : WebClient
	{
		public WebClientEx()
		{
			this.Cookies = new CookieContainer();
		}

		public CookieContainer Cookies
		{
			get;
			private set;
		}

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest r = base.GetWebRequest(address);
			HttpWebRequest request = r as HttpWebRequest;
			if (request != null)
				request.CookieContainer = this.Cookies;
			return r;
		}

		protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
		{
			WebResponse response = base.GetWebResponse(request, result);
			this.ReadCookies(response);
			return response;
		}

		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse response = base.GetWebResponse(request);
			this.ReadCookies(response);
			return response;
		}

		private void ReadCookies(WebResponse r)
		{
			HttpWebResponse response = r as HttpWebResponse;
			if (response != null)
				this.Cookies.Add(response.Cookies);
		}
	}
}
