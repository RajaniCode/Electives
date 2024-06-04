using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      // inspired
      string quote =
        "Most people have the will to win, few have the will to prepare to win.";


      // make an array dropping empty items
      string[] words = quote.Split(new char[] { ' ', ',', '.' },
        StringSplitOptions.RemoveEmptyEntries);

      foreach (var s in words.Reverse())
        Console.WriteLine(s);

      Console.ReadLine();
    }
  }
}
