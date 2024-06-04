using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar Calendar1 = new Calendar();
		TextBox TextBox1 = new TextBox();
		Calendar1 = (Calendar)(PreviousPage.FindControl("Calendar1"));
		TextBox1 = (TextBox)(PreviousPage.FindControl("TextBox1"));
		Label1.Text = "Hi " + TextBox1.Text + ", here is the output of the Cross Page Post Back Button: "+ Calendar1.SelectedDate.ToString();
    }
}