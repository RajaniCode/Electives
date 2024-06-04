using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleYieldReturn
{
  class Program
  {
    static void Main(string[] args)
    {
      foreach(int i in GetEvents())
        Console.WriteLine(i);
      Console.ReadLine();
    }

    public static IEnumerable<int> GetEvents()
    {
      var integers = new[]{1, 2, 3, 4, 5, 6, 7, 8};
      foreach(int i in integers)
        if(i % 2 == 0)
          yield return i;
    }
  }
}
