using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


/// <summary>
/// Summary description for CustomHandler
/// </summary>
namespace CustomHTTP
{
    public class CustomHandler : IHttpHandler
{
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
    public void ProcessRequest(System.Web.HttpContext context)
    {
        HttpResponse Response = context.Response;
        Response.Write("<html><body><H2>Sample HTTP Handler</H2></body></html>");
    }

}

}
