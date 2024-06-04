using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace UrlRoutingDemo
{
    public partial class ProductsByTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tagNames = RouteData.Values["tagnames"] as string;
            string[] tagList = tagNames.Split('/');

            Response.Write(string.Format("You wanted products that have the following tags: {0}",
                string.Join(" : ", tagList)));

            RouteValueDictionary parameters = new RouteValueDictionary()
            {
                { "tagnames", "new/discounted" }
            };

            VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, "products-by-tag", parameters);
            codeGeneratedLink.NavigateUrl = vpd.VirtualPath;

        }
    }
}