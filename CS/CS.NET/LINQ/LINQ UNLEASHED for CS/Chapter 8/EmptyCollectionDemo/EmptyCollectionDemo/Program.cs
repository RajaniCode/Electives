using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EmptyCollectionDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] numbers1 = new int[]{1, 2, 3};
      int[] numbers2 = new int[]{4, 5, 6};
      int[] numbers3 = new int[]{7, 8, 9};

      List<int[]> all = new List<int[]>{
        numbers1, numbers2, numbers3};

      //var allNumbers = all.Aggregate(
      //  Enumerable.Empty<int>(), (current,next) =>
      //    current.Union(next));

      //var allNumbers = all.Aggregate((current,next) =>
      //  current.Union(next).ToArray<int>());

      var allNumbers = Enumerable.Aggregate(all, Enumerable.Empty<int>(), 
        (current, next)=>current.Union(next));

      var allNumbers = Enumerable.Aggregate(all, Enumerable.Empty<int>(), 
        (current, next)=>current.Union(next));


      Array.ForEach(allNumbers.ToArray(), n=>Console.WriteLine(n));
      Console.ReadLine();

    }
  }
}
