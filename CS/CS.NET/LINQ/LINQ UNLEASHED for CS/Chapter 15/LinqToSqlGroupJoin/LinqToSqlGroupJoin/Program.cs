using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSqlGroupJoin
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();

      var orderInformation = from order in northwind.Orders
                             join detail in northwind.Details
                             on order.OrderID equals detail.OrderID
                             into children
                             select new
                             {
                               CustomerID = order.CustomerID,
                               OrderDate = order.OrderDate,
                               RequiredDate = order.RequiredDate,
                               Details = children
                             };



      string line = new string('-', 40);
      Array.ForEach(orderInformation.ToArray(), r =>
        {
          Console.WriteLine("Customer ID: {0}", r.CustomerID);
          Console.WriteLine("Order Date: {0}", r.OrderDate
            .GetValueOrDefault().ToShortDateString());
          Console.WriteLine("Required Date: {0}", r.RequiredDate
            .GetValueOrDefault().ToShortDateString());

          Console.WriteLine("---------Order Details---------");
          Array.ForEach(r.Details.ToArray(), d =>
            {
              Console.WriteLine("Product ID: {0}", d.ProductID);
              Console.WriteLine("Unit Price: {0}", d.UnitPrice);
              Console.WriteLine("Quantity: {0}", d.Quantity);
              Console.WriteLine();

            });

          Console.WriteLine(line);
          Console.WriteLine();
        });


      Console.ReadLine();
    }
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString =
      "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Books\\Addison Wesley\\" + 
      "LINQ\\Northwind\\northwnd.mdf\";" + 
      "Integrated Security=True;Connect Timeout=30;User Instance=True";

      //"Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\temp\\northwnd.mdf;" +
      //"Integrated Security=True;Connect Timeout=30;User Instance=True";

    public Northwind()
      : base(connectionString)
    {
      Log = Console.Out;
    }


    public Table<Order> Orders
    {
      get{ return this.GetTable<Order>(); }
    }

    public Table<OrderDetail> Details
    {
      get{ return GetTable<OrderDetail>(); }
    }
  }


  [Table(Name = "dbo.Order Details")]
  public partial class OrderDetail 
  {

    private int _OrderID;

    private int _ProductID;

    private decimal _UnitPrice;

    private short _Quantity;

    private float _Discount;


    public OrderDetail()
    {
    }

    [Column(Storage = "_OrderID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
      set
      {
        this._OrderID = value;
      }
    }

    [Column(Storage = "_ProductID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
    public int ProductID
    {
      get
      {
        return this._ProductID;
      }
      set
      {
        this._ProductID = value;
      }
    }

    [Column(Storage = "_UnitPrice", DbType = "Money NOT NULL")]
    public decimal UnitPrice
    {
      get
      {
        return this._UnitPrice;
      }
      set
      {
        this._UnitPrice = value;
      }
    }

    [Column(Storage = "_Quantity", DbType = "SmallInt NOT NULL")]
    public short Quantity
    {
      get
      {
        return this._Quantity;
      }
      set
      {
        this._Quantity = value;
      }
    }

    [Column(Storage = "_Discount", DbType = "Real NOT NULL")]
    public float Discount
    {
      get
      {
        return this._Discount;
      }
      set
      {
        this._Discount = value;
      }
    }
  }

  [Table(Name = "dbo.Orders")]
  public partial class Order 
  {

    private int _OrderID;

    private string _CustomerID;

    private System.Nullable<int> _EmployeeID;

    private System.Nullable<System.DateTime> _OrderDate;

    private System.Nullable<System.DateTime> _RequiredDate;

    private System.Nullable<System.DateTime> _ShippedDate;

    private System.Nullable<int> _ShipVia;

    private System.Nullable<decimal> _Freight;

    private string _ShipName;

    private string _ShipAddress;

    private string _ShipCity;

    private string _ShipRegion;

    private string _ShipPostalCode;

    private string _ShipCountry;

    public Order()
    {
    }

    [Column(Storage = "_OrderID", AutoSync = AutoSync.OnInsert, 
      DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
      set
      {
        this._OrderID = value; 
      }
    }

    [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
    public string CustomerID
    {
      get
      {
        return this._CustomerID;
      }
      set
      {
        this._CustomerID = value;
      }
    }

    [Column(Storage = "_EmployeeID", DbType = "Int")]
    public System.Nullable<int> EmployeeID
    {
      get
      {
        return this._EmployeeID;
      }
      set
      {
        this._EmployeeID = value;
      }
    }

    [Column(Storage = "_OrderDate", DbType = "DateTime")]
    public System.Nullable<System.DateTime> OrderDate
    {
      get
      {
        return this._OrderDate;
      }
      set
      {
        this._OrderDate = value;
      }
    }

    [Column(Storage = "_RequiredDate", DbType = "DateTime")]
    public System.Nullable<System.DateTime> RequiredDate
    {
      get
      {
        return this._RequiredDate;
      }
      set
      {
        this._RequiredDate = value;
      }
    }

    [Column(Storage = "_ShippedDate", DbType = "DateTime")]
    public System.Nullable<System.DateTime> ShippedDate
    {
      get
      {
        return this._ShippedDate;
      }
      set
      {
        this._ShippedDate = value;
      }
    }

    [Column(Storage = "_ShipVia", DbType = "Int")]
    public System.Nullable<int> ShipVia
    {
      get
      {
        return this._ShipVia;
      }
      set
      {
        this._ShipVia = value;
      }
    }

    [Column(Storage = "_Freight", DbType = "Money")]
    public System.Nullable<decimal> Freight
    {
      get
      {
        return this._Freight;
      }
      set
      {
        this._Freight = value;
      }
    }

    [Column(Storage = "_ShipName", DbType = "NVarChar(40)")]
    public string ShipName
    {
      get
      {
        return this._ShipName;
      }
      set
      {
        this._ShipName = value;
      }
    }

    [Column(Storage = "_ShipAddress", DbType = "NVarChar(60)")]
    public string ShipAddress
    {
      get
      {
        return this._ShipAddress;
      }
      set
      {
        this._ShipAddress = value;
      }
    }

    [Column(Storage = "_ShipCity", DbType = "NVarChar(15)")]
    public string ShipCity
    {
      get
      {
        return this._ShipCity;
      }
      set
      {
        this._ShipCity = value;
      }
    }

    [Column(Storage = "_ShipRegion", DbType = "NVarChar(15)")]
    public string ShipRegion
    {
      get
      {
        return this._ShipRegion;
      }
      set
      {
        this._ShipRegion = value;
      }
    }

    [Column(Storage = "_ShipPostalCode", DbType = "NVarChar(10)")]
    public string ShipPostalCode
    {
      get
      {
        return this._ShipPostalCode;
      }
      set
      {
        this._ShipPostalCode = value;
      }
    }

    [Column(Storage = "_ShipCountry", DbType = "NVarChar(15)")]
    public string ShipCountry
    {
      get
      {
        return this._ShipCountry;
      }
      set
      {
        this._ShipCountry = value;
      }
    }
  }
}


