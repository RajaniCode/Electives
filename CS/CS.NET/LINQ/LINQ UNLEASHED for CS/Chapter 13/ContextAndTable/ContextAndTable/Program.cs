using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Common;
using System.Reflection;

namespace ContextAndTable
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
      Table<Customer> customers = customerContext.GetTable<Customer>();

      var startsWithA = from customer in customers
                        where customer.CustomerID[0] == 'A'
                        select customer;


      customerContext.Log = Console.Out;

      Array.ForEach(startsWithA.ToArray(), c => Console.WriteLine(c));
      Console.ReadLine();
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

