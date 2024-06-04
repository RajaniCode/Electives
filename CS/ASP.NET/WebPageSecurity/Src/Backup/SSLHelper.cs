using System;
using System.Web;

namespace Hyper.Web.Security
{
	/// <summary>
	/// The SSLHelper class provides static methods for ensuring that a page is rendered 
	/// securely via SSL or unsecurely.
	/// </summary>
	public class SSLHelper
	{
		/// <summary>
		/// Intializes an instance of this class.
		/// </summary>
		public SSLHelper()
		{
		}

		/// <summary>
		/// Requests the current page over a secure connection, if it is not already.
		/// </summary>
		public static void RequestSecurePage()
		{
			// Is this request secure?
			string RequestPath = HttpContext.Current.Request.Url.ToString();
			if (RequestPath.StartsWith("http://"))
			{
				// Replace the protocal of the requested URL with "https"
				RequestPath = RequestPath.Replace("http://", "https://");

				// Redirect to the secure page
				HttpContext.Current.Response.Redirect(RequestPath, true);
			}
		}

		/// <summary>
		/// Requests the current page over an unsecure connection, if it is not already.
		/// </summary>
		public static void RequestUnsecurePage()
		{
			// Is this request secure?
			string RequestPath = HttpContext.Current.Request.Url.ToString();
			if (RequestPath.StartsWith("https://"))
			{
				// Replace the protocal of the requested URL with "http"
				RequestPath = RequestPath.Replace("https://", "http://");

				// Redirect to the unsecure page
				HttpContext.Current.Response.Redirect(RequestPath, true);
			}
		}
	}
}
