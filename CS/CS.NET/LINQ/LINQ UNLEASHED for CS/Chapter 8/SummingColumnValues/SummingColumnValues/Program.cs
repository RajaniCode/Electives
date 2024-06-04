using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SummingColumnValues
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = File.ReadAllLines("..\\..\\csvData.txt");

      // make sure we have some data
      foreach (string s in lines)
        Console.WriteLine("{0}", s);

      var results =
        from line in lines
        let values = line.Split(',')
        let y = values
        select (from str in y
                    select Convert.ToInt32(str));

      Console.WriteLine();
      for (int i = 0; i < results.Count(); i++)
      {
        Console.WriteLine("Total Column {0}: {1}", i+1, results.Sum(o => o.ElementAt(i)));
      }

      System.Threading.Thread.Sleep(5000);
    }
  }

  /* Data:
   * 3,5,7,9,13
   * 1,2,3,4,5
   * 6,7,8,9,10
   * 123,12,1,0,8
   * -3,-23,22,44, 7
   */
}
