using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace UrlRoutingDemo
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            InitializeRoutes(RouteTable.Routes);
        }

        void InitializeRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("about-us", "about", "~/About.aspx");

            // URL pattern: blog/2010/05/12 routes to blog.aspx
            routes.MapPageRoute("blog", "blog/{year}/{month}/{day}", "~/Blog.aspx");

            // URL pattern with defaults
            routes.MapPageRoute("category-browse",
                "category/{categoryname}",
                "~/Category.aspx",
                true,
                new RouteValueDictionary()
                {
                    {"categoryname", "explosives"}
                });

            // URL pattern with variable segments
            routes.MapPageRoute("products-by-tag",
                "products/tags/{*tagnames}",
                "~/ProductsByTag.aspx");

            // URL pattern with constraints            
            routes.MapPageRoute(
                routeName: "constrained-blog",
                routeUrl: "cblog/{year}/{month}/{day}",
                physicalFile: "~/Blog.aspx",
                checkPhysicalUrlAccess: true,
                defaults: new RouteValueDictionary() {
                    { "year", DateTime.Now.Year.ToString() }, 
                    { "month", DateTime.Now.Month.ToString() },
                    { "day", DateTime.Now.Day.ToString() }
                },
                constraints: new RouteValueDictionary() {
                    { "year", @"\d{0,4}" },
                    { "month", @"\d{0,2}" },
                    { "day", @"\d{0,2}" }
                });
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
