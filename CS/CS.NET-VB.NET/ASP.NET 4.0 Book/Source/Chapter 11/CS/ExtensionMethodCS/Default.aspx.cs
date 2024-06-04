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
        try
        {
            string[] Words = {"lame", "name", "tame", "apple", "mango", "nice", "example", "parrot", "apricot", "banana"};
            var result = Words.OrderBy(s => s);
            ListBox1.Items.Clear();
            foreach (var r in result)
            {
                ListBox1.Items.Add(r);
            }
        }
        catch (Exception ex)
        {
            ListBox1.Items.Add(ex.Message);
        }

    }
}