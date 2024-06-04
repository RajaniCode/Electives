using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaCurry
{
  class Program
  {
    static void Main(string[] args)
    {
      Func<int, int, int> longLambda = (x,y) => x + y;
      Console.WriteLine(longLambda(3,4));
      Console.ReadLine();

      // currying
      Func<int, Func<int,int>> curry1 = x => y => x + y;
      Console.WriteLine(curry1(3)(4));
      Console.ReadLine();
    }
  }
}
