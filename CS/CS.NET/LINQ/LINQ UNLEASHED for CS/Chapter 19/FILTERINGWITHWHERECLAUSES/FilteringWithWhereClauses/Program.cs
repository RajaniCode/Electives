using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FilteringWithWhereClauses
{
  class Program
  {
    static void Main(string[] args)
    {
      const string filename = "..\\..\\Stocks.xml";
      XElement xml = XElement.Load(filename);
      XNamespace sq = "http://www.stock_quotes.com";

      var stocksThatLostGround = 
        from stock in xml.Elements(sq + "Stock")
          where (
            from price in stock.Elements(sq + "Price")
            where (decimal)price.Attribute("Change") < 0
            select price).Any()
        select stock;

      Array.ForEach(stocksThatLostGround.ToArray(), 
        o=>Console.WriteLine(o.Element(sq + "Symbol").Value));
      Console.ReadLine();
    }
  }
}
