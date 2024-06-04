using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnerJoin
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


      Array.ForEach(join1.ToArray(), o=>Console.WriteLine
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
