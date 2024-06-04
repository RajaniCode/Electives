using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryWithWhere
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]{1966, 1967, 1968, 1969, 1970};
      var evens = from num in numbers where num % 2 == 0 select num;
      
      foreach(var result in evens)
        Console.WriteLine(result);

      Console.ReadLine();

    }
  }
}
