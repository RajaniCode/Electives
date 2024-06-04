using System;
using System.Data;
using System.IO;
using System.Collections;
using System.Web;

public class CustomerModel
{
  private static DataSet ds;
  // --------------------------------------------
  
  public CustomerModel()
	{ 
    // create a new DataSet instance
    ds = new DataSet();
    // populate with data from XML files
    String xmlSchemaPath = HttpContext.Current.Request.MapPath(@"~/xmldata/customers.xsd");
    String xmlFilePath = HttpContext.Current.Request.MapPath(@"~/xmldata/customers.xml");
    try
    {
      ds.ReadXmlSchema(xmlSchemaPath);
      ds.ReadXml(xmlFilePath);
    }
    catch (Exception ex)
    {
      throw new Exception("CustomerModel: Cannot load customer list", ex);
    }
	}
  // --------------------------------------------

  public DataTable GetCustomerList()
  {
    // return list of customers from DataSet
    return ds.Tables[0];
  }
  // --------------------------------------------
  
  public String GetCustomerName(String customerID)
  {
    // return just the company name for the specified customer ID
    DataRow[] rows = ds.Tables[0].Select("CustomerID LIKE '" + customerID + "'");
    return rows[0]["CompanyName"].ToString();
  }
  // --------------------------------------------
  
  public DataRow[] GetCustomerDetails(String customerID)
  {
    // return row(s) from DataSet table for specified customer ID
    return ds.Tables[0].Select("CustomerID = '" + customerID + "'");
  }
  // --------------------------------------------
 
  public SortedList GetCityList()
  {
    // create a list of cities and number of customers in each one
    SortedList cities = new SortedList();
    // iterate through the DataSet table
    foreach (DataRow row in ds.Tables[0].Rows)
    {
      // get name of city
      String city = row["City"].ToString();
      // if already in list, increment count
      if (cities.Contains(city))
      {
        cities[city] = (Int32)cities[city] + 1;
      }
      else
      {
        // add new item to list with count = 1
        cities.Add(city, 1);
      }
    }
    return cities;
  }

  // --------------------------------------------
  public Int32 GetCityCount()
  {
    // get count of number of different cities
    SortedList cities = GetCityList();
    return cities.Count;
  }
  // --------------------------------------------
}

