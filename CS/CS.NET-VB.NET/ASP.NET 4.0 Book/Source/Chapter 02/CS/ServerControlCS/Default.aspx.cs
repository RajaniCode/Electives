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
        string str = "Welcome " + DropDownList1.SelectedValue + " " + TextBox1.Text;
        DropDownList1.Visible = false;
        TextBox1.Visible = false;
        Label1.Visible = false;
        Label2.Visible = false;
        Button1.Visible = false;
        Response.Write(str);
    }
}