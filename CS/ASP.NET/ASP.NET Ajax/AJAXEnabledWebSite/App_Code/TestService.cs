using System;
using System.Threading;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Reflection;
/// <summary>
/// Summary description for TestService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TestService : System.Web.Services.WebService {

    public static Dictionary<string,bool> _TimeoutHistory = new Dictionary<string,bool>();
    public TestService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod][ScriptMethod(UseHttpGet=true)]
    public string HelloWorld(string param) {
        Thread.Sleep(1000);
        if( null == param ) throw new SoapException("param is null", new System.Xml.XmlQualifiedName("error"));
        return param;
    }
    
    [WebMethod][ScriptMethod(UseHttpGet=true)]
    public string Timeout(string param) {
        if( _TimeoutHistory.ContainsKey(param) ) return param;
        _TimeoutHistory[param] = true;
        Thread.Sleep(10000);
        return param;
    }

    [WebMethod][ScriptMethod(UseHttpGet=true)]
    public string CachedGet()
    {
        TimeSpan cacheDuration = TimeSpan.FromMinutes(1);
        Context.Response.Cache.SetCacheability(HttpCacheability.Public);
        Context.Response.Cache.SetExpires(DateTime.Now.Add(cacheDuration));
        Context.Response.Cache.SetMaxAge(cacheDuration);
        Context.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");

        return DateTime.Now.ToString();
    }

    [WebMethod][ScriptMethod(UseHttpGet=true)]
    public string CachedGet2()
    {
        TimeSpan cacheDuration = TimeSpan.FromMinutes(1);

        FieldInfo maxAge = Context.Response.Cache.GetType().GetField("_maxAge", 
            BindingFlags.Instance|BindingFlags.NonPublic);
        maxAge.SetValue(Context.Response.Cache, cacheDuration);

        Context.Response.Cache.SetCacheability(HttpCacheability.Public);
        Context.Response.Cache.SetExpires(DateTime.Now.Add(cacheDuration));
        Context.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");

        return DateTime.Now.ToString();
    }
}

