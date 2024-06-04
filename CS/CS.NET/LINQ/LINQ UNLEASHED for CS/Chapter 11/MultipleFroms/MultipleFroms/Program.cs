using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleFroms
{
  class Program
  {
    static void Main(string[] args)
    {

      string[] willRogers =
      {
        "Don't gamble; take all your savings ",
        "and buy some good stock and hold it ",
        "till it goes up, then sell it. If it ",
        "don't go up, don't buy it. Will Rogers"
      };

      // part, word, words, and one are all called range variables
      var horseSense = from part in willRogers
                       let words = part.Split(';', '.', ' ', ',')
                       from word in words
                       let one = word.ToUpper()
                       where one.Contains('I')
                       select word;
      Array.ForEach(horseSense.ToArray(), w => Console.WriteLine(w));
      Console.ReadLine();
    }
  }
}
