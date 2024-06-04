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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        object[] data = { 1, "one", 2, "two", 3, "three", 4, "four", 5, "five", 6, "six", 7, "seven", 8, "eight", 9, "nine", 10, "ten" };
        var query = data.OfType<string>();
        foreach (var s in query)
        {
            ListBox1.Items.Add(s);
        }

    }
}