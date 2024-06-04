using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Xml.Linq;
using System.Data.Linq.Mapping;

public class XmlData
{
  public static XDocument GetData()
  {
    Northwind northwind = new Northwind();

    XDocument xml = new XDocument(
     new XComment("First 3 Customers Starting with 'C'"),
     new XElement("Customers",
     (from cust in northwind.Customers
      where cust.CompanyName.StartsWith("C")
      orderby cust.CompanyName
      select new XElement("Customer",
        new XElement("CustomerID", cust.CustomerID),
        new XElement("CompanyName", cust.CompanyName),
        new XElement("ContactTitle", cust.ContactTitle),
        new XElement("ContactName", cust.ContactName),
        new XElement("Address", cust.Address),
        new XElement("City", cust.City),
        new XElement("Region", cust.Region),
        new XElement("PostalCode", cust.PostalCode),
        new XElement("Country", cust.Country),
        new XElement("Phone", cust.Phone),
        new XElement("Fax", cust.Fax))).Take(3)));

    return xml;
  }
}

public class Northwind : DataContext
{
  private static readonly string connectionString = 
    "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + 
    "\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\"" + 
    ";Integrated Security=True;Connect Timeout=30;User Instance=True";

  public Northwind() : base(connectionString){}

  public Table<Customer> Customers
  {
    get{ return this.GetTable<Customer>(); }
  }
}

[Table(Name="Customers")]
public class Customer
{
  [Column()]
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


