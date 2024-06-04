using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;



    /// <summary>
    /// Summary description for TimeService
    /// </summary>
    [WebService(Namespace="TimeService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService()]
    public class TimeService : System.Web.Services.WebService
    {

        //public TimeService()
        //{

        //    //Uncomment the following line if using designed components 
        //    //InitializeComponent(); 
        //}

        //[WebMethod]
        //public string HelloWorld() {
        //    return "Hello World";
        //}
        [WebMethod]
        public string ServerTime(string myName)
        {
            if (myName == "")
                throw new Exception("Please Enter Your Name");
            return string.Format("Hello {0}, the time on the server is:  {1}", myName, DateTime.Now.ToString());
        }


    }

