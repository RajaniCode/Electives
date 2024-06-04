using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaClosure
{
  class Program
  {
    static void Main(string[] args)
    {
      UsesClosure();
    }

    static void UsesClosure()
    {
      string toFind = "ed";
      var words = new string[]{
        "ended", "friend", "closed", "potato"};

      var matches = words.Select(s => s.Contains(toFind));

      foreach(var str in matches)
        Console.WriteLine(str);
      Console.ReadLine();

    }
  }
}
