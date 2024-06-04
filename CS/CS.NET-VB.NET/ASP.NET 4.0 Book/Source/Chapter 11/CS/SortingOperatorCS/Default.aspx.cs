using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    double[] doubles = { 500, 700, 100, 200, 400, 600, 900, 300, 800 };
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        var sorting = from d in doubles
                      orderby d
                      select d;
        foreach (var d in sorting)
        {
            ListBox1.Items.Add(d.ToString());
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
		var DescendingSorting = from d in doubles
			orderby d descending
			select d;
		foreach (var d in DescendingSorting)
		{
			ListBox1.Items.Add(d.ToString());
		}

    }
}