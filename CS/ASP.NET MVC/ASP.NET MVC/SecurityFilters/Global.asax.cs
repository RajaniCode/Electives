using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentSecurity;
using SecurityFilters.Controllers;
using System.Web.Security;

namespace SecurityFilters
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Uncomment this line to eable custom attrbute security
            filters.Add(new SecurityFilter());

            //Uncomment this line to use custom 
            //filters.Add(new CustomSecurityAttribute());


            SecurityConfigurator.Configure(configuration =>
            {
                // Let Fluent Security know how to get the authentication status of the current user
                configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);

                // Let Fluent Security know how to get the roles for the current user
                configuration.GetRolesFrom(() =>
                            {
                                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                                if (authCookie != null)
                                {
                                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                                    return authTicket.UserData.Split(',');
                                }
                                else
                                {
                                    return new[]{""};
                                }
                            });

                // This is where you set up the policies you want Fluent Security to enforce
                configuration.For<PublicController>().Ignore();

                configuration.For<PublicController>(x => x.Dashboard()).RequireRole("Public");

                configuration.For<RegisteredController>(x => x.Index()).DenyAnonymousAccess();
                configuration.For<RegisteredController>(x => x.Dashboard()).RequireRole("Registered", "Admin");
                configuration.For<RegisteredController>(x => x.Home()).RequireRole("Registered", "Admin");
                configuration.For<RegisteredController>(x => x.MyAge()).RequireRole("Registered", "Admin");
                configuration.For<RegisteredController>(x => x.Profile()).RequireRole("Registered", "Admin");

                configuration.For<AdminController>(x => x.Index()).DenyAnonymousAccess();
                configuration.For<AdminController>(x => x.Dashboard()).RequireRole("Admin");
                configuration.For<AdminController>(x => x.Home()).RequireRole("Admin");
                configuration.For<AdminController>(x => x.Denied()).RequireRole("Admin");
            });

            //Uncomment this line to enable fluent security
            //GlobalFilters.Filters.Add(new HandleSecurityAttribute(), 0);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Public", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}