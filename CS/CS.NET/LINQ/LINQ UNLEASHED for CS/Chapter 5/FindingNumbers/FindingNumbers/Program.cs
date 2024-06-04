using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindingNumbers
{
  class Program
  {
    static void Main(string[] args)
    {
      List<int> fiboList = new List<int>();
      fiboList.AddRange(
        new[]{1,1,2,3,5,8,13,21,34,55});

      Predicate<int> match = n => n % 2 == 1;
      var odds = fiboList.FindAll(match);

      ObjectDumper.Write(odds);
      Console.ReadLine();

    }
  }
}
