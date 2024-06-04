using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedianOperation
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]{3,4,5,6,7,8,9,10};
      
      Console.Write(numbers.Median());
      Console.ReadLine();
    }
  }

  

  public static class MyAggregate
  {
    public static T Median<T>(this IEnumerable<T> source) 
    {
      var ordered = from s in source orderby s select s;
      return source.ToArray()[ordered.Count()/2];
    }
  }
}


