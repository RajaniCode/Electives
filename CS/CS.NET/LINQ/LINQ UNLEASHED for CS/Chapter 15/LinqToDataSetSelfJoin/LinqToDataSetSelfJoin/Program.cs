using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LinqToDataSetNonEquijoin
{
  class Program
  {
    static void Main(string[] args)
    {

      const string connectionString = 
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\" + 
        "Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" + 
        "Integrated Security=True;Connect Timeout=30;User Instance=True";

      DataSet dataset = new DataSet();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(
          "SELECT * FROM PRODUCTS", connection);

        adapter.Fill(dataset);
      }

      DataTable products = dataset.Tables[0];
      
      // nonequijoin as self join
      var productsFromMultipleSuppliers =
        from product1 in products.AsEnumerable()
        from product2 in products.AsEnumerable()
        where product1.Field<string>("ProductName") ==
        product2.Field<string>("ProductName")
        && product1.Field<int>("SupplierID") !=
        product2.Field<int>("SupplierID")
        select new
        {
          ProductName = product1.Field<string>("ProductName"),
          Supplier1 = product1.Field<int>("SupplierID"),
          Supplier1Price = product1.Field<decimal>("UnitPrice"),
          Supplier2 = product2.Field<int>("SupplierID"),
          Supplier2Price = product1.Field<decimal>("UnitPrice")
        };

      Array.ForEach(productsFromMultipleSuppliers.ToArray(), r =>
        {
          Console.WriteLine("Product: {0}", r.ProductName);
          Console.WriteLine("Supplier 1: {0}", r.Supplier1);
          Console.WriteLine("Supplier 1 Price: {0}", r.Supplier1Price);
          Console.WriteLine("Supplier 2: {0}", r.Supplier2);
          Console.WriteLine("Supplier 2 Price: {0}", r.Supplier2Price);
          Console.WriteLine();
        });

      Console.ReadLine();

    }
  }
}
