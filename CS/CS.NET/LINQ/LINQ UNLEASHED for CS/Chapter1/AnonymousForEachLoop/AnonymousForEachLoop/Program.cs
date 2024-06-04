using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousForEachLoop
{
  class Program
  {
    static void Main(string[] args)
    {
      var fibonacci = new int[]{ 1, 1, 2, 3, 5, 8, 13, 21 };
      foreach( var fibo in fibonacci)
        Console.WriteLine(fibo);
      Console.ReadLine();
    }
  }
}
