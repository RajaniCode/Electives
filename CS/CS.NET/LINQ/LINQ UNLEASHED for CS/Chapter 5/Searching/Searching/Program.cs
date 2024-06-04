using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searching
{
  class Program
  {
    static void Main(string[] args)
    {
      var recipes = new[]{
        "Crepes Florentine", "Shrimp Che Paul",
        "Beef Burgundy", "Rack of Lamb", 
        "Tacos", "Rosemary Raosted Chicken",
        "Juevos Rancheros", "Buffalo Chicken Nachos"};

      var results = recipes.Where(
        s=>s.Contains("Chicken"));

      Array.ForEach<string>(results.ToArray<string>(),
        s => Console.WriteLine(s));
      Console.ReadLine();

    }
  }
}
