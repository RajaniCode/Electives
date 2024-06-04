using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace GenericExtensionMethods
{
  class Program
  {
    static void Main(string[] args)
    {
      string connectionString = "Data Source=CASPAR;Initial Catalog=Northwind;Integrated Security=True";
      // create the list of orders
      List<Order> orders = new List<Order>();

      // open an dprotect the connection
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        // prepare to select all orders
        SqlCommand command = new SqlCommand("SELECT * FROM ORDERS", connection);
        command.CommandType = CommandType.Text;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        // read all orders
        while(reader.Read())
        {
          Order order = new Order();
          // the exension method does the leg work but it looks like order
          // is self-initializing
          order.Read(reader);
          orders.Add(order);    
        }
      }

      // use the dumper to send everything to the console
      orders.Dump(Console.Out);
      Console.ReadLine();
    }
  }

  public static class ReaderHelper
  {
    public static void Read(this Order order, IDataReader reader)
    {
      order.OrderID = order.SafeRead(reader, "OrderID", -1);
      order.CustomerID = order.SafeRead(reader, "CustomerID", "");
    }

    /// <summary>
    /// One reader checks for all the null possibilities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="reader"></param>
    /// <param name="fieldName"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static T SafeRead<T>(this EntityClass entity, 
      IDataReader reader, string fieldName, T defaultValue)
    {
      try
      {
        object o = reader[fieldName];
        if(o == null || o == System.DBNull.Value)
          return defaultValue;

        return (T)Convert.ChangeType(o, defaultValue.GetType());
      }
      catch
      {
        return defaultValue;
      }
    }
  }

    public static class Dumper
  {
    public static void Dump(this Object o, TextWriter writer)
    {
      PropertyInfo[] properties = o.GetType().GetProperties();
      foreach(PropertyInfo p in properties)
      {
        try
        {
          writer.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            p.GetValue(o, null)));
        }
        catch
        {
          writer.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            "unk."));
        }
      }
    }

    public static void Dump<T>(this IList<T> list, TextWriter writer)
    {
      foreach(object o in list)
        o.Dump(writer);
    }
  }


  public class EntityClass{}

  public class Order : EntityClass
  {

    /// <summary>
    /// Initializes a new instance of the Order class.
    /// </summary>
    public Order()
    {
    }

    private int orderID;
    public int OrderID
    {
      get
      {
        return orderID;
      }
      set
      {
        orderID = value;
      }
    }

    private string customerID;
    public string CustomerID
    {
      get
      {
        return customerID;
      }
      set
      {
        customerID = value;
      }
    }
  }

}
