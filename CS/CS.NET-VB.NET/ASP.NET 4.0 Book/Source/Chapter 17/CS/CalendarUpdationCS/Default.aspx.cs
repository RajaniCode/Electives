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
            Calendar cal;
            cal = (Calendar)Master.FindControl("Calendar1");
            if (cal != null)
            {
                cal.VisibleDate = Convert.ToDateTime(TextBox1.Text);
                cal.SelectedDate = Convert.ToDateTime(TextBox1.Text);
                Label1.Text = " You have entered " + TextBox1.Text;
                Label1.Visible = true;
            }
        }
        catch
        {
            Label1.Text = "Wrong Format Entered";
            Label1.Visible = true;
        }

    }
}