using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XDocumentDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      XDocument xml = XDocument.Load("..\\..\\PetCemetary.xml");
      var pets = from pet in xml.Elements("pets").Elements("pet")
                  select pet;

      Array.ForEach(pets.ToArray(), p=>Console.WriteLine(p.Element("name").Value));
      Console.ReadLine();
    }
  }
}
