using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SynchronousHTTPHandler
/// The code implements the ProcessRequest method and writes a string to the Response property of the current HttpContext object.
/// </summary>
public class SynchronousHTTPHandler : IHttpHandler
{
	public SynchronousHTTPHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest Request = context.Request;
        HttpResponse Response = context.Response;
        // This handler is called whenever a file ending 
        // in .sample is requested. A file with that extension
        // does not need to exist.
        Response.Write("<html>");
        Response.Write("<body>");
        Response.Write("<h1>Hello from a synchronous custom HTTP handler.</h1>");
        Response.Write("</body>");
        Response.Write("</html>");
    }

    public bool IsReusable
    {
        // To enable pooling, return true here.
        // This keeps the handler in memory.
        get { return false; }
    }

}