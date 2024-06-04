using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008GettControlInformationfromSourcePage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                TextBox SourceTextBox =
                    (TextBox)Page.PreviousPage.FindControl("TextBox1");
                if (SourceTextBox != null)
                {
                    Label1.Text = SourceTextBox.Text;
                }
            }
        }
    }
}
