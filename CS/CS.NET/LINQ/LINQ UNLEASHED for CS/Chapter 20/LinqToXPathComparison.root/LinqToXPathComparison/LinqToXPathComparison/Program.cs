using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;


namespace LinqToXPathComparison
{
  class Program
  {
    static void Main(string[] args)
    {
      FindChild();
      FindSibling();
      FilterOnAttribute();
      UseNamespace();
    }

    private static void UseNamespace()
    {
      const string filename = "..\\..\\CurrentStatsWithNamespace.xml";
      XDocument doc = XDocument.Load(filename);
      XNamespace jack = "http://www.blackjack.com";

      XElement winLoss1 = doc.Element(jack + "Blackjack")
        .Element(jack + "Player").Element(jack + "Statistics").Element(jack + "NetWinLoss");

      Console.WriteLine(winLoss1);
      Console.ReadLine();

      XmlReader reader = XmlReader.Create(filename);
      XElement root = XElement.Load(reader);
      XmlNameTable table = reader.NameTable;
      XmlNamespaceManager manager = new XmlNamespaceManager(table);
      manager.AddNamespace("jack", "http://www.blackjack.com");

      XElement winLoss2 = 
        doc.XPathSelectElement("./jack:Blackjack/jack:Player/jack:Statistics/jack:NetWinLoss",
        manager);
      Console.WriteLine(winLoss2);
      Console.ReadLine();
    }

    private static void FilterOnAttribute()
    {
      const string filename = "..\\..\\CurrentStats.xml";
      XElement xml = XElement.Load(filename);

      XElement player1 = 
        (from elem in xml.Elements("Player")
        where elem.Attribute("Name").Value == "Player 1"
        select elem).First();

      Console.WriteLine(player1);

      XElement player2 = xml.XPathSelectElement("Player[@Name='Player 1']");
      Console.WriteLine(player2);
      Console.ReadLine();
      
    }

    private static void FindSibling()
    {
      const string filename = "..\\..\\CurrentStats.xml";
      XElement xml = XElement.Load(filename);
      XElement child1 = xml.Element("Player")
        .Element("Statistics").Element("AverageAmountWon");
      XElement sibling1 = child1.ElementsAfterSelf().First();
      Console.WriteLine(sibling1);
      Console.ReadLine();

      XElement child2 = xml.XPathSelectElement("Player/Statistics/AverageAmountWon");
      XElement sibling2 = child2.XPathSelectElement("following-sibling::*");
      Console.WriteLine(sibling2);
      Console.ReadLine();
      
    }

    private static void FindChild()
    {
      const string filename = "..\\..\\CurrentStats.xml";
      XElement xml = XElement.Load(filename);
      XElement child1 = xml.Element("Player")
        .Element("Statistics").Element("AverageAmountLost");
      Console.WriteLine(child1);
      Console.ReadLine();

      // XPath expression using System.Xml.Linq capabilities
      XElement child2 = xml.XPathSelectElement("Player/Statistics/AverageAmountLost");
      Console.WriteLine(child2);
      Console.ReadLine();
    }
  }
}
