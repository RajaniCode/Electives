using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2010ViewState
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private int Counter
        {
            get
            {
                object Instance = ViewState["Counter"];
                return (Instance == null) ? 0 : (int)Instance;
            }
            set
            {
                ViewState["Counter"] = value;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Counter++;
            TextBox1.Text = Counter.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {           
            ViewState["Name"] = TextBox1.Text.Trim();
            Context.Items.Add("Page1", ViewState["Name"]);

            //Won't work
            //Response.Redirect("WebForm2.aspx");

            Server.Transfer("WebForm2.aspx");
        }
    }
}