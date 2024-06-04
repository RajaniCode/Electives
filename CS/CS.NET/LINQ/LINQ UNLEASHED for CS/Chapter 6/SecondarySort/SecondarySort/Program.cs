using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondarySort
{
  class Program
  {
    static void Main(string[] args)
    {

      var gamblers = new []{
        new {LastName="Kimmel", First="Paul", Age=41},
        new {LastName="Swanson", First="Dena", Age=26},
        new {LastName="Swanson", First="Joe", Age=4},
        new {LastName="Kimmel", First="Noah", Age=11}};

      // thenby is implicit in second sort argument
      var sordid = from gambler in gamblers orderby gambler.LastName, gambler.Age 
        select gambler;

      foreach(var playa in sordid)
        Console.WriteLine(playa);

      Console.ReadLine();


    }
  }
}
