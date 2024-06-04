using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GroupIntoDemo
{
  class Program
  {
    // set up a typical SQL join
    static string sql =
      "SELECT Categories.CategoryName, Products.ProductID, " +
      "Products.ProductName, Products.UnitsInStock, Products.UnitPrice " +
      "FROM Categories INNER JOIN " +
      "Products ON Categories.CategoryID = Products.CategoryID";

    // use the default northwind connection string
    static string connectionString =
      "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
      //"Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    // define a simple class using automatic properties
    public class ProductItem
    {
      public string CategoryName { get; set; }
      public int ProductID { get; set; }
      public string ProductName { get; set; }
      public int UnitsInStock { get; set; }
      public decimal UnitPrice { get; set; }

      public override string ToString()
      {
        const string mask =
          "Category Name: {0}, " +
          "Product ID: {1}, " +
          "Product Name: {2}, " +
          "Units In Stock: {3}, " +
          "Unit Price: {4}";

        return string.Format(mask, CategoryName,
          ProductID, ProductName, UnitsInStock,
          UnitPrice);
      }
    }

    // a read helper
    static T SafeRead<T>(IDataReader reader, string name, T defaultValue)
    {
      object o = reader[name];
      if (o != System.DBNull.Value && o != null)
        return (T)Convert.ChangeType(o, defaultValue.GetType());

      return defaultValue;
    }

    static void Main(string[] args)
    {
      List<ProductItem> products = new List<ProductItem>();

      // read all of the data into custom objects
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          products.Add(new ProductItem
          {
            CategoryName = SafeRead(reader, "CategoryName", ""),
            ProductID = SafeRead(reader, "ProductID", -1),
            ProductName = SafeRead(reader, "ProductName", ""),
            UnitsInStock = SafeRead(reader, "UnitsInStock", 0),
            UnitPrice = SafeRead(reader, "UnitPrice", 0M)
          });
        }
      }

      // make sure I have some data
      Array.ForEach(products.ToArray(), y => Console.WriteLine(y));
      Console.ReadLine();

      Console.Clear();
      string line = new string('-', 40);

      // define the LINQ group
      var grouped = from p in products
                    orderby p.CategoryName, p.ProductName
                    group p by p.CategoryName into grp
                    select new { Category = grp.Key, Product = grp };

      // dump each group
      Array.ForEach(grouped.ToArray(), g =>
      {
        Console.WriteLine(g.Category);
        Console.WriteLine(line);
        // dump each product in the group
        Array.ForEach(g.Product.ToArray(), p =>
            Console.WriteLine(p));
        Console.WriteLine(Environment.NewLine);
      });

      Console.ReadLine();

    }
  }
}
