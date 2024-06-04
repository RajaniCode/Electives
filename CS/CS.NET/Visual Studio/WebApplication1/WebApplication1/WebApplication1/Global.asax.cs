using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString); 
        }

        protected void Application_End(object sender, EventArgs e)
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }        
    }
}