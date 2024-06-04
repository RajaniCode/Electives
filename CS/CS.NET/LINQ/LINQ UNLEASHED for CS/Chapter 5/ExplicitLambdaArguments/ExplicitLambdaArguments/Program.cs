using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplicitLambdaArguments
{
  class Program
  {
    static void Main(string[] args)
    {
      Func<int, int, int> add =
        (int x, int y) => x + y;
      Console.WriteLine(add(3, 4));
      Console.ReadLine();
    }
  }
}
