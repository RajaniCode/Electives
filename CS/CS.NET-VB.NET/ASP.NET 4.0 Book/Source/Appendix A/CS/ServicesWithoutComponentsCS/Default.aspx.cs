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
        TransactionClass trans = new TransactionClass();
			Label1.Text=trans.AddDetails("Table Lamp", "A table lamp with the picture of flowers", "Show piece");
			// MessageBox.Show(trans.AddDetails("Table Lamp", "A table lamp with the picture of flowers", "Show piece"));

    }
}