using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace AverageWordLengthInFile
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = File.ReadAllLines("..\\..\\WalrusAndCarpenter.txt");
      // sanity check
      Array.ForEach(lines, line => Console.WriteLine(line));
      
      Func<string, string[]> Split = str=>str.Split(new char[]{'-',',',' ','.'}, 
        StringSplitOptions.RemoveEmptyEntries);

      List<string> all = new List<string>();
      //split out words
      Array.ForEach(lines, line => all.AddRange(Split(line)));

      // sanity check 
      Array.ForEach(all.ToArray(), word => Console.WriteLine(word));

      //send result
      Console.WriteLine("Average word length {0}",
        Math.Round(all.Average(w => w.Length), 2));
      
      Console.ReadLine();
    }
  }
}
