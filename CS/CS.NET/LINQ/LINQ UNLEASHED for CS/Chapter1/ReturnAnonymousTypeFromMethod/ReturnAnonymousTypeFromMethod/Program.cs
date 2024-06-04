using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReturnAnonymousTypeFromMethod
{
  class Program
  {
    static void Main(string[] args)
    {
      var anon = GetAnonymous();
      Type t = anon.GetType();
      Console.WriteLine(t.GetProperty("Stock").GetValue(anon, null));
      Console.ReadLine();
    }

    public static object GetAnonymous()
    {
      var stock = new {Stock="MSFT", Price="32.450"};
      return stock;
    }
  }
}
