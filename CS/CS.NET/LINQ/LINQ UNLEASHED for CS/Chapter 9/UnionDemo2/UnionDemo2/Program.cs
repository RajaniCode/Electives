using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;

namespace UnionDemo2
{
  class Program
  {
    /// <summary>
    /// Demonstrates except ship city
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      List<Order> orders = GetOrders();
      Console.WriteLine(orders.Count);

      var citiesInMexico = from order in orders
                           where order.ShipCountry == "Mexico"
                           select order;
      var citiesinNewMexico = from order in orders
                              where order.ShipRegion == "NM"
                              || order.ShipRegion == "TX"
                              select order;

      var territory = citiesInMexico.Union(citiesinNewMexico);

      Array.ForEach(territory.ToArray(), 
        input => Console.WriteLine(Dump(input)));

      Console.ReadLine();
    }

    

    public static string Dump<T>(T obj)
    {
      Type t = typeof(T);
      StringBuilder builder = new StringBuilder();

      PropertyInfo[] infos = t.GetProperties();

      // feel the enmity of your peers if you write code like this
      Array.ForEach( infos.ToArray(), p => builder.AppendFormat(
        "{0}={1} ", p.Name, p.GetValue(obj, null) == null ? "" : 
        p.GetValue(obj, null)));
      builder.AppendLine();

      return builder.ToString();

    }

    public static List<Order> GetOrders()
    {
      string connectionString = 
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Books\\Addison Wesley" + 
        "\\LINQ\\Northwind\\northwnd.mdf\";Integrated Security=True;Connect " + 
        "Timeout=30;User Instance=True";

      List<Order> orders = new List<Order>();

      using(IDbConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        IDbCommand command = new SqlCommand("SELECT * FROM Orders");
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        IDataReader reader = command.ExecuteReader();
        while(reader.Read())
        {
          orders.Add(new Order
          {
            OrderID = reader.IsDBNull(0) ? null : (int?)reader.GetInt32(0),
            CustomerID = reader.IsDBNull(1) ? null : reader.GetString(1),
            EmployeeID = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),
            OrderDate = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(3),
            RequiredDate = reader.IsDBNull(4) ? null : (DateTime?)reader.GetDateTime(4),
            ShippedDate = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5),
            ShipVia = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6),
            Freight = reader.IsDBNull(7) ? null : (decimal?)reader.GetDecimal(7),
            ShipName = reader.IsDBNull(8) ? null : reader.GetString(8),
            ShipAddress = reader.IsDBNull(9) ? null : reader.GetString(9),
            ShipCity = reader.IsDBNull(10) ? null : reader.GetString(10),
            ShipRegion = reader.IsDBNull(11) ? null : reader.GetString(11),
            ShipPostalCode = reader.IsDBNull(12) ? null : reader.GetString(12),
            ShipCountry = reader.IsDBNull(13) ? null : reader.GetString(13),
          }
          );
      	}
      }

      return orders;
    }
  }

  class CityComparer : IEqualityComparer<Order>
  {
    #region IEqualityComparer<Order> Members

    public bool Equals(Order x, Order y)
    {
      return x.ShipCity == null || y.ShipCity == null ? 
        false : x.ShipCity.Equals(y.ShipCity);
    }

    public int GetHashCode(Order obj)
    {
      return obj.ShipCity == null ? -1 : obj.ShipCity.GetHashCode();
    }

    #endregion
  }

  class Order 
  {
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
  }

}
