using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ElementDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};

      // first
      var first = (from n in numbers select n).First();
      Console.WriteLine("First: {0}", first);
      var firstOrDefault = (from n in numbers select n).FirstOrDefault(
        n=>n>10);
      Console.WriteLine("First or default: {0}", firstOrDefault);

      // last
      var last = (from n in numbers select n).Last();
      Console.WriteLine("Last: {0}", last);
      var lastOrDefault = (from n in numbers select n).LastOrDefault(
        n=>n<5);
      Console.WriteLine("Last or default: {0}", lastOrDefault);

      // single
      var single = (from n in numbers where n==5 select n).Single();
      Console.WriteLine("Single: {0}", single);
      var singleOrDefault = (from n in numbers select n).SingleOrDefault(
        n=>n==3);
      Console.WriteLine("Single or default: {0}", singleOrDefault);

      // element at
      var element = (from n in numbers where n < 8 select n).ElementAt(6);
      Console.WriteLine("Element at 6: {0}", element);

      var elementOrDefault = (from n in numbers select n).ElementAtOrDefault(11);
      Console.WriteLine("Element at 11 or default: {0}", elementOrDefault);

      Console.ReadLine();
    }
  }
}