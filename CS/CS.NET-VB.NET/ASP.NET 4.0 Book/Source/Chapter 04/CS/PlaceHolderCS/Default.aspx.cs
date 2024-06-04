using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    TextBox Textbox1 = new TextBox();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Textbox1.Text = "This is TextBox inside the placeholder";
        Textbox1.Style["width"] = "280PX";
        PlaceHolder1.Controls.Add(Textbox1);

    }

}