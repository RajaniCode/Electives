using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockHistoryModel;

namespace StockQuotesWithEntityFramework
{
  class Program1
  {
    // rename to use the other main
    static void _Main(string[] agrs)
    {
      StockHistoryEntities stockHistory = new StockHistoryEntities();

      var quotes = from quote in stockHistory.PriceHistory
                   orderby quote.Company.CompanySymbol
                   select new {
                     Symbol=quote.Company.CompanySymbol, 
                     Name=quote.Company.CompanyName,
                     LastPrice=quote.LastTradePrice, 
                     Time=quote.LastTradeTime};

      Array.ForEach(quotes.ToArray(), 
        s => Console.WriteLine(s));
      Console.ReadLine();

    }
  }
}
