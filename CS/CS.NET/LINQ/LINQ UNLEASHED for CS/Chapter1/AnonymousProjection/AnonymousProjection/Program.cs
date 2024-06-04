using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousProjection
{
  class Program
  {
    static void Main(string[] args)
    {
      //var joe = new {"Joe", "Swanson"}; // error - no member declarator
      var joe = new {First="Joe", Last="Swanson"}; 
      Console.WriteLine(joe);
      Console.ReadLine();
    }
  }
}
