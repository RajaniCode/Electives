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

public partial class CityList : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      // use CustomerModel to get SortedList of cities
      CustomerModel customers = new CustomerModel();
      SortedList cities = customers.GetCityList();
      // iterate through the SortedList displaying the values
      Label1.Text += "List of cities and count of customers from CustomerModel class: <br />";
      foreach (String key in cities.Keys)
      {
        Label1.Text += key + " (" + cities[key].ToString() + ")<br />";
      }
    }
    catch (Exception ex)
    {
      Label1.Text += "USER CONTROL ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
}
