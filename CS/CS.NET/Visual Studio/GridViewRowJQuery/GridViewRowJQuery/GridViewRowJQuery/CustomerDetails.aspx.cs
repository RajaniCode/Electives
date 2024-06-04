using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cid = Request.QueryString["CID"];
        string cname = Request.QueryString["CName"];
        Response.Write("CustomerID= " + cid + " : " + "CompanyName= " + cname);
    }
}
