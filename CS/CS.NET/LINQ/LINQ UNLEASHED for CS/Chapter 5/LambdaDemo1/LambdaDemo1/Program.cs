using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaDemo1
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]{1,2,3,4,5,6,7,8};

      // demo1
      //Func<int, bool> func = delegate(int arg)
      //{
      //  return arg % 2 == 0;
      //};

      //var p = numbers.Where(func);

      // demo2
      //Func<int, bool> func = p2 => p2 % 2 == 0;
      //var p = numbers.Where(func);

      // demo3
      //var p = numbers.Where(p2=>p2%2==0);

      // demo4
      var p = from n in numbers 
              where n % 2 == 0
              select n;
      
      foreach(var i in p)
        Console.WriteLine(i);
      Console.ReadLine();
    }
  }
}
