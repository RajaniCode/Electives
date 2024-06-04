using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;
using System.Data.Services.Client;
using System.Data.Services;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NorthwindEntities svc = new NorthwindEntities(new Uri("http://localhost:3365/WebSite1/WcfDataService.svc"));
        GridView1.DataSource = svc.Customers;
        GridView1.DataBind();
    }
}