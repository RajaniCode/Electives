using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypeWithIntellisense
{
  class Program
  {
    static void Main(string[] args)
    {
      var dena = new {First="Dena", Last="Swanson"};
      // intellisense 
      Console.WriteLine(dena.Concat(dena.First, dena.Last));
      Console.ReadLine();
    }
  }
}
