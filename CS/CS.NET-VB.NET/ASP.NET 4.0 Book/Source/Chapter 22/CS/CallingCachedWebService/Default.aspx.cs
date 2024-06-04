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
        int num1, num2;
        localhost.CachedWebServiceCS service = new localhost.CachedWebServiceCS();
        num1 = Convert.ToInt32(TextBox1.Text);
        num2 = Convert.ToInt32(TextBox2.Text);
        Label1.Text = service.GetCacheResult(num1, num2);
        //localhost.CachedWebServiceCS service = new localhost.CachedWebServiceCS();
        //int num1 = Convert.ToInt32(TextBox1.Text);
        //int num2 = Convert.ToInt32(TextBox2.Text);
        //Label1.Text = service.GetCacheResult(num1, num2);
    }
}