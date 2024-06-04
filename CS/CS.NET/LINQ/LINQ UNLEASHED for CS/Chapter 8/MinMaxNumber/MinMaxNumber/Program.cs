using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinMaxNumber
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new float[] { 1.0f, 3.5f, -7.8f, 10f };
      Console.WriteLine("Min: {0}", numbers.Min());
      Console.WriteLine("Max: {0}", numbers.Max());
      Console.ReadLine();
    }
  }
}
