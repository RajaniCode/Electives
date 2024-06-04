using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    object[] list = { "hello", 34, "mango", 90, "nice", "example", 7.3m, 8.0f, "linq" };

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        var num = list.OfType<int>();
        ListBox1.Items.Add("The Numeric Characters are: ");
        foreach (var n in num)
        {
            ListBox1.Items.Add(n.ToString());
        }

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        var str = list.OfType<string>();
        ListBox1.Items.Add("The String Characters are: ");
        foreach (var s in str)
        {
            ListBox1.Items.Add(s);
        }
    }
}