using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICappingSelectDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      // array of strings for convenience
      string wayfarism = "I'm still vertical";

      // create to array of strings
      var values = wayfarism.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

      // icap
      var icapped = from s in values
                    select s.Replace(s[0], Convert.ToChar(s[0].ToString().ToUpper()));

      icapped.WriteLineAll();
      Console.ReadLine();
    }
  }

  public static class Extender
  {
    public static void WriteLineAll<T>(this IEnumerable<T> ary)
    {
      Array.ForEach(ary.ToArray(), item=>Console.WriteLine(item));
    }
  }
}
