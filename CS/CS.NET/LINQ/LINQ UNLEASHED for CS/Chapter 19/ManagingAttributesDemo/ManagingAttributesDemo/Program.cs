using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ManagingAttributesDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      XElement xml = XElement.Load("..\\..\\PetCemetary.xml");
      var pets = from pet in xml.Elements("pet")
                 let genus = pet.Element("species").Attribute("genus")
                 where genus.Value == "Feline"
                  select pet;
      XElement.Parse()

      Array.ForEach(pets.ToArray(), p=>Console.WriteLine(p.Element("name").Value));
      Console.ReadLine();
    }
  }
}
