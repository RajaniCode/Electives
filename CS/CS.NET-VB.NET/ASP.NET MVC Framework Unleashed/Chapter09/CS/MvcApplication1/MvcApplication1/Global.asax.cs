using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication1.Constraints;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute( 
                "SortRoute", 
                "Sort/{*values}", 
                new {controller = "Sort", action = "Index"} 
            );



            //routes.MapRoute( 
            //    "Product1", 
            //    "Product/{action}", 
            //    new {controller = "Product"} 
            //);




            //routes.MapRoute( 
            //    "DefaultNoAdmin", 
            //    "{controller}/{action}/{id}", 
            //    new {controller = "Home", action = "Index", id = ""}, 
            //    new {controller = new NotEqual("Admin")} 
            //);





            //routes.MapRoute( 
            //    "Admin", 
            //    "Admin/{action}", 
            //    new {controller = "Admin"}, 
            //    new {Auth = new AuthenticatedConstraint()} 
            //);



            routes.MapRoute(
                "ProductInsert",
                "Product/Insert",
                 new { controller = "Product", action = "Insert" },
                 new { method = new HttpMethodConstraint("POST") }
            );


            //routes.MapRoute(
            //  "BlogArchive",
            //  "Archive/{entryDate}",
            //  new { controller = "Blog", action = "Archive" },
            //  new { entryDate = @"\d{2}-\d{2}-\d{4}" }
            //);


            //routes.MapRoute(
            //    "BlogArchive",                             
            //    "Archive/{entryDate}",                           
            //    new { controller = "Blog", action = "Archive" }  
            //);


            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
            
            
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}