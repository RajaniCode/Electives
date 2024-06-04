using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SelectManyDemo
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
      // explicit select many combines the two sub-arrays
      string[] words = new string[]{"many have the will to win", "few have the will to prepare"};
      var words2 = words.SelectMany(str=>str.Split(' '));
      Array.ForEach(words2.ToArray(), s=>Console.WriteLine(s));
      Console.ReadLine();

      List<Customer> customers = new List<Customer>{
        new Customer{ID=1, CompanyName="Tom's Toffees"},
        new Customer{ID=2, CompanyName="Karl's Coffees"}};

      List<Order> orders = new List<Order>{
        new Order{ID=1, CustomerID=1, ItemDescription="Granulated Sugar"},
        new Order{ID=2, CustomerID=1, ItemDescription="Molasses"},
        new Order{ID=3, CustomerID=2, ItemDescription="French Roast Beans"},
        new Order{ID=4, CustomerID=2, ItemDescription="Ceramic Cups"}};

      // implicit select many
      var orderInfo = from customer in customers
                      from order in orders 
                      where customer.ID == order.CustomerID
                      select new {Name=customer.CompanyName, Item=order.ItemDescription};

      Array.ForEach(orderInfo.ToArray(), o=>Console.WriteLine(
          "Company: {0}, Item: {1}", o.Name, o.Item));
      Console.ReadLine();
    }
  }
}
