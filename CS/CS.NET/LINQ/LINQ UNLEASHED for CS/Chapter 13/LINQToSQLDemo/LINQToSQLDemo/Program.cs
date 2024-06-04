using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace LINQToSQLDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind(@"Northwnd.mdf");

      var customers = from customer in northwind.Customers
                      where customer.City == "London"
                      select customer.CompanyName;

      foreach (var cust in customers)
        Console.WriteLine(cust);

      Console.ReadLine();
    }
  }

  public class Northwind : DataContext
  {
    public Northwind(string database)
      : base(database) { }
  }


}
//// Northwnd inherits from System.Data.Linq.DataContext.
//Northwnd nw = new Northwnd(@"northwnd.mdf");

//var companyNameQuery =
//    from cust in nw.Customers
//    where cust.City == "London"
//    select cust.CompanyName;

//foreach (var customer in companyNameQuery)
//{
//    Console.WriteLine(customer);
//}