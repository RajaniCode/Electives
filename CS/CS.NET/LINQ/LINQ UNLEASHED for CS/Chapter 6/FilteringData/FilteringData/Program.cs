using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilteringData
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[] { -1, -32, 3, 5, -8, 13, 7, -41 };

      var magnitude = from n in numbers where Math.Abs(n) > 5 select n;

      foreach (var m in magnitude)
        Console.WriteLine(m);
      Console.ReadLine();


    }
  }
}
