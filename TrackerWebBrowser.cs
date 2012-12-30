using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace SDA_DonationTracker
{
	class TrackerWebBrowser : WebBrowser
	{
		/// <summary>
		/// Will be true if login was successful (more than likely will be unless Google
		/// authorization was denied).
		/// </summary>
		public bool LoggedIn
		{
			get;
			set;
		}
		/// <summary>The domain name of the tracker.</summary>
		public string TrackerDomain
		{
			get;
			set;
		}
		/// <summary>The sessionid that the browser got from the tracker.</summary>
		public string SessionID
		{
			get;
			private set;
		}

		// The following is for getting the HttpOnly cookies needed to get the sessionid.
		[DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern bool InternetGetCookieEx(string pchURL, string pchCookieName,
			StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
		const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

		// Imports the NavigateError method from the OLE DWebBrowserEvents2
		// interface.
		[ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
			InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
			TypeLibType(TypeLibTypeFlags.FHidden)]
		public interface DWebBrowserEvents2
		{
			[DispId(271)]
			void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
				[In] ref object URL, [In] ref object frame,
				[In] ref object statusCode, [In, Out] ref bool cancel);
		}

		/// <summary>
		/// Get all the cookies for the given URI.
		/// </summary>
		/// <param name="uri">The URI to check.</param>
		/// <returns>A string containing the cookies for the given URI.</returns>
		private static string GetGlobalCookies(string uri)
		{
			return TrackerWebBrowser.GetGlobalCookies(uri, null);
		}

		/// <summary>
		/// Get the cookie(s) for the given URI.
		/// </summary>
		/// <param name="uri">The URI to check.</param>
		/// <param name="cookieName">If null, all cookies will be retrieved, otherwise just a single cookie.</param>
		/// <returns>A string containing the cookie(s) for the given URI.</returns>
		private static string GetGlobalCookies(string uri, string cookieName)
		{
			uint datasize = 1024;
			StringBuilder cookieData = new StringBuilder((int)datasize);
			if (InternetGetCookieEx(uri, cookieName, cookieData, ref datasize,
				INTERNET_COOKIE_HTTPONLY, IntPtr.Zero) && cookieData.Length > 0)
				return cookieData.ToString().Replace(';', ',');
			else
				return null;
		}

		private string Email, Password;

		public void DoLogin(string domain, string email, string password)
		{
			this.TrackerDomain = domain;
			this.Email = email;
			this.Password = password;
			this.LoggedIn = false;
			this.Navigate("https://accounts.google.com/Login");
		}

		private AxHost.ConnectionPointCookie cookie;
		private TrackerWebBrowserEventHelper helper;

		[PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void CreateSink()
		{
			base.CreateSink();

			// Create an instance of the client that will handle the event
			// and associate it with the underlying ActiveX control.
			this.helper = new TrackerWebBrowserEventHelper(this);
			this.cookie = new AxHost.ConnectionPointCookie(this.ActiveXInstance, this.helper,
				typeof(DWebBrowserEvents2));
		}

		[PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
		protected override void DetachSink()
		{
			// Disconnect the client that handles the event
			// from the underlying ActiveX control.
			if (cookie != null)
			{
				cookie.Disconnect();
				cookie = null;
			}

			base.DetachSink();
		}

		// Raises the NavigateError event.
		protected virtual void OnNavigateError(WebBrowserNavigateErrorEventArgs e)
		{
			if (e.StatusCode == 404 &&
				e.Url == string.Format("http://{0}/openid/login/", this.TrackerDomain))
				this.Navigate(string.Format("http://{0}/tracker/openid/login/", this.TrackerDomain));
			else
			{
				MessageBox.Show(this, string.Format(@"Unable to connect to {0}.
HTTP Status Code: {1}", e.Url, e.StatusCode), "Navigation Error!", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Application.ExitThread();
			}
		}

		// Handles the NavigateError event from the underlying ActiveX
		// control by raising the NavigateError event defined in this class.
		private class TrackerWebBrowserEventHelper : StandardOleMarshalObject, DWebBrowserEvents2
		{
			private TrackerWebBrowser parent;

			public TrackerWebBrowserEventHelper(TrackerWebBrowser parent)
			{
				this.parent = parent;
			}

			public void NavigateError(object pDisp, ref object url, ref object frame, ref object statusCode, ref bool cancel)
			{
				// Raise the NavigateError event.
				this.parent.OnNavigateError(new WebBrowserNavigateErrorEventArgs((string)url, (string)frame, (int)statusCode, cancel));
			}
		}

		// Represents the method that will handle the TrackerWebBrowser.NavigateError event.
		public delegate void WebBrowserNavigateErrorEventHandler(object sender, WebBrowserNavigateErrorEventArgs e);

		// Provides data for the TrackerWebBrowser.NavigateError event.
		public class WebBrowserNavigateErrorEventArgs : EventArgs
		{
			public WebBrowserNavigateErrorEventArgs(string url, string frame, int statusCode, bool cancel)
			{
				this.Url = url;
				this.Frame = frame;
				this.StatusCode = statusCode;
				this.Cancel = cancel;
			}

			public string Url
			{
				get;
				set;
			}

			public string Frame
			{
				get;
				set;
			}

			public int StatusCode
			{
				get;
				set;
			}

			public bool Cancel
			{
				get;
				set;
			}
		}

		protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
		{
 			base.OnDocumentCompleted(e);

			if (e.Url.Host == "accounts.google.com")
			{
				// This block comes up on the initial log-in to Google.
				if (e.Url.AbsolutePath == "/Login")
				{
					HtmlElement email = this.Document.GetElementById("Email");
					email.SetAttribute("value", this.Email);

					HtmlElement password = this.Document.GetElementById("Passwd");
					password.SetAttribute("value", this.Password);

					HtmlElement signin = this.Document.GetElementById("signIn");
					signin.InvokeMember("Click");
				}
				// This block comes up if the username or password entered were rejected by Google.
				else if (e.Url.AbsolutePath == "/ServiceLoginAuth")
				{
					MessageBox.Show(this, "The username or password entered were incorrect.",
						"Google Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.ExitThread();
				}
				// This block comes up if the tracker site was not authorized on the user's
				// Google account, and asks the user to allow for the authorization.
				else if (e.Url.AbsolutePath == "/o/openid2/auth")
				{
					if (MessageBox.Show(this, @"Google requires authorization to allow the tracker
to access your account.  Do you wish to allow this?", "Google Authorization",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						HtmlElement approveButton = this.Document.GetElementById("approve_button");
						approveButton.InvokeMember("Click");
					}
					else
						Application.ExitThread();
				}
			}
			// This block comes up after logging in to Google, and starts the login to the tracker.
			else if (e.Url.Host == "www.google.com" && e.Url.AbsolutePath == "/settings/account")
				this.Navigate(string.Format("http://{0}/openid/login/", this.TrackerDomain));
			// This block comes up for the tracker site, we only want to process it if the main
			// tracker page has come up.
			else if (e.Url.Host == this.TrackerDomain && e.Url.AbsolutePath == "/tracker/")
			{
				this.LoggedIn = true;
				string cookies = TrackerWebBrowser.GetGlobalCookies(e.Url.ToString(), "sessionid");
				this.SessionID = cookies.Substring(10);
				Application.ExitThread();
			}
		}
	}
}
