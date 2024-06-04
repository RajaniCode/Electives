using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LinqToDataSetEquijoin
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
        const string SQL = "SELECT * FROM Products;SELECT * FROM SUPPLIERS"; 
        SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection);
        adapter.Fill(dataset);
      }

      DataTable products = dataset.Tables[0];
      DataTable suppliers = dataset.Tables[1];
      
      var inventory = from product in products.AsEnumerable()
                     join supplier in suppliers.AsEnumerable()
                     on product.Field<int>("SupplierID") 
                     equals supplier.Field<int>("SupplierID")
                     orderby product.Field<string>("ProductName")
                     select new
                     {
                       Company=supplier.Field<string>("CompanyName"),
                       City=supplier.Field<string>("City"),
                       Phone=supplier.Field<string>("Phone"),
                       Product=product.Field<string>("ProductName"),
                       Price=product.Field<decimal>("UnitPrice"),
                       InStock=product.Field<Int16>("UnitsInStock"),
                       Discontinued=product.Field<bool>("Discontinued")
                     };

      string line = new string('-', 40);
      foreach(var item in inventory)
      {
        Console.WriteLine("Company: {0}", item.Company);
        Console.WriteLine("City: {0}", item.City);
        Console.WriteLine("Phone: {0}", item.Phone);
        Console.WriteLine("Product: {0}", item.Product);
        Console.WriteLine("Price: {0:C}", item.Price);
        Console.WriteLine("Quantity on hand: {0}", item.InStock);
        Console.WriteLine("Discontinued: {0}", item.Discontinued);
        Console.WriteLine(line);
        Console.WriteLine();
      }

      Console.ReadLine();
    }
  }
}

