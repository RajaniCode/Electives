using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousForEachLoopFromExpression
{
  class Program
  {
    
    static void Main(string[] args)
    {
      var fibonacci = new int[]{ 1, 1, 2, 3, 5, 8, 13, 21, 33, 54, 87 };
            
      // uses Lambda expression with Where<int, bool> and
      // Where is an extension method for IEnumerable
      foreach( var fibo in fibonacci.Where(n => n%3==0))
        Console.WriteLine(fibo);
      Console.ReadLine();

      // uses LINQ query
      foreach( var fibo in from f in fibonacci where f%3==0 select f)
        Console.WriteLine(fibo);
      Console.ReadLine();

    }
  }
}
