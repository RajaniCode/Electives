using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UrlRoutingDemo
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string categoryName = RouteData.Values["categoryname"] as string;
            Response.Write(string.Format("Category you chose: {0}", categoryName));
        }
    }
}