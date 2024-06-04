<%@ WebHandler Language="C#" Class="GenericHandler" %>

using System;
using System.Web;

public class GenericHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        ManageForm(context);
    }
 
    public void ManageForm(HttpContext context)
	{        
		context.Response.Write("<html><body><form>");
		if (context.Request.Params["Feature"] == null)
		{
			context.Response.Write("<h2>Hello there. Select your Favorite Feature of ASP .NET 4.0 </h2>");
			context.Response.Write("<select name='Feature'>");
			context.Response.Write("<option> ASP.NET AJAX</option>");
			context.Response.Write("<option> LINQ </option>");
			context.Response.Write("<option> Silverlight </option>");
			context.Response.Write("<option> WCF </option>");
			context.Response.Write("</select>");
			context.Response.Write("<input type=submit name='Lookup' value='Lookup'></input>");
			context.Response.Write("</br>");
		}
      
		if (context.Request.Params["Feature"] != null)
		{
			context.Response.Write("Hi, you picked: ");
			context.Response.Write(context.Request.Params["Feature"]);
			context.Response.Write(" as your favorite feature.</br>");            
		}
		context.Response.Write("</form></body></html>");
	}

    public bool IsReusable {
        get {
            return false;
        }
    }

}