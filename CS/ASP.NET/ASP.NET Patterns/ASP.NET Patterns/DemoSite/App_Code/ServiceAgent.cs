using System;
using System.Web;
using System.Web.Services;

// wraps the Web Reference and calls to Web Service
// to perform auxiliary processing
public class ServiceAgent
{
  LocalDemoService.Service svc = null;

	public ServiceAgent()
	{
    // create instance of remote Web service
    try
    {
      svc = new LocalDemoService.Service();
    }
    catch (Exception ex)
    {
      throw new Exception("Cannot create instance of remote service", ex); 
    }
	}
  //---------------------------------------

  public String GetCustomerName(String custID)
  {
    // add '*' to customer ID if required
    if (custID.Length < 5)
    {
      custID = String.Concat(custID, "*");
    }
    // call Web Service and raise a local exception
    // if an error occurs (i.e. when the returned
    // value string starts with "ERROR:")
    String custName = svc.CustomerName(custID);
    if (custName.Substring(0,6) == "ERROR:")
    {
      throw new Exception("Cannot retrieve customer name - " + custName);       
    }
    return custName;
  }
  //---------------------------------------
}
