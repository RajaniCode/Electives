using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsingCSS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInvoke_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(3000);
        lblText.Text = "Processing completed";
    }
}



