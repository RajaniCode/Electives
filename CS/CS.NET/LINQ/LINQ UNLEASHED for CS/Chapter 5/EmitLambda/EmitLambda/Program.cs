using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.DLinq;
using System.Linq.Expressions;

namespace EmitLambda
{
  class Program
  {
    static void Main(string[] args)
    {
      Test();
      Test2();
    }

    static void Test2()
    {
      Expression<Func<int, bool>> exp = 
        num => num % 2 == 0;
      Console.WriteLine("Body: {0}", exp.Body.ToString());
      Console.WriteLine("Node Type: {0}", exp.NodeType);
      Console.WriteLine("Type: {0}", exp.Type);
      Func<int, bool> lambda = exp.Compile();
      Console.WriteLine(lambda(2));
      Console.ReadLine();
    }

    static void Test()
    {
      Func<int, bool> lambda = num => num % 2 == 0;
    }
  }
}
