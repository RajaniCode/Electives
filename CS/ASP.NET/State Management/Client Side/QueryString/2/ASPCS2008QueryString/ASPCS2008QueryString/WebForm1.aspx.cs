using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;

namespace ASPCS2008QueryString
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int loop1, loop2;

            // Load NameValueCollection object.
            //NameValueCollection coll = Request.Params;
            NameValueCollection coll = Request.QueryString;
            // Get names of all keys into a string array.
            String[] arr1 = coll.AllKeys;
            for (loop1 = 0; loop1 < arr1.Length; loop1++)
            {
                Response.Write("Key: " + Server.HtmlEncode(arr1[loop1]) + "<br>");
                String[] arr2 = coll.GetValues(arr1[loop1]);
                for (loop2 = 0; loop2 < arr2.Length; loop2++)
                {
                    Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                }
            }
        }
    }
}
