using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using StockHistoryModel;
using System.Data.Objects;

namespace StockQuotesWithEntityFramework
{
  class Program3
  {
    static void Main(string[] args)
    {
      string[] stocks = { "MSFT", "GOOG", "DELL", "GM", "F",
                        "CSCO", "INTC"};

      WebClient client = new WebClient();
      for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < stocks.Length; j++)
        {
          string result = client.DownloadString(
            string.Format("http://download.finance.yahoo.com/d/?s={0}&f=nsolph",
            stocks[j]));
          UpdatePriceHistory(result);
          Console.WriteLine(result);
          System.Threading.Thread.Sleep(100);
        }
      }

      Console.ReadLine();
    }
    
    /// <summary>
    /// Use LINQ to XML to get data
    /// Use LINQ to Entities to write data to database
    /// </summary>
    /// <param name="result"></param>
    static void UpdatePriceHistory(string result)
    {
      XElement xml = CreateXMLElement(result);
      Console.WriteLine(xml.ToString());

      StockHistoryEntities entities = new StockHistoryEntities();

      PriceHistory quote = CreatePriceHistory(xml);
      

      string name = xml.Element("Name").Value;
      string symbol = xml.Element("Symbol").Value;

#if (!USE_CLASSES)
      var results = from c in entities.Company
                    where c.CompanySymbol == symbol 
                    select c;
#else
      ObjectParameter param = new ObjectParameter("symbol", symbol);
      ObjectQuery<Company> results = entities.Company.Where("it.CompanySymbol = @symbol", param);
#endif
      Company company;

      if (results.Count() == 0)
      {
        company = new Company();
        company.CompanyName = name;
        company.CompanySymbol = symbol;
        entities.AddToCompany(company);
      }
      else
      {
        company = results.First();
      }

      company.PriceHistory.Add(quote);
      entities.SaveChanges(true);
    }
      
      
    static PriceHistory CreatePriceHistory(XElement xml)
    {
      Func<XElement, decimal?> toDecimal =
        val =>
        {
          decimal? temp = (decimal?)val;
          return Math.Round((decimal)val, 2, MidpointRounding.ToEven);
        };
        
        
      PriceHistory quote = new PriceHistory();
      quote.OpeningPrice = toDecimal(xml.Element("Open"));
      quote.WhenRequested = DateTime.Now;
      quote.LastTradeTime = Convert.ToDateTime(xml.Element("LastTradeTime").Value);
      quote.LastTradePrice = toDecimal(xml.Element("LastTradePrice"));
      quote.CurrentPrice = toDecimal(xml.Element("Price"));
      quote.TodaysHigh = toDecimal(xml.Element("High"));
     
      return quote;
    }

    static XElement CreateXMLElement(string result)
    {
      // remove unneeded HTML tags and split into fields
      result = result.Replace("<b>", "").Replace("</b>", "");
      string[] data = result.Split(
        new char[] { ',', '"', '-' }, StringSplitOptions.RemoveEmptyEntries);

      // use functional construction to create XML document
      return new XElement("Quote", 
        new XElement("Name", data[0].Trim()),
        new XElement("Symbol", data[1].Trim()),
        new XElement("Open", data[2].Trim()),
        new XElement("LastTradeTime", data[3].Trim()),
        new XElement("LastTradePrice", data[4].Trim()),
        new XElement("Price", data[5].Trim()),
        new XElement("High", data[6].Trim())
        );
     
    }
  }
}


