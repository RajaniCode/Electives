using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace ContextAndTableExpanded
{

  class Program
  {

    private static readonly string connectionString = 
      @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + 
      "\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" + 
      "Integrated Security=True;Connect Timeout=30;User Instance=True";

    static void Main(string[] args)
    {
      DataContext customerContext = new DataContext(connectionString);
      Table<Customers> customers = customerContext.GetTable<Customers>();

      customerContext.Log = Console.Out;

      var startsWithA = from customer in customers
                        where customer.CustomerID[0] == 'A'
                        select customer;



      Array.ForEach(startsWithA.ToArray(), c => Console.WriteLine(c.CompanyName));
      Console.ReadLine();
    }
  }

  [Table(Name="Customers")]
  public class Customers
  {
    private string customerID;
    private string companyName;
    private string contactName;
    private string contactTitle;
    private string address;
    private string city;
    private string region;
    private string postalCode;
    private string country;
    private string phone;
    private string fax;

    
    [Column(Name="CustomerID", Storage="customerID", 
      DbType="NChar(5)", CanBeNull=false)]
    public string CustomerID
    {
      get { return customerID; }
      set { customerID = value; }
    }

    [Column(Name="CompanyName", Storage="companyName", 
      DbType="NVarChar(40)", CanBeNull=true)]
    public string CompanyName
    {
      get { return companyName; }
      set { companyName = value; }
    }

    [Column(Name="ContactName", Storage="contactName", 
      DbType="NVarChar(30)")]
    public string ContactName
    {
      get { return contactName; }
      set { contactName = value; } 
    }

    [Column(Name="ContactTitle", Storage="contactTitle",
      DbType = "NVarChar(30)")]
    public string ContactTitle
    {
      get { return contactTitle; }
      set { contactTitle = value; }
    }

    [Column(Name="Address", Storage="address",
      DbType = "NVarChar(60)")]
    public string Address
    {
      get { return address; }
      set { address = value; }
    }

    [Column(Name="City", Storage="city",
      DbType = "NVarChar(15)")]
    public string City
    {
      get { return city; }
      set { city = value; }
    }

    [Column(Name = "Region", Storage = "region", DbType = "NVarChar(15)")]
    public string Region
    {
      get { return region; }
      set { region = value; }
    }

    [Column(Name="PostalCode", Storage="postalCode",
      DbType = "NVarChar(10)")]
    public string PostalCode
    {
      get { return postalCode; }
      set { postalCode = value; }
    }

    [Column(Name = "Country", Storage = "country", DbType = "NVarChar(15)")]
    public string Country
    {
      get { return country; }
      set { country = value; }
    }

    [Column(Name = "Phone", Storage = "phone", DbType = "NVarChar(24)")]
    public string Phone
    {
      get { return phone; }
      set { phone = value; }
    }

    [Column(Name = "Fax", Storage = "fax", DbType = "NVarChar(24)")]
    public string Fax
    {
      get { return fax; }
      set { fax = value; }
    }
    
    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      PropertyInfo[] props = this.GetType().GetProperties();

      // using array for each
      Array.ForEach(props.ToArray(), prop =>
        builder.AppendFormat("{0} : {1}", prop.Name,
          prop.GetValue(this, null) == null ? "<empty>\n" :
          prop.GetValue(this, null).ToString() + "\n"));

      return builder.ToString();
    }

  }

}

