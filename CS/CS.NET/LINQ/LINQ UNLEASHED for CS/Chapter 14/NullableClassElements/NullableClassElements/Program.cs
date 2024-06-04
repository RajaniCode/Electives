using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;


namespace NullableClassElements
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Order> orders = northwind.GetTable<Order>();

      northwind.Log = Console.Out;
      Array.ForEach(orders.ToArray(), t=>Console.WriteLine(t));
      Console.ReadLine();
    }
  }

  [Database(Name = "Northwind")]
  public class Northwind : DataContext
  {

    private static readonly string connectionString =
      @"Data Source=.\SQLEXPRESS;AttachDbFilename=" +
      "\"C:\\Books\\Addison Wesley\\LINQ\\Northwind\\northwnd.mdf\";" +
      "Integrated Security=True;Connect Timeout=30;User Instance=True";

    public Northwind() : base(connectionString) { }
  }

  [Table(Name="Orders")]
  public class Order
  {
    [Column(IsPrimaryKey=true)]
    public int OrderID{get; set;}

    [Column()]
    public string CustomerID{get; set;}
    
    [Column(CanBeNull=true)]
    public int? EmployeeID{get; set;}

    [Column(CanBeNull = true)]
    public Nullable<DateTime> OrderDate{get; set;}

    [Column(CanBeNull = true)]
    public DateTime? RequiredDate{get; set;}

    [Column(CanBeNull = true)]
    public DateTime? ShippedDate{get; set;}

    [Column(CanBeNull = true)]
    public int? ShipVia{get; set;}

    [Column(CanBeNull = true)]
    public decimal? Freight{get; set;}

    [Column(CanBeNull = true)]
    public string ShipName{get; set;}

    [Column(CanBeNull = true)]
    public string ShipAddress{get; set;}

    [Column(CanBeNull = true)]
    public string ShipCity{get; set;}

    [Column(CanBeNull = true)]
    public string ShipRegion{get; set;}

    [Column(CanBeNull = true)]
    public string ShipPostalCode{get; set;}

    [Column(CanBeNull = true)]
    public string ShipCountry{get; set;}

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      PropertyInfo[] props = this.GetType().GetProperties();

      // using array for each
      Array.ForEach(props.ToArray(), prop =>
        builder.AppendFormat("{0} : {1}", prop.Name,
          prop.GetValue(this, null) == null ? "<empty>\n" :
          prop.GetValue(this, null).ToString() + "\n"));

      return builder.ToString();
    }
  }
}

