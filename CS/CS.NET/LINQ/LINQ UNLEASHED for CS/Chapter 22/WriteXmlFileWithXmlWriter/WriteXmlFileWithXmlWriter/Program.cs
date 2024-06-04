using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace WriteXmlFileWithXmlWriter
{
  class Program
  {
    static void Main(string[] args)
    {
      string all = GetQuotes("MSFT GOOG DELL");
      string[] quotes =
        all.Replace("<b>", "").Replace("</b>", "")
          .Replace("\"", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

      using (XmlTextWriter writer = new XmlTextWriter("quotes.xml", System.Text.Encoding.UTF8))
      {
        writer.WriteStartDocument(true);
        writer.WriteStartElement("Root", "");

        foreach (string str in quotes)
        {
          string[] fields = 
            str.Split(new char[]{',', '-'}, StringSplitOptions.RemoveEmptyEntries);

          writer.WriteStartElement("Company");
          writer.WriteValue(fields[0].Trim());
          writer.WriteStartElement("LastPrice");
          writer.WriteAttributeString("Time", fields[1].Trim());
          writer.WriteValue(fields[2].Trim());
          writer.WriteEndElement();
          writer.WriteElementString("HighToday", fields[3].Trim());
          writer.WriteEndElement();
          

        }

        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
      }
    }

    static string GetQuotes(string stocks)
    {
      string url =
        @"http://quote.yahoo.com/d/quotes.csv?s={0}&f=nlh";

      HttpWebRequest request =
        (HttpWebRequest)HttpWebRequest.Create(string.Format(url, stocks));
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();

      using (StreamReader reader = new StreamReader(
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

