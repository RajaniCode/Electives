using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HandlingMissingDataDemo
{
  class Program
  {
    static void Main(string[] args)
    {
        XElement elem = XElement.Load(@"..\..\PetCemetary.xml");
        var pets = from pet in elem.Elements("pet")
                   select new {Name=pet.Name, StartYear= (int)pet.Element("startYear"),
                               EndYear = (int)(pet.Element("endYear").IsEmpty ? 0 : (int)pet.Element("endYear"))};

        Array.ForEach(pets.ToArray(), p => 
          {
              Console.WriteLine("Name: {0}", p.Name);
              Console.WriteLine("Entered family: {0}", p.StartYear);
              Console.WriteLine("Left family: {0}", p.EndYear);
          });

        Console.ReadLine();
    }
  }
}
