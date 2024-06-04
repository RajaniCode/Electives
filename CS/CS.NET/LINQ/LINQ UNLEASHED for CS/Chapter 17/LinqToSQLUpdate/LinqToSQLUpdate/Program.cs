using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace LinqToSQLUpdate

{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();

      try
      {
        var changeOne = customers.Single(cust => cust.CustomerID == "PAULY");
        changeOne.ContactName = "Joe Swanson";
        
        northwind.SubmitChanges();
      }
      catch
      {
        Console.WriteLine("Nothing to do.");
      }
   }

    public class Northwind : DataContext
    {
      private static readonly string connectionString = 
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + 
        "C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\"" + 
        ";Integrated Security=True;Connect Timeout=30;User Instance=True";

      public Northwind() : base(connectionString)
      {
        Log = Console.Out;
      }

      private void UpdateCustomer(Customer obj)
      {
        this.UpdateCustomer(obj.CustomerID, obj.CompanyName, obj.ContactName, obj.ContactTitle, obj.Address, obj.City, obj.Region, obj.PostalCode, obj.Country, obj.Phone, obj.Fax);
      }

     [Function(Name="dbo.UpdateCustomer")]
		  public int UpdateCustomer(
       [Parameter(Name="CustomerID", DbType="NChar(5)")] 
        string customerID, 
       [Parameter(Name="CompanyName", DbType="NVarChar(40)")] 
        string companyName, 
       [Parameter(Name="ContactName", DbType="NVarChar(30)")] 
        string contactName, 
       [Parameter(Name="ContactTitle", DbType="NVarChar(30)")] 
        string contactTitle, 
       [Parameter(Name="Address", DbType="NVarChar(60)")] string address, 
       [Parameter(Name="City", DbType="NVarChar(15)")] string city, 
       [Parameter(Name="Region", DbType="NVarChar(15)")] string region, 
       [Parameter(Name="PostalCode", DbType="NVarChar(10)")] string postalCode, 
       [Parameter(Name="Country", DbType="NVarChar(15)")] string country, 
       [Parameter(Name="Phone", DbType="NVarChar(24)")] string phone, 
       [Parameter(Name="Fax", DbType="NVarChar(24)")] string fax)
		  {
			  IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerID, companyName, contactName, 
          contactTitle, address, city, region, postalCode, country, phone, fax);
			  return ((int)(result.ReturnValue));
		  }
    }

    [Table(Name="Customers")]
    public class Customer
    {
      [Column(IsPrimaryKey=true)]
      public string CustomerID{ get; set; }
      [Column()]
      public string CompanyName{ get; set; }
      [Column()]
      public string ContactName{ get; set; }
      [Column()]
      public string ContactTitle{ get; set; }
      [Column()]
      public string Address{ get; set; }
      [Column()]
      public string City{ get; set; }
      [Column()]
      public string Region{ get; set; }
      [Column()]
      public string PostalCode{ get; set; }
      [Column()]
      public string Country{ get; set; }
      [Column()]
      public string Phone{ get; set; }
      [Column()]
      public string Fax{ get; set; }
    }
  }
}
