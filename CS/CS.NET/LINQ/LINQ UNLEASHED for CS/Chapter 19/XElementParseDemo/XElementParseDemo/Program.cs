using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XElementParseDemo
{
  class Program
  {
    static void Main(string[] args)
    {
        string xml = "<pets>" + 
                     "  <pet>" + 
                     "    <id>2</id>" + 
                     "    <name>Dog</name>" + 
                     "    <species>Some Kind of Cat</species>" + 
                     "    <sex>Female</sex>" + 
                     "    <startYear>1972</startYear>" + 
                     "    <endYear>1974</endYear>" + 
                     "    <causeOfDeath>Car</causeOfDeath>" + 
                     "    <specialQuality>Best mouser</specialQuality>" + 
                     "  </pet>" + 
                     "</pets>";

        XElement elem = XElement.Parse(xml);
        var pets = from pet in elem.Elements("pet")
                   select pet;

        Array.ForEach(pets.ToArray(), p => Console.WriteLine(p.Element("name").Value));
        Console.ReadLine();
    }
  }
}
