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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.Text == "South Delhi")
        {
            this.TextBox2.Text = "South Delhi";
        }
        else if (RadioButtonList1.Text == "North Delhi")
        {
            this.TextBox2.Text = "North Delhi";
        }
        else if (RadioButtonList1.Text == "East Delhi")
        {
            this.TextBox2.Text = "East Delhi";
        }
        else if (RadioButtonList1.Text == "West Delhi")
        {
            this.TextBox2.Text = "West Delhi";
        }
        else if (RadioButtonList1.Text == "Central Delhi")
        {
            this.TextBox2.Text = "Central Delhi";
        }

    }
}