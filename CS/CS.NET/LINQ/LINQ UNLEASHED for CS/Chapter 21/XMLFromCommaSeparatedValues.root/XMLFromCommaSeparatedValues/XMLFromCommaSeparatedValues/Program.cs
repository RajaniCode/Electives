using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace XMLFromCommaSeparatedValues
{
  class Program
  {
    static void Main(string[] args)
    {
      string all = GetQuotes("MSFT GOOG DELL");
      string[] quotes = 
        all.Replace("<b>", "").Replace("</b>", "")
          .Replace("\"", "").Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);
      

      // Read into an array of strings.
      XElement stockQuotes = new XElement("Root",
            from quote in quotes
            let fields = quote
              .Split(new char[]{',', '-'}, 
                StringSplitOptions.RemoveEmptyEntries)
            select 
                new XElement("Company", fields[0].Trim(), 
                new XElement("LastPrice", fields[2].Trim(), 
                  new XAttribute("Time", fields[1].Trim())), 
                  new XElement("HighToday", fields[3].Trim())));

        stockQuotes.Save("..\\..\\quotes.xml");
        Console.WriteLine(stockQuotes);
        Console.ReadLine();
    }

    static string GetQuotes(string stocks)
    {
		  string url = 
        @"http://quote.yahoo.com/d/quotes.csv?s={0}&f=nlh";

	    HttpWebRequest request = 
        (HttpWebRequest)HttpWebRequest.Create(string.Format(url, stocks));
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      
      using(StreamReader reader = new StreamReader(
        response.GetResponseStream(), Encoding.ASCII))
      {
        try
        {
          return reader.ReadToEnd();
        }
        finally
        {
          // don't need to close the reader because Dispose does
          response.Close();
        }
      }

    }
  }
}
