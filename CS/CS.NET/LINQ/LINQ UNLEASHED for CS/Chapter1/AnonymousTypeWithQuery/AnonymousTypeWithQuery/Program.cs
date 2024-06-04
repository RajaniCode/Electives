using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypeWithQuery
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[] {1, 2, 3, 4, 5, 6, 7};
      var all = from n in numbers orderby n descending select n;
      
      foreach(var n in all)
        Console.WriteLine(n);

      var songs = new string[]{"Let it be", "I shall be released"};
      var newType = from song in songs select new {Title=song};

      foreach(var s in newType)
        Console.WriteLine(s.Title);

      Console.ReadLine();
    }
  }
}
