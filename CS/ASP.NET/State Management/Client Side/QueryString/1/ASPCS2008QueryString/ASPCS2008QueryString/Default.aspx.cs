using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008QueryString
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            //HtmlAnchor1.HRef = "WebForm1.aspx?QueryStringValue=" + TextBox1.Text;

            Response.Redirect("WebForm1.aspx?QueryStringValue=" + TextBox1.Text);
            //Server.Transfer("WebForm1.aspx?QueryStringValue=" + TextBox1.Text);  
        }
    }
}
