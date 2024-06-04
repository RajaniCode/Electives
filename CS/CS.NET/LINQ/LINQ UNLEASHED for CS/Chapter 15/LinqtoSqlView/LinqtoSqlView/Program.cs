using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace LinqtoSqlView
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();

      var products = from product in northwind.Products
                     select product;

      string line = new string('-', 40);
      Array.ForEach(products.Take(5).ToArray(), r => 
        {
          Console.WriteLine(r);
          Console.WriteLine(line);
          Console.WriteLine();
        });

      Console.ReadLine();

    }
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" + 
      "C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" + 
      "Integrated Security=True;Connect Timeout=30;User Instance=True";

    public Northwind()
      : base(connectionString)
    {
      Log = Console.Out;
    }

    public Table<ProductList> Products
    {
      get { return this.GetTable<ProductList>(); }
    }
  }

  [Table(Name = "Alphabetical list of products")]
  public class ProductList
  {
    [Column()]
    public int ProductID { get; set; }

    [Column()]
    public string ProductName{ get; set; }

    [Column()]
    public int SupplierID { get; set; }

    [Column()]
    public int CategoryID { get; set; }

    [Column()]
    public string QuantityPerUnit { get; set; }

    [Column()]
    public decimal UnitPrice { get; set; }

    [Column()]
    public Int16 UnitsInStock { get; set; }

    [Column()]
    public Int16 UnitsOnOrder { get; set; }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      PropertyInfo[] info = this.GetType().GetProperties();

      Array.ForEach(info, i =>
      {
        Console.WriteLine("Name: {0}, Value: {1}",
          i.Name,
          i.GetValue(this, null) == null ? "none" :
          i.GetValue(this, null));
      });

      return builder.ToString();

    }
  }

}
