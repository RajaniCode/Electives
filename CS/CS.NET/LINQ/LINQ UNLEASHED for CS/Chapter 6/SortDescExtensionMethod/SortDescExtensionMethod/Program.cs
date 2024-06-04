using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortDescExtensionMethod
{
  class Program
  {
    static void Main(string[] args)
    {
      // inspired
      string quote =
        "Most people have the will to win, few have the will to prepare to win.";
      
      
      // make an array dropping empty items
      string[] words = quote.Split(new char[]{' ', ',', '.'}, 
        StringSplitOptions.RemoveEmptyEntries);

      // use extension method directly to sort descending
      foreach (var s in words.OrderByDescending(s => s))
        Console.WriteLine(s);

      Console.ReadLine();
    }
  }
}
