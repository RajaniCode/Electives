using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CustomerList : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      // get DataSet of customers from CustomerModel class
      // and bind to GridView control in the page
      CustomerModel customerList = new CustomerModel();
      GridView1.DataSource = customerList.GetCustomerList();
      GridView1.DataBind();
    }
    catch (Exception ex)
    {
      Label1.Text += "USER CONTROL ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
}
