using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            Label4.Text = "You have Selected Football";
        }
        else if (RadioButton2.Checked)
        {
            Label4.Text = "You have Selected Cricket";
        } 
    }
}