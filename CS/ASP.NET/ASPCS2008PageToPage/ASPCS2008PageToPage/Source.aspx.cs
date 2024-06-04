using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008PageToPage
{
    public partial class Source : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string targetURL;

            targetURL = "Target.aspx";

            targetURL += "?&field1=" + Server.UrlEncode(TextBox1.Text.Trim());

            targetURL += "&field2=" + Server.UrlEncode(TextBox2.Text.Trim());

            Session["field3"] = TextBox3.Text.Trim();

            Response.Redirect(targetURL);

            //Response.Redirect("Target.aspx?field1=value1&field2=value2");
        }

        // Public property values from the source page
        public String CurrentCity
        {
            get
            {
                return TextBox4.Text;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Target.aspx");
        }

       

        
        
    }
}
