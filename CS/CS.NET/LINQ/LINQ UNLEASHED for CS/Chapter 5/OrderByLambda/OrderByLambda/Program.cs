using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderByLambda
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]
        {1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
      IEnumerable<int> ordered = numbers.OrderBy(n=>n);
      foreach(var num in ordered)
        Console.WriteLine(num);
      Console.ReadLine();
    }
  }
}
