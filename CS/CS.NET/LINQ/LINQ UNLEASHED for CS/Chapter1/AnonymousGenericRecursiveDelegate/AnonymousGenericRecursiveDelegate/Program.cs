using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AnonymousGenericRecursiveDelegate
{
  class Program
  {
    static void Main(string[] args)
    {
      Func<long, long> Factorial = 
        delegate(long n)
        {
          return n > 1 ? 
            n * (long)(new StackTrace()
            .GetFrame(0).GetMethod().Invoke(null, new object[]{n-1}))
            : n;
        };

      Console.WriteLine(Factorial(6));
      Console.ReadLine();
    }
  }
}
