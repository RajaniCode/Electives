using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LinqToDatasetRightJoin
{
  class Program
  {
    static void Main(string[] args)
    {
      const string connectionString = 
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + 
        "\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" + 
        ";Integrated Security=True;Connect Timeout=30;User Instance=True";

      DataSet dataset = new DataSet();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        const string SQL = "SELECT * FROM CUSTOMERS;SELECT * FROM ORDERS"; 
        SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection);
        adapter.Fill(dataset);
      }

      DataTable customers = dataset.Tables[0];
      DataTable orders = dataset.Tables[1];

      var orphanedOrders = from order in orders.AsEnumerable()
                           join customer in customers.AsEnumerable()
                           on order.Field<string>("CustomerID") equals
                           customer.Field<string>("CustomerID") 
                           into parent 
                           from p in parent.DefaultIfEmpty(customers.NewRow())
                           select new
                           {
                            CustomerID = p.Field<string>("CustomerID"),
                            Company = p.Field<string>("CompanyName"),
                            City = p.Field<string>("City"),
                            Phone = p.Field<string>("Phone"),
                            OrderID = order.Field<int?>("OrderID"),
                            OrderDate = order.Field<DateTime?>("OrderDate"),
                            RequiredDate = order.Field<DateTime?>("RequiredDate"),
                            ShipCity = order.Field<string>("ShipCity")
                          };

      string line = new string('-', 40);
      foreach (var item in orphanedOrders)
      {
        Console.WriteLine("Customer ID: {0}", item.CustomerID);
        Console.WriteLine("Company: {0}", item.Company);
        Console.WriteLine("City: {0}", item.City);
        Console.WriteLine("Phone: {0}", item.Phone);
        Console.WriteLine("Order ID: {0}", item.OrderID);
        Console.WriteLine("Order Date: {0}", item.OrderDate);
        Console.WriteLine("Required Date: {0}", item.RequiredDate);
        Console.WriteLine("Ship to: {0}", item.ShipCity);
        Console.WriteLine(line);
        Console.WriteLine();
      }

      Console.ReadLine();
    }
  }
}

