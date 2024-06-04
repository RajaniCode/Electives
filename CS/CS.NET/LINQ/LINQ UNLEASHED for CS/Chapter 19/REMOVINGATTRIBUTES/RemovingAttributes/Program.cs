using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace RemovingAttributes
{
  class Program
  {
    static void Main(string[] args)
    {
      string filename = "..\\..\\PetCemetary.xml";

      XElement xml = XElement.Load(filename);
      var pets = from pet in xml.Elements("pet")
                 where pet.Element("name").Value == "Ruby"
                 select pet;

      Array.ForEach(pets.ToArray(), p=>Console.WriteLine(p.Element("name").Value));

      foreach(var pet in pets)
      {
        pet.Element("species").Attribute("genus").Remove();
      }

      xml.Save(filename);
      
      Console.ReadLine();
    }
  }
}
