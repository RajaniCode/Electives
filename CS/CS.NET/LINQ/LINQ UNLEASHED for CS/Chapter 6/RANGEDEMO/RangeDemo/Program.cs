using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RangeDemo
{
  class Program
  {
    // demonstrates range and repeat
    static void Main(string[] args)
    {
      // great for filling a range of values
      var sequence = Enumerable.Range(0/*start*/, 10/*count*/);
      Array.ForEach(sequence.ToArray(), n=>Console.WriteLine(n));
      Console.ReadLine();

      var alpha = Enumerable.Range(97, 26);
      Array.ForEach(alpha.Cast<char>().ToArray(), c=>Console.WriteLine(c));
      Console.ReadLine();
      
      var someStrings = Enumerable.Repeat("test", 100);
      Array.ForEach(someStrings.ToArray(), s=>Console.WriteLine(s));
      Console.ReadLine();

      var empties = Enumerable.DefaultIfEmpty<char>(Enumerable.Empty<char>());
      Console.WriteLine("Count: {0}", empties.Count());
      Console.ReadLine();

    }
  }
}
