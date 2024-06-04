using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectDemo2
{
  class Program
  {
    static void Main(string[] args)
    {

      var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      var toEvens = from num in numbers
                    select num * 2;

      Array.ForEach(toEvens.ToArray(), n => Console.WriteLine(n));
      Console.ReadLine();
    }
  }
}

