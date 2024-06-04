using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{

  // display a list of all customers
  protected void btn_CustList_Click(object sender, EventArgs e)
  {
    try
    {
      // get DataSet of customers from CustomerModel class
      // and bind to GridView control in the page
      CustomerModel customers = new CustomerModel();
      Label1.Text += "Customer List from CustomerModel class:<p />";
      GridView1.DataSource = customers.GetCustomerList();
      GridView1.DataBind();
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message + "<p />";
    }
  }
  //------------------------------------------------------

  // display the name of the specified customer
  protected void btn_CustModel_Click(object sender, EventArgs e)
  {
    try
    {
      // use method of the CustomerModel class
      CustomerModel customers = new CustomerModel();
      Label1.Text += "Customer Name from CustomerModel class: ";
      Label1.Text += customers.GetCustomerName(txtID_CustModel.Text);
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
  //------------------------------------------------------

  // display all the details of the specified customer
  protected void btn_CustDetails_Click(object sender, EventArgs e)
  {
    // get details from CustomerModel class
    try
    {
      // use CustomerModel to get DataRow for specified customer  
      CustomerModel customers = new CustomerModel();
      DataRow[] details = customers.GetCustomerDetails(txtID_CustDetails.Text);
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
      Label1.Text += "PAGE ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
  //------------------------------------------------------

  // display a list of customers extracted from the Customer Repository
  protected void btn_ReposList_Click(object sender, EventArgs e)
  {
    try
    {
      // get DataSet of customers from CustomerRepositoryModel class
      // and bind to GridView control in the page
      CustomerRepositoryModel customers = new CustomerRepositoryModel();
      Label1.Text += "Customer List from CustomerRepositoryModel repository:<p />";
      GridView1.DataSource = customers.GetCustomerList();
      GridView1.DataBind();
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message + "<p />";
      if (ex.InnerException != null)
      {
        Label1.Text += "INNER EXCEPTION: " + ex.InnerException.Message;
      }
    }
  }
  //------------------------------------------------------

  // display the name of the specified customer using the Customer Repository
  // extra processing in Repository allows for match on partial ID
  protected void btn_ReposName_Click(object sender, EventArgs e)
  {
    try
    {
      // use method of the CustomerRepositoryModel class
      CustomerRepositoryModel customers = new CustomerRepositoryModel();
      Label1.Text += "Customer Name from CustomerRepositoryModel repository: ";
      Label1.Text += customers.GetCustomerName(txtID_ReposName.Text);
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
  //------------------------------------------------------
  
  // display name of specified customer using the Web Service 
  protected void btn_WSProxy_Click(object sender, EventArgs e)
  {
    try
    {
      // get details from Web Service
      // use 'using' construct to ensure disposal after use
      using (LocalDemoService.Service svc = new LocalDemoService.Service())
      {
        Label1.Text += "Customer name from Web Service: " 
                    + svc.CustomerName(txtID_WSProxy.Text);
      }
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message;
    }
    Label1.Text += "<p />";
  }
  //------------------------------------------------------

  // display name of specified customer using the Service Agent
  // extra processing in Agent allows for match on partial ID
  protected void btn_WSAgent_Click(object sender, EventArgs e)
  {
    try
    {
      // get details from Service Agent
      ServiceAgent agent = new ServiceAgent();
      Label1.Text += "Customer name from Service Agent: " 
                  + agent.GetCustomerName(txtID_WSAgent.Text);
    }
    catch (Exception ex)
    {
      Label1.Text += "PAGE ERROR: " + ex.Message + "<br />";
      if (ex.InnerException != null)
      {
        Label1.Text += "INNER EXCEPTION: " + ex.InnerException.Message;
      }
    }
    Label1.Text += "<p />";
  }
  //------------------------------------------------------

  protected void GoButton_Click(object sender, EventArgs e)
  {
    // provides easy equivalent of typing in addresses
    // to redirect to the the selected url or path
    String destination = TransferList.SelectedValue;
    if (!destination.StartsWith(">"))
    {
      if (destination.EndsWith(".aspx"))
      {
        // no special page name so just redirect to it
        Response.Redirect(destination, true);
      }
      else
      {
        // add special page name to query string so that the Front
        // Controller will redirect to the appropriate page and view
        Response.Redirect(Request.Path + "?target=" + destination, true);
      }
    }
  }
}
