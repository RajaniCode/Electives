using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AddAnnotationToXML
{
  class Program
  {
    static void Main(string[] args)
    {
      const string filename = "..\\..\\Stocks.xml";
      XElement elem = XElement.Load(filename);
      XNamespace sq = "http://www.stock_quotes.com";

      var stocksToAnnotate = 
        from stock in elem.Elements(sq + "Stock")
        select stock;

      const string yahooQuery = "http://download.finance.yahoo.com/d/?s={0}&f=ncbh";
      foreach(var stock in stocksToAnnotate)
      {
        stock.AddAnnotation(string.Format(yahooQuery, stock.Element(sq + "Symbol").Value));
        Console.WriteLine(stock.Annotation(typeof(Object)));
      }

      Console.ReadLine();
    }
  }
}
