using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UrlRoutingDemo
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string year = Page.RouteData.Values["year"] as string;
            string month = Page.RouteData.Values["month"] as string;
            string day = Page.RouteData.Values["day"] as string;

            Response.Write(string.Format("You requested the blog posts for {0}/{1}/{2}",
                month, day, year));
        }
    }
}