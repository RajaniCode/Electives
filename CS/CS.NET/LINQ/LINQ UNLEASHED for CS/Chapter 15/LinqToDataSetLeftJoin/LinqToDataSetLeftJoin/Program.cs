using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LinqToDataSetLeftJoin
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
      
      var customersWithoutOrders = from customer in customers.AsEnumerable()
                      join order in orders.AsEnumerable()
                      on customer.Field<string>("CustomerID") equals
                      order.Field<string>("CustomerID") into children
                      from child in children.DefaultIfEmpty(orders.NewRow())
                      let OrderID = child.Field<int?>("OrderID")
                      where OrderID == 11080
                     select new
                     {
                       Company=customer.Field<string>("CompanyName"),
                       City=customer.Field<string>("City"),
                       Phone=customer.Field<string>("Phone"),
                       OrderID=child.Field<int?>("OrderID"),
                       OrderDate=child.Field<DateTime?>("OrderDate"),
                       RequiredDate=child.Field<DateTime?>("RequiredDate"),
                       ShipCity=child.Field<string>("ShipCity")
                     };

      string line = new string('-', 40);
      foreach(var item in customersWithoutOrders)
      {
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

