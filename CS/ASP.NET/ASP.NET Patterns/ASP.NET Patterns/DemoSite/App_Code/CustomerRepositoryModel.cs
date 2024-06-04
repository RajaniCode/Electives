using System;
using System.Data;
using CustomerRepositoryTableAdapters;

public class CustomerRepositoryModel
{

  public CustomerRepository.CustomersDataTable GetCustomerList()
  {
    // get details from CustomerRepository typed DataSet
    try
    {
      CustomersTableAdapter adapter = new CustomersTableAdapter();
      return adapter.GetData();
    }
    catch (Exception ex)
    {
      throw new Exception("ERROR: Cannot access typed DataSet", ex);
    }
  }
  //------------------------------------------------------

  public String GetCustomerName(String custID)
  {
    // get details from CustomerRepository typed DataSet
    try
    {
      if (custID.Length < 5)
      {
        custID = String.Concat(custID, "*");
      }
      CustomerRepository.CustomersDataTable customers = GetCustomerList();
      // select row(s) for this customer ID
      CustomerRepository.CustomersRow[] rows 
        = (CustomerRepository.CustomersRow[])customers.Select("CustomerID LIKE '" + custID + "'");
      // return the value of the CompanyName property
      return rows[0].CompanyName;
    }
    catch (Exception ex)
    {
      throw new Exception("ERROR: Cannot access typed DataSet", ex);
    }
  }
  //------------------------------------------------------
}
