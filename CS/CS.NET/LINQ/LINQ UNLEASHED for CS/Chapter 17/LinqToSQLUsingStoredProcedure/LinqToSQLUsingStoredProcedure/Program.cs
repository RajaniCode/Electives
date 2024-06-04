using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSQLUsingStoredProcedure
{
  class Program
  {
    static void Main(string[] args)
    {
      CustomersDataContext context = new CustomersDataContext();
      context.Log = Console.Out;

      Customer customer = new Customer();
      customer.CustomerID = "temp";
      customer.CompanyName = "Paulys Fried Oysters";

      context.Customers.InsertOnSubmit(customer);
      context.SubmitChanges();

      Console.WriteLine("Insert: {0}", customer.CustomerID);
      Console.ReadLine();

    }
  }
}
