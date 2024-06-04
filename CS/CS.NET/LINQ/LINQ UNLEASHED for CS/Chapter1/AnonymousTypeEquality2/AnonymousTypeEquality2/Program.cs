using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypeEquality2
{
  class Program
  {
    static void Main(string[] args)
    {
      var eq1 = new {ID=1, Name="Paul"};
      var eq2= new {Name="Paul", ID=3};
      Console.WriteLine(eq1.GetType().Name);
      Console.WriteLine(eq2.GetType().Name);
      Console.ReadLine();
    }
  }
}
