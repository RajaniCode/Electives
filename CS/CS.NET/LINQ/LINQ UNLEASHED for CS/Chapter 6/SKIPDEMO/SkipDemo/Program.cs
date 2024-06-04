using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkipDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var ints = new int[]{1,2,3,4,5,6,7,8,9,10};
      var result1 = ints.TakeWhile(n=>n<=5);
      var result2 = ints.Skip(3);
      Array.ForEach(result1.ToArray(), n=> Console.WriteLine(n));
      Console.ReadLine();
      Array.ForEach(result2.ToArray(), n=> Console.WriteLine(n));
      Console.ReadLine();
    }
  }
}
