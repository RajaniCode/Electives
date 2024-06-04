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
        Calendar1.SelectedDate = DateTime.Now;
        TextBox1.Text = "Today's date and time is :" + Calendar1.SelectedDate;
    }
}