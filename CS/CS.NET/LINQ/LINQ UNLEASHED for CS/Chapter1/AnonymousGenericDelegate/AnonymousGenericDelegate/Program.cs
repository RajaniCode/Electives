using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousGenericDelegate
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Func<long, long> Factorial = 
        delegate(long n)
        {
          if(n==1) return 1;
          long result=1;
          for(int i=2; i<=n; i++)
            result *= i;
          return result;
        };

      Console.WriteLine(Factorial(6));
      Console.ReadLine();
    }
  }
}
