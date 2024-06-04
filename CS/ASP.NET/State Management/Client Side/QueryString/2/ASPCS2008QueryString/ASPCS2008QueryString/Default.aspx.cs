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
            //Server.Transfer("WebForm1.aspx?field1=value1&field2=value2");
            Response.Redirect("WebForm1.aspx?field1=value1&field2=value2");
        }
    }
}
