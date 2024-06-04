using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AnonysmousTypeWithMethod
{
  class Program
  {
    static void Main(string[] args)
    {
      // adding method possibility
      Func<string, string, string> Concat = 
        delegate(string first, string last)
        {
          return last + ", " + first;
        };

      // whacky method but works
      Func<Type, Object, string> Concat2 = 
        delegate(Type t, Object o)
        {
          PropertyInfo[] info = t.GetProperties();
          return (string)info[1].GetValue(o, null) + 
            ", " + (string)info[0].GetValue(o, null);
        };

      var dena = new {First="Dena", Last="Swanson", Concat=Concat};
      //var dena = new {First="Dena", Last="Swanson", Concat=Concat2};
      Console.WriteLine(dena.Concat(dena.First, dena.Last));
      //Console.WriteLine(dena.Concat(dena.GetType(), dena));
      Console.ReadLine();
    }
  }
}
