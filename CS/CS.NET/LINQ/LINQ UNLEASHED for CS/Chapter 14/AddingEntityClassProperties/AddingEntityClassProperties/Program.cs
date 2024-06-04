using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AddingEntityClassProperties
{
  class Program
  {
    static void Main(string[] args)
    {
    }
  }
}

[Table(Name = "Customers")]
public partial class Customer
{
  [Column(IsPrimaryKey = true)]
  public string CustomerID;
  // ...
  private EntitySet<Order> _Orders;
  [Association(Storage = "_Orders", OtherKey = "CustomerID")]
  public EntitySet<Order> Orders
  {
    get { return this._Orders; }
    set { this._Orders.Assign(value); }
  }
}


