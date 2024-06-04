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
        Label2.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Enabled = !(TextBox1.Enabled);
        if (TextBox1.Enabled == true)
            Label2.Text = "TextBox is enabled";
        else
            Label2.Text = "TextBox is disabled";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Visible = !(TextBox1.Visible);

        if (TextBox1.Visible == true)
            Label2.Text = "TextBox is Visible";
        else
            Label2.Text = "TextBox is hidden";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Style["BACKGROUND-COLOR"] = "aqua";
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
            TextBox2.Text = "Check Box selected";
        else
            TextBox2.Text = "Check Box is not selected";
    }

}