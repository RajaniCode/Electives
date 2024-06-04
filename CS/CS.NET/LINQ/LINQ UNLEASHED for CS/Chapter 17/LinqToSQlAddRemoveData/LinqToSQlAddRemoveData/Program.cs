using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSQlAddRemoveData
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();

      // insert a new customer
      Customer customer = new Customer();
      customer.CustomerID = "DUSTY";
      customer.CompanyName = "Dusty's Cellars";
      customer.ContactName = "Dena Swanson";
      customer.ContactTitle = "Catering Manager";
      customer.Address = "1839 Grand River Avenue";
      customer.City = "Okemos";
      customer.Region = "MI";
      customer.PostalCode = "48864";
      customer.Country = "US";
      customer.Phone = "(517) 349-5150";
      customer.Fax = "(517) 349-8416";

      customers.InsertOnSubmit(customer);

      northwind.SubmitChanges();
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
