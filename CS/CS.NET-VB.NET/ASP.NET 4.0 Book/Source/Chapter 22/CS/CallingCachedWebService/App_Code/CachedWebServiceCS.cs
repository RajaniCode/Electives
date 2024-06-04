using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for CachedWebServiceCS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CachedWebServiceCS : System.Web.Services.WebService {

    public CachedWebServiceCS () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}


    [WebMethod(CacheDuration = 60)]
    public string GetCacheResult(int num1, int num2)
    {
        return "The result is " + (num1 + num2).ToString() + ", and the cached time is " + System.DateTime.Now.ToString();
    }    

}
