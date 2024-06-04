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
      var moreNumbers = new int[]{10, 11, 12, 13, 14, 15};

      foreach( var n in numbers.Concat(moreNumbers))
        Console.WriteLine(n);

      Console.ReadLine();
    }
  }
}