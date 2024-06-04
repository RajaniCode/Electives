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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (CheckBox1.Checked && CheckBox2.Checked)
            Response.Write("You are an undergraduate and also a post graduate");
        else if (CheckBox1.Checked && !CheckBox2.Checked)
            Response.Write("You are a post graduate");
        else if (CheckBox2.Checked && !CheckBox1.Checked)
            Response.Write("You are an under graduate");
        else
            Response.Write("You are neither a under graduate nor a post graduate");

    }
}