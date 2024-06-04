using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfTypeFilterDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var randomData = new object[]{1, "two", 3, "four", 5.5, "six", 7M};

      var canBeInt = from r in randomData.OfType<int>() select r;
      foreach(var i in canBeInt)
        Console.WriteLine(i);
      Console.ReadLine();

      Console.WriteLine(Convert.ToInt32(7M));
      Console.ReadLine();
    }
  }
}
