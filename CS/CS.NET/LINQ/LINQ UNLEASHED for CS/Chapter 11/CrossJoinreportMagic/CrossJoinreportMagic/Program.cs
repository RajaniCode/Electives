using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossJoinReportMagic
{
  class Program
  {
    static void Main(string[] args)
    {
#region collection initializations
      var customers = new Customer[]{ 
        new Customer{CustomerID="ALFKI", CompanyName="Alfreds Futterkiste"},
        new Customer{CustomerID="ANATR", CompanyName="Ana Trujillo Emparedados y helados"},
        new Customer{CustomerID="ANTON", CompanyName="Antonio Moreno Taquería"},
        new Customer{CustomerID="AROUT", CompanyName="Around the Horn"},
        new Customer{CustomerID="BERGS", CompanyName="Berglunds snabbköp"},
        new Customer{CustomerID="SPECD", CompanyName="Spécialités du monde"}
      };
      
      var products = new Product[]{
        new Product{ProductID=1, ProductName="Chai"},
        new Product{ProductID=2, ProductName="Chang"},
        new Product{ProductID=3, ProductName="Aniseed Syrup"},
        new Product{ProductID=4, ProductName="Chef Anton's Cajun Seasoning"},
        new Product{ProductID=5, ProductName="Chef Anton's Gumbo Mix"},
        new Product{ProductID=6, ProductName="Grandma's Boysenberry Spread"},
        new Product{ProductID=7, ProductName="Uncle Bob's Organic Dried Pears"},
        new Product{ProductID=8, ProductName="Northwoods Cranberry Sauce"},
        new Product{ProductID=9, ProductName="Mishi Kobe Niku"},
        new Product{ProductID=10, ProductName="Ikura"}
      };

      var orders = new Order[]{
        new Order{ OrderID= 10278, CustomerID="BERGS"},
        new Order{ OrderID= 10280, CustomerID="BERGS"},
        new Order{ OrderID= 10308, CustomerID="BERGS"},
        new Order{ OrderID= 10355, CustomerID="AROUT"},
        new Order{ OrderID= 10365, CustomerID="ANTON"},
        new Order{ OrderID= 10383, CustomerID="AROUT"},
        new Order{ OrderID= 10384, CustomerID="BERGS"},
        new Order{ OrderID= 10444, CustomerID="BERGS"},
        new Order{ OrderID= 10445, CustomerID="BERGS"},
        new Order{ OrderID= 10453, CustomerID="AROUT"},
        new Order{ OrderID= 10507, CustomerID="ANTON"},
        new Order{ OrderID= 10524, CustomerID="BERGS"},
        new Order{ OrderID= 10535, CustomerID="ANTON"},
        new Order{ OrderID= 10558, CustomerID="AROUT"},
        new Order{ OrderID= 10572, CustomerID="BERGS"},
        new Order{ OrderID= 10573, CustomerID="ANTON"},
        new Order{ OrderID= 10625, CustomerID="ANATR"},
        new Order{ OrderID= 10626, CustomerID="BERGS"},
        new Order{ OrderID= 10643, CustomerID="ALFKI"}
      };

      var orderDetails = new OrderDetail[]{
        new OrderDetail{OrderID=10278, ProductID=1, 
          UnitPrice=15.5000M, Quantity=16, Discount=0},
        new OrderDetail{OrderID=10278, ProductID=2, 
          UnitPrice=44.0000M, Quantity=15, Discount=0},
        new OrderDetail{OrderID=10278, ProductID=3, 
          UnitPrice=35.1000M, Quantity=8, Discount=0},
        new OrderDetail{OrderID=10278, ProductID=4, 
          UnitPrice=12.0000M, Quantity=25, Discount=0},
        new OrderDetail{OrderID=10280, ProductID=5, 
          UnitPrice=3.6000M, Quantity=12, Discount=0},
        new OrderDetail{OrderID=10280, ProductID=6, 
          UnitPrice=19.2000M, Quantity=20, Discount=0},
        new OrderDetail{OrderID=10280, ProductID=7, 
          UnitPrice=6.2000M, Quantity=30, Discount=0},
        new OrderDetail{OrderID=10308, ProductID=1, 
          UnitPrice=15.5000M, Quantity=5, Discount=0},
        new OrderDetail{OrderID=10308, ProductID=9, 
          UnitPrice=12.0000M, Quantity=5, Discount=0},
        new OrderDetail{OrderID=10355, ProductID=3, 
          UnitPrice=3.6000M, Quantity=25, Discount=0},
        new OrderDetail{OrderID=10355, ProductID=5, 
          UnitPrice=15.6000M, Quantity=25, Discount=0},
        new OrderDetail{OrderID=10365, ProductID=7, 
          UnitPrice=16.8000M, Quantity=24, Discount=0},
        new OrderDetail{OrderID=10383, ProductID=9, 
          UnitPrice=4.8000M, Quantity=20, Discount=0},
        new OrderDetail{OrderID=10383, ProductID=2, 
          UnitPrice=13.0000M, Quantity=15, Discount=0},
        new OrderDetail{OrderID=10383, ProductID=4, 
          UnitPrice=30.4000M, Quantity=20, Discount=0}
        };
#endregion

      var orderInfo = from customer in customers
                      from product in products
                      // inner data
                      from data in
                        ((from order in orders
                          join detail in orderDetails
                          on order.OrderID equals detail.OrderID
                          group detail by new { order.CustomerID, detail.ProductID, detail.Discount } into groups
                          from item in groups
                          let Quantity = groups.Sum(d => d.Quantity)
                          select new
                          {
                            groups.Key.CustomerID,
                            item.ProductID,
                            item.UnitPrice,
                            Quantity,
                            item.Discount
                          }).Distinct())
                      where customer.CustomerID == data.CustomerID
                      && product.ProductID == data.ProductID
                      orderby product.ProductID, customer.CompanyName
                      select new
                      {
                        customer.CustomerID,
                        customer.CompanyName,
                        product.ProductID,
                        product.ProductName,
                        data.Quantity,
                        data.UnitPrice,
                        data.Discount,
                        Total=(data.Quantity * data.UnitPrice * (1-data.Discount))
                      };
                      

      Dump(orderInfo);
      Console.ReadLine();
	  }

    public static void Dump(object data)
    {
      if (data is IEnumerable)
      {
        IEnumerable list = data as IEnumerable;
        IEnumerator enumerator = list.GetEnumerator();
        int i = 0;
        while(enumerator.MoveNext())
        {
          i++;
          Console.WriteLine(enumerator.Current);
          Console.WriteLine(Environment.NewLine);

        }

        Console.WriteLine("Item count: {0}", i);
      }
    }

  }

    public class Customer
    {
      public string CustomerID { get; set; }
      public string CompanyName { get; set; }
    }

    public class Product
    {
      public int ProductID { get; set; }
      public string ProductName { get; set; }
    }

    public class Order
    {
      public int OrderID { get; set; }
      public string CustomerID { get; set; }
    }

    public class OrderDetail
    {
      public int OrderID { get; set; }
      public int ProductID { get; set; }
      public decimal UnitPrice { get; set; }
      public int Quantity { get; set; }
      public decimal Discount { get; set; }
    }
}

