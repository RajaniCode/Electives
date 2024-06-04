using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace NonEquijoin
{

  class Program
  {

    static void Main()
    {
      const string connectionString = 
        //"Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

        "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"" +
        "C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" +
        "Integrated Security=True;Connect Timeout=30;User Instance=True";

      const string SQL = "SELECT * FROM PRODUCTS; SELECT * FROM SUPPLIERS";
      List<Product> products = new List<Product>();
      List<Supplier> suppliers = new List<Supplier>();

      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(SQL, connection);
        IDataReader reader = command.ExecuteReader();
        products = reader.ReadProducts();

        if(reader.NextResult())
          suppliers = reader.ReadSuppliers();

      }

      var nonEquiJoin = 
        from p in products
          let master = from s in suppliers select s.SupplierID
          where master.Contains(p.SupplierID)
          orderby p.SupplierID
          select new {SupplierID=p.SupplierID, ProductName = p.ProductName};

      Array.ForEach(nonEquiJoin.ToArray(), target=>Console.WriteLine(
        "Supplier ID={0,4}, Product={1}", 
        target.SupplierID, target.ProductName
        ));
      Console.ReadLine();
    }
  }

  public class Product
  {
    public int? ProductID{ get; set; }
    public string ProductName{ get; set; }
    public int? SupplierID{ get; set; }
    public int? CategoryID{ get; set; }
    public string QuantityPerUnit{ get; set; }
    public decimal? UnitPrice{ get; set; }
    public int? UnitsInStock{ get; set; }
    public int? UnitsOnOrder{ get; set; }
    public int? ReorderLevel{ get; set; }
    public bool? Discontinued{ get; set; }
	}

  public class Supplier
  {
    public int? SupplierID{ get; set; }
    public string CompanyName{ get; set; }
    public string ContactName{ get; set; }
    public string ContactTitle{ get; set; }
    public string Address{ get; set; }
    public string City{ get; set; }
    public string Region{ get; set; }
    public string PostalCode{ get; set; }
    public string Country{ get; set; }
    public string Phone{ get; set; }
    public string Fax{ get; set; }
    public string HomePage{ get; set; }
  }
  
  public static class ExtendsReader
  {
    public static List<Product> ReadProducts(this IDataReader reader)
    {

      List<Product> list = new List<Product>();
      while (reader.Read())
      {
        Product o = new Product();
        o.ProductID = reader.GetInt32(0);
        o.ProductName = reader.GetString(1);
        o.SupplierID = reader.GetInt32(2);
        o.CategoryID = reader.GetInt32(3);
        o.QuantityPerUnit = reader.GetString(4);
        o.UnitPrice = reader.GetDecimal(5);
        o.UnitsInStock = reader.GetInt16(6);
        o.UnitsOnOrder = reader.GetInt16(7);
        o.ReorderLevel = reader.GetInt16(8);
        o.Discontinued = reader.GetBoolean(9);
        list.Add(o);
      }

      return list;
    }

    public static List<Supplier> ReadSuppliers(this IDataReader reader)
    {
      List<Supplier> list = new List<Supplier>();
      while(reader.Read())
      {
        Supplier o = new Supplier();
        o.SupplierID = reader.GetInt32(0);
        o.CompanyName = reader.GetString(1);
        o.ContactName = reader.GetString(2);
        o.ContactTitle = reader.GetString(3);
        o.Address = reader.GetString(4);
        o.City = reader.GetString(5);
        o.Region = reader["Region"] == 
          System.DBNull.Value ? "" : reader.GetString(6);
        o.PostalCode = reader.GetString(7);
        o.Country = reader.GetString(8);
        o.Phone = reader.GetString(9);
        o.Fax = reader["Fax"] == 
          System.DBNull.Value ? "" : reader.GetString(10);
        o.HomePage = reader["HomePage"] == System.DBNull.Value ?
          "" : reader.GetString(11);

        list.Add(o);
      }

      return list;
    }
  }
}

