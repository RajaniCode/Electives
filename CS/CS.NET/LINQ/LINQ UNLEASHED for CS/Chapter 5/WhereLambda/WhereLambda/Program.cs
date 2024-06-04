using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhereLambda
{
  class Program
  {
    static void Main(string[] args)
    {
      var words = new string[]{"Drop", "Dead", "Fred"};
      IEnumerable<string> hasDAndE = 
        words.Where(s => s.Contains('D') && s.Contains('e'));

      foreach(string s in hasDAndE)
        Console.WriteLine(s);
      Console.ReadLine();
    }
  }
}
