using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AddingAttributes
{
  class Program
  {
    static void Main(string[] args)
    {
      string filename = "..\\..\\PetCemetary.xml";

      XElement xml = XElement.Load(filename);
      var pets = from pet in xml.Elements("pet")
                 let genus = pet.Element("species").Attribute("genus")
                 where genus == null
                 select pet;

      Array.ForEach(pets.ToArray(), p=>Console.WriteLine(p.Element("name").Value));

      foreach(var pet in pets)
      {
        pet.Element("species").Add(new XAttribute("genus", "Dog"));
      }

      xml.Save(filename);
      
      Console.ReadLine();
    }
  }
}
