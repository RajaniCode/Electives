using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyWithIndex
{
  class Program
  {

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

    static void Main(string[] args)
    {
      List<Customer> customers = new List<Customer>{
        new Customer{ID=1, CompanyName="Tom's Toffees"},
        new Customer{ID=2, CompanyName="Karl's Coffees"}};

      List<Order> orders = new List<Order>{
        new Order{ID=1, CustomerID=1, ItemDescription="Granulated Sugar"},
        new Order{ID=2, CustomerID=1, ItemDescription="Molasses"},
        new Order{ID=3, CustomerID=2, ItemDescription="French Roast Beans"},
        new Order{ID=4, CustomerID=2, ItemDescription="Ceramic Cups"}};

      var orderInfo =
        customers.SelectMany(
          (customer, index) =>
            from order in orders
            where order.CustomerID == customer.ID
            select new { Key = index + 1, Customer = customer.CompanyName, 
	    Item = order.ItemDescription });

      Array.ForEach(orderInfo.ToArray(), o=>Console.WriteLine(
          "Key: {0}, Name: {1}, Item: {2}", o.Key, o.Customer, o.Item));
      Console.ReadLine();
    }
  }
}
