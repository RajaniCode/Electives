using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Xml.Linq;
using System.Data.Linq.Mapping;

namespace UpdateSQLFromXML
{
  class Program
  {
    static void Main(string[] args)
    {
      XElement xml = XElement.Load("..\\..\\DataToUpdate.xml");
      Northwind northwind = new Northwind();

      foreach (XElement elem in xml.Elements("Customer"))
      {
        Customer cust = new Customer();
        cust.CustomerID = elem.Element("CustomerID").Value;
        cust.CompanyName = elem.Element("CompanyName").Value;
        cust.ContactTitle = elem.Element("ContactTitle").Value;
        cust.ContactName = elem.Element("ContactName").Value;
        cust.Address = elem.Element("Address").Value;
        cust.City = elem.Element("City").Value;
        cust.Region = elem.Element("Region").Value;
        cust.PostalCode = elem.Element("PostalCode").Value;
        cust.Country = elem.Element("Country").Value;
        cust.Phone = elem.Element("Phone").Value;
        cust.Fax = elem.Element("Fax").Value;

        northwind.Customers.InsertOnSubmit(cust);
        northwind.SubmitChanges();

      }

    }

    public class Northwind : DataContext
    {
      private static readonly string connectionString =
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=" +
        "\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\"" +
        ";Integrated Security=True;Connect Timeout=30;User Instance=True";

      public Northwind() : base(connectionString) { }

      public Table<Customer> Customers
      {
        get { return this.GetTable<Customer>(); }
      }
    }

    [Table(Name = "Customers")]
    public class Customer
    {
      [Column(IsPrimaryKey=true)]
      public string CustomerID { get; set; }
      [Column()]
      public string CompanyName { get; set; }
      [Column()]
      public string ContactName { get; set; }
      [Column()]
      public string ContactTitle { get; set; }
      [Column()]
      public string Address { get; set; }
      [Column()]
      public string City { get; set; }
      [Column()]
      public string Region { get; set; }
      [Column()]
      public string PostalCode { get; set; }
      [Column()]
      public string Country { get; set; }
      [Column()]
      public string Phone { get; set; }
      [Column()]
      public string Fax { get; set; }
    }

  }
}


