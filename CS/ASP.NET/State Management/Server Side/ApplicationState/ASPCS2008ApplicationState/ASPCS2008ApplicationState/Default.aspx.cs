using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008ApplicationState
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["PageRequestCount"] = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["PageRequestCount"] =
                ((int)Application["PageRequestCount"]) + 1;
            Application.UnLock();

            Response.Redirect("WebForm1.aspx");
        }
    }
}
