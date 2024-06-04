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
        string[] names = new string[] { "Ram", "Priya", "Puja", "Rita", "Jhonny", "Steve" };
        string[] position = new string[] { "Manager", "Team Leader", "Developer", "Writer", "Director" };
        int[] years = new int[] { 1, 2, 4, 8, 9 }; 

        var q = names.Zip(position, (a, b) => a + " is the " + b + " of the company");
        var r = q.Zip(years, (c, d) => c + " with " + d + " years of experience.");
        
        foreach (var result in r)
        {
            ListBox1.Items.Add(result);
        }

    }
}