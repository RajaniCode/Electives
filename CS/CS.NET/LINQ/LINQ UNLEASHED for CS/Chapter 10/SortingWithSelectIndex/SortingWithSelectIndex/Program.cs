using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingWithSelectIndex
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] cards = new int[52];

      Random rand = new Random();

      var shuffler = cards.Select((num, index) =>
        new { Key = index, Random = rand.Next() });

      Array.ForEach(shuffler.OrderBy(s=>s.Random).ToArray(), s => Console.WriteLine(s));
      Console.ReadLine();
    }
  }
}
