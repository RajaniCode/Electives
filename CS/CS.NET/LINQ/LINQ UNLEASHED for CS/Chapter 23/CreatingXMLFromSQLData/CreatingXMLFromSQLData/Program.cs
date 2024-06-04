using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Xml.Linq;
using System.Data.Linq.Mapping;

namespace CreatingXMLFromSQLData
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();

      XDocument xml = new XDocument(
        new XComment("First 3 Customers Starting with 'C'"),
        new XElement("Customers", 
        (from cust in northwind.Customers
          where cust.CompanyName.StartsWith("C")
          orderby cust.CompanyName
          select new XElement("Customer", 
            new XAttribute("CustomerID", cust.CustomerID),
            cust.CompanyName, 
            new XElement("ContactName", 
              new XAttribute("ContactTitle", cust.ContactTitle),
              cust.ContactName),
            new XElement("Address", 
              new XElement("Street", cust.Address),
              new XElement("City", cust.City),
              new XElement("Region", cust.Region),
              new XElement("PostalCode", cust.PostalCode),
              new XElement("Country", cust.Country)),
            new XElement("Phones", 
              new XElement("Phone", 
                new XAttribute("Type", "Primary"),
                cust.Phone),
              new XElement("Phone",
                new XAttribute("Type", "Fax"),
                cust.Fax)))).Take(3)));

      
      Console.WriteLine(xml.ToString());
      Console.ReadLine();
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
  }
}
