using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayInitializer
{
  class Program
  {
    static void Main(string[] args)
    {
      // array initializer 
      var fibonacci = new int[]{ 1, 1, 2, 3, 5, 8, 13, 21 };
      Console.WriteLine(fibonacci[0]);
      Console.ReadLine();
    }
  }
}
