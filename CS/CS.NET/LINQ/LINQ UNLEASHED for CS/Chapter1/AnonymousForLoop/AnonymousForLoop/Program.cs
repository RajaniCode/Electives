using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousForLoop
{
  class Program
  {
    static void Main(string[] args)
    {
      var fibonacci = new int[]{ 1, 1, 2, 3, 5, 8, 13, 21 };
      for( var i=0; i<fibonacci.Length; i++)
        Console.WriteLine(fibonacci[i]);
      Console.ReadLine();
    }
  }
}
