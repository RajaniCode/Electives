using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FindingElementsBasedOnContext
{
  class Program
  {
    static void Main(string[] args)
    {
      XElement elem = XElement.Parse(
         "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + 
         "<sq:Stocks xmlns:sq=\"http://www.stock_quotes.com\">" + 
         "  <sq:Stock>" + 
         "    <sq:Symbol>MSFT</sq:Symbol>" + 
         "    <sq:Price Change=\"0.6\" Low=\"42.1\" High=\"51.0\">56.0</sq:Price>" + 
         "  </sq:Stock>" +  
         "  <sq:Stock>" + 
         "    <sq:Symbol>MVK</sq:Symbol>" + 
         "    <sq:Price Change=\"-3.2\" Low=\"22.8\" High=\"32.4\">25.5</sq:Price>" + 
         "  </sq:Stock>" + 
         "  <sq:Stock>" + 
         "    <sq:Symbol>GOOG</sq:Symbol>" + 
         "    <sq:Price Change=\"8.0\" Low=\"24.4\" High=\"34.5\">32.0</sq:Price>" + 
         "  </sq:Stock>" +  
         "  <sq:Stock>" + 
         "    <sq:Symbol>VFINX</sq:Symbol>" + 
         "    <sq:Price Change=\"8.0\" Low=\"24.4\" High=\"34.5\">32.0</sq:Price>" + 
         "  </sq:Stock>" + 
         "  <sq:Stock>" + 
         "    <sq:Symbol>HDPMX</sq:Symbol>" + 
         "    <sq:Price Change=\"8.0\" Low=\"24.4\" High=\"34.5\">32.0</sq:Price>" + 
         "  </sq:Stock>" + 
         "</sq:Stocks>");

      XNamespace sq = "http://www.stock_quotes.com";

      var contextStock = 
        from symbol in elem.Elements(sq + "Stock").Elements(sq + "Symbol")
        let price = symbol.ElementsAfterSelf().FirstOrDefault()
        where (decimal)(price.Attribute("Change")) < 1M
        select symbol;

      Array.ForEach(contextStock.ToArray(), o=>Console.WriteLine(o.Value));
      Console.ReadLine();
    }
  }
}
