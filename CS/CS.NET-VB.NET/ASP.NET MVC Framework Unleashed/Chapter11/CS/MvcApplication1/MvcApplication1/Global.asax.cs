using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;


namespace MvcApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "JS")
                return Request.Browser.EcmaScriptVersion.ToString();
            return base.GetVaryByCustomString(context, custom);
        }


        //public void Application_BeginRequest()
        //{
        //    Debug.WriteLine("Application_BeginRequest");
        //}

        //public void Application_AuthenticateRequest()
        //{
        //    Debug.WriteLine("Application_AuthenticateRequest");
        //}

        //public void Application_AuthorizeRequest()
        //{
        //    Debug.WriteLine("Application_AuthorizeRequest");
        //}

        //public void Application_EndRequest()
        //{
        //    Debug.WriteLine("Application_EndRequest");
        //}

        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              
                "{controller}/{action}/{id}",                           
                new { controller = "Home", action = "Index", id = "" }  
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}