using System;
using System.Web;

/// <summary>
/// Summary description for HttpReceive
/// </summary>
/// 
namespace Microsoft.Samples.BizTalk.Adapters.HttpReceive
{

	public class HttpReceiveWebHandler : IHttpHandler
	{
		public HttpReceiveWebHandler()
		{
		}

		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return false; }
		}

        public void ProcessRequest(HttpContext context)
        {
			// Get the BizTalk HTTP Receive Adapter from the application cache...
			HttpReceiveAdapter httpAdapter = (HttpReceiveAdapter)context.Application["HttpReceiveAdapter"];

			// Pass the HttpContext to the Http Receive Adapter to be processed...
			httpAdapter.ProcessRequest(context);
		}

		#endregion
	}
}