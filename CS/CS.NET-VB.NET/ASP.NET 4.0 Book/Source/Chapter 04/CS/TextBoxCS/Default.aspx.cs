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
		TextBox1.Text = "You have clicked the button";
		TextBox4.Text = "This is a multi line textbox. This is a multi line textbox. This is a multi line textbox. This is a multi line textbox. ";
		TextBox3.Text = TextBox2.Text;
	}

}