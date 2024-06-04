using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace ASPCS2008WebServiceSessionState
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

       [WebMethod(EnableSession = true)]
        public int IncrementSessionCounterX()
        {
	        int counter = 0;
	        if (Context.Session["Counter"] == null) {
		        counter = 1;
	        } else {
		        counter = Convert.ToInt32(Context.Session["Counter"]) + 1;
	        }
	        Context.Session["Counter"] = counter;
	        return counter;
        }

    }
}
