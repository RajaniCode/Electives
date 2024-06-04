using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008SessionState
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null)
            {
                TextBox1.Text = (string)Session["FirstName"];
            }
            else
            {
                TextBox1.Text = "Null";
            }

            if (Session["LastName"] != null)
            {
                TextBox2.Text = (string)Session["LastName"];
            }
            else
            {
                TextBox2.Text = "Null";
            }
        }
    }
}
