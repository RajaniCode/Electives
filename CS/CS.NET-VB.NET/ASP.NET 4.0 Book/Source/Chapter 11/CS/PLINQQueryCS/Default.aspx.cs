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
        int i, j, n;
        i = Convert.ToInt32(TextBox1.Text);
        j = Convert.ToInt32(TextBox2.Text);
        n = Convert.ToInt32(TextBox3.Text);
        var source = Enumerable.Range(i, j);


        var parallelQuery = from num in source.AsParallel().AsOrdered()
                            where num % n == 0
                            select num;


        foreach (var v in parallelQuery)
        {
            if (v < j)
            {
                ListBox1.Items.Add(v.ToString());
            }
        }
    }
}