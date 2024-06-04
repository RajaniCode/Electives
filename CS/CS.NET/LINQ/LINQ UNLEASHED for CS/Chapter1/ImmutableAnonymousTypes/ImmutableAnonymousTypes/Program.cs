using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImmutableAnonymousTypes
{
  class Program
  {
    static void Main(string[] args)
    {
      var dena = new {First="Dena", Last="Swanson"};
      //dena.First = "Christine"; // error - immutable
      Console.WriteLine(dena);
      Console.ReadLine();
    }
  }
}
