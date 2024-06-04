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
        Label1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            String name = null;
            Response.Write(name.ToString());
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = "The Error Message is:  " + ex.Message;
        }
    }

}