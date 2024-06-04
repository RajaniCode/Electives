using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UsingNamespacesWithLinqToXML
{
  class Program
  {
    static void Main(string[] args)
    {
      const string filename = "..\\..\\Stocks.xml";
      XElement xml = XElement.Load(filename);
      XNamespace sq = "http://www.stock_quotes.com";

      var stocks = 
        from stock in xml.Elements(sq + "Stock")
        select new {Name=stock.Element(sq + "Symbol").Value};

      Array.ForEach(stocks.ToArray(), 
        o=>Console.WriteLine(o.Name));
      Console.ReadLine();
    }
  }
}
