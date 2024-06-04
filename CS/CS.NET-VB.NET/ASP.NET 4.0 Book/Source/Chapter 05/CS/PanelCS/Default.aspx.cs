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
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Panel2.BackColor = System.Drawing.Color.Red;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Panel2.BackColor = System.Drawing.Color.Green;
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        Panel2.BackColor = System.Drawing.Color.Yellow;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}