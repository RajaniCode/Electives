using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoinDemo
{
  class Program
  {
    
    static void Main(string[] args)
    {
      List<Customer> customers = new List<Customer>{
        new Customer{ID=1, CompanyName="Tom's Toffees"},
        new Customer{ID=2, CompanyName="Karl's Coffees"},
        new Customer{ID=3, CompanyName="Mary's Marshmallow Cremes"}};

      List<Order> orders = new List<Order>{
        new Order{ID=1, CustomerID=1, ItemDescription="Granulated Sugar"},
        new Order{ID=2, CustomerID=1, ItemDescription="Molasses"},
        new Order{ID=3, CustomerID=2, ItemDescription="French Roast Beans"},
        new Order{ID=4, CustomerID=2, ItemDescription="Ceramic Cups"}};
      
      // join
      var join1 = from customer in customers 
                   join order in orders on customer.ID equals 
                   order.CustomerID 
                   select new {Name=customer.CompanyName, Item=order.ItemDescription};

      // left join using group join - key is into which is group join
      var join2 = from customer in customers 
                   join order in orders on customer.ID equals 
                   order.CustomerID into temp
                   from sub in temp.DefaultIfEmpty()
                   select new {Name=customer.CompanyName,
                   Item=sub==null?String.Empty: sub.ItemDescription};

      var join3 = from c in customers 
                  from o in orders
                  select new {Name=c.CompanyName, Item=o.ItemDescription};

      // join2 represents the left join and join1 represents the inner join
      Array.ForEach(join3.ToArray(), o=>Console.WriteLine
        ("Name: {0}, Item: {1}", o.Name, o.Item));
      Console.ReadLine();

    }

  }
    
  public class Customer
  {
    public int ID{get; set;}
    public string CompanyName{get; set; }
  }

  public class Order
  {
    public int ID{get; set; }
    public int CustomerID{get; set; }
    public string ItemDescription{get; set;}
  }
}

      // composite keys
      // var query = from o in db.Orders
      //    from p in db.Products
      //    join d in db.OrderDetails 
      //    on new {o.OrderID, p.ProductID} equals new {d.OrderID, d.ProductID} into details
      //    from d in details
      //    select new {o.OrderID, p.ProductID, d.UnitPrice};
