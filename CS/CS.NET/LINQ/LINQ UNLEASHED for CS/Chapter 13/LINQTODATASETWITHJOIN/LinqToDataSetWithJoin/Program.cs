using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LinqToDataSetWithJoin
{
  class Program
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;" + 
      "Integrated Security=True";

    static void Main(string[] args)
    {
      const string sql = "SELECT * FROM Orders;" + 
        "SELECT * FROM [Order Details];";

      DataSet data = new DataSet();
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = 
          new SqlCommand(sql, connection);
        command.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(data);
      }

      DataTable orders = data.Tables[0];
      DataTable orderDetails = data.Tables[1];

      var orderResults = 
        from order in orders.AsEnumerable()
        join detail in orderDetails.AsEnumerable()
        on order.Field<int>("OrderID") 
        equals detail.Field<int>("OrderID")
        select new { 
          OrderID=order.Field<int>("OrderID"),
          CustomerID=order.Field<string>("CustomerID"),
          ProductID=detail.Field<int>("ProductID"),
          UnitPrice=detail.Field<decimal>("UnitPrice"),
          Quantity=detail.Field<Int16>("Quantity"),
          Discount=detail.Field<float>("Discount")};

      Console.WriteLine("Orders & Details");
      foreach(var result in orderResults)
      {
        Console.WriteLine("Order ID: {0}", result.OrderID);
        Console.WriteLine("Customer ID: {0}", result.CustomerID);
        Console.WriteLine("Product ID: {0}", result.ProductID);
        Console.WriteLine("Unit Price: {0}", result.UnitPrice);
        Console.WriteLine("Quantity: {0}", result.Quantity);
        Console.WriteLine("Discount: {0}", result.Discount);
        Console.WriteLine();
      }

      Console.ReadLine();
    }
  }
}

