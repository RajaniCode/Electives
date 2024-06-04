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

public partial class CustomerDetails : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      // use CustomerModel to get DataRow for specified customer  
      CustomerModel customers = new CustomerModel();
      DataRow[] details = customers.GetCustomerDetails("ALFKI");
      // convert row values into an array
      Object[] values = details[0].ItemArray;
      Label1.Text += "Customer Details from CustomerModel class: <br />";
      // iterate through the array displaying the values
      foreach (Object item in values)
      {
        Label1.Text += item.ToString() + ", ";
      }
    }
    catch (Exception ex)
    {
      Label1.Text += "USER CONTROL ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
}
