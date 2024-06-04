using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinWordDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var games = new string[] { "Halo 3", "Call of Duty 4", "Project Gotham 3" };
      Console.WriteLine("Shortest title: {0}", games.Min(t => t.Length));

      // shortest title name
      var title = from game in games
                  where game.Length ==
                    games.Min(t => t.Length)
                  select game;

      Array.ForEach(title.ToArray(), s => Console.WriteLine(s));
      Console.ReadLine();
    }
  }
}
