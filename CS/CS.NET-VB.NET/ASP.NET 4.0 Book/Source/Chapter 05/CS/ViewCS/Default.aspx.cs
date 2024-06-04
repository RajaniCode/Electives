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
        MultiView1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View2);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View3);
    }
}