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
        string[] fruits = { "apple", "banana", "peach", "mango" };
        string[] words = { "hello", "peach", "linq", "mango", "set" };
        var common = fruits.Intersect(words);
        ListBox1.Items.Add("Common in both arrays: ");
        foreach (var n in common)
        {
            ListBox1.Items.Add(n);
        }

    }
}