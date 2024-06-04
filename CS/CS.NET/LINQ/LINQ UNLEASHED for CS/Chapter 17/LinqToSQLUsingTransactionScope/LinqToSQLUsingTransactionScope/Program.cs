using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Transactions;

namespace LinqToSQLUsingTransactionScope
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();
      Table<Order> orders = northwind.GetTable<Order>();


      using (TransactionScope scope = new TransactionScope())
      {

        var removeCustomers = from customer in customers
                              where customer.CustomerID.ToString().ToUpper() == "PAUL1"
                              select customer;

        var removeOrders = from order in orders
                           where order.CustomerID.ToString().ToUpper() == "PAUL1"
                           select order;

        if (removeOrders.Any())
        {
          orders.DeleteAllOnSubmit(removeOrders);
          northwind.SubmitChanges();
        }

        customers.DeleteAllOnSubmit(removeCustomers);
        northwind.SubmitChanges();

        scope.Complete();
      }
    }

    public class Northwind : DataContext
    {
      private static readonly string connectionString =
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" +
        "C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\"" +
        ";Integrated Security=True;Connect Timeout=30;User Instance=True";

      public Northwind()
        : base(connectionString)
      {
        Log = Console.Out;
      }
    }

    [Table(Name = "Customers")]
    public class Customer
    {
      [Column(IsPrimaryKey = true)]
      public string CustomerID { get; set; }
    }

   [Table(Name = "Orders")]
    public class Order
    {
      [Column(IsPrimaryKey = true)]
      public int OrderID { get; set; }
      [Column()]
      public string CustomerID { get; set; }
    }
  }
}
