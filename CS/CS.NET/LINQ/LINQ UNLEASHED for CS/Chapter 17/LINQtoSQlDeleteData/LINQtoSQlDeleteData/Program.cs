using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQtoSQlDeleteData
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();

      try
      {
        var remove = customers.Single(cust => cust.CustomerID == "DUSTY");
        customers.DeleteOnSubmit(remove);
        
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
