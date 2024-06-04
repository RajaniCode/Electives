using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Xml.Linq;
using System.Data.Linq.Mapping;
using CustomerClass;
using Temp;

namespace LinqToSQlToXmlWithEmbeddedExpression
{
  class Program
  {
    static void Main(string[] args)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();

      Console.WriteLine(LinqtoSqlToXml.GetXML(customers.ToList<Customer>()));
      Console.ReadLine();

    }
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    public Northwind() : base(connectionString){}
  }
}
