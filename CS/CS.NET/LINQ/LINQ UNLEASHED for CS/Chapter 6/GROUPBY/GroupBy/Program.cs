using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupBy
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[]{1,2,3,4,5,6,7,8,9,10};
      var result = from n in nums group n by n % 2;
      
      // really quite funky
      Array.ForEach(result.ToArray(), x=>{
        Console.WriteLine(x.Key==0? "evens:" : "odds:");
        Array.ForEach(x.ToArray(), y=>Console.WriteLine(y));});

      Console.ReadLine();
    }
  }
}
