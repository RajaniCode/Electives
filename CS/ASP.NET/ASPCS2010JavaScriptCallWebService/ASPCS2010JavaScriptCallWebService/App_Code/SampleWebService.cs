using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for WebService1
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SampleWebService : System.Web.Services.WebService
{
    public SampleWebService()
    {

    }
    
    [WebMethod]
    public string GetServerResponse(string callerName)
    {
        if (callerName == string.Empty)
        {
            throw new Exception("Web Service Exception: invalid argument");
        }
        else
        {
            return "Service responded to " + callerName + " at " + DateTime.Now.ToString();
        }
    }
}
