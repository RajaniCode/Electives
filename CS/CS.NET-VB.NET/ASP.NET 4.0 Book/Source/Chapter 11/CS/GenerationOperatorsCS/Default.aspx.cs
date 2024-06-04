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
        var numbers = from n in Enumerable.Range(1, 50)
                      select new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" };
        foreach (var n in numbers)
        {
            ListBox1.Items.Add("The number is " + n.Number + n.OddEven);
        }

    }
}