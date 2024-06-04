using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://daveandal.net/demoservices/designpatterns")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{

  [WebMethod (Description="Returns the name of the specified customer")]
  public String CustomerName(String customerID) 
  {
    // create a new DataSet instance
    DataSet ds = new DataSet();
    // populate with data from XML files
    String xmlSchemaPath = HttpContext.Current.Request.MapPath(@"~/xmldata/customers.xsd");
    String xmlFilePath = HttpContext.Current.Request.MapPath(@"~/xmldata/customers.xml");
    try
    {
      ds.ReadXmlSchema(xmlSchemaPath);
      ds.ReadXml(xmlFilePath);
      // select row(s) matching the customer ID 
      DataRow[] rows = ds.Tables[0].Select("CustomerID LIKE '" + customerID + "'");
      if (rows.Length > 0)
      {
        // return CompanyName value from first matching row
        return rows[0]["CompanyName"].ToString();
      }
      else
      {
        // cannot return Exception, so return error message instead
        return "ERROR: Customer ID " + customerID + " not found";
      }
    }
    catch (Exception ex)
    {
      // cannot return Exception, so return error message instead
      return "ERROR: " + ex.Message;
    }
  }
    
}
