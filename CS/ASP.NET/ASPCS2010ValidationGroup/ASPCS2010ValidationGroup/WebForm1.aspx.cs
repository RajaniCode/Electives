using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2010ValidationGroup
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidationGroup1");
            Page.Validate("ValidationGroup2");

            if (Page.IsValid)
            {
                Response.Redirect("WebForm2.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidationGroup2");
            Page.Validate("ValidationGroup3");

            if (Page.IsValid)
            {
                Response.Redirect("WebForm2.aspx");
            }
        }
    }
}