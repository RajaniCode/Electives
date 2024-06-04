using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008PageToPage
{
    public partial class Target : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Query String
            Label1.Text = Request.QueryString["field1"];
            Label2.Text = Request.QueryString["field2"];

            // Session State
            Label3.Text = (string)(Session["field3"]);

            Source s = PreviousPage as Source;
            if (s != null)
            {
                Label4.Text = s.CurrentCity;
                // Label4.Text = PreviousPage.CurrentCity;
            }
              
            // Exception if Button1_Click
            //Label4.Text = PreviousPage.CurrentCity;

            // Values of controls from the source page 
            if (Page.PreviousPage != null)
            {
                TextBox SourceTextBox =
                    (TextBox)Page.PreviousPage.FindControl("TextBox5");
                if (SourceTextBox != null)
                {
                    Label5.Text = SourceTextBox.Text;
                }
            }
        }
    }
}
