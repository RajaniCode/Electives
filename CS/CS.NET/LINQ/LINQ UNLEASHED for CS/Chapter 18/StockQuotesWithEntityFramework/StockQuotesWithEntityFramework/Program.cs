using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace StockQuotesWithEntityFramework
{
  class Program
  {
    // rename to use the other Main
    static void _Main(string[] args)
    {
      string[] stocks = { "MSFT", "GOOG", "DELL", "GM", "F",
                        "CSCO", "INTC"};

      WebClient client = new WebClient();
      for (int i = 0; i < 25; i++)
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

    static void UpdatePriceHistory(string result)
    {
      // get rid of goofy characters
      result = result.Replace("<b>", "").Replace("</b>", "");

      // split into separate fields; we still need to split 
      // last trade time and price
      string[] data = result.Split(
        new char[]{',', '"', '-'}, StringSplitOptions.RemoveEmptyEntries);
      
      if(data.Length != 7) return;
      string name = data[0].Trim();
      string symbol = data[1].Trim();
      string open = data[2].Trim();
      string lastTradeTime = data[3].Trim();
      string lastTradePrice = data[4].Trim();
      string price = data[5].Trim();
      string high = data[6].Trim();

      UpdatePriceHistory(name, symbol, open, 
        lastTradeTime, lastTradePrice, price, high);
    }

    private static void UpdatePriceHistory(string name, string symbol, 
      string open, string lastTradeTime, 
      string lastTradePrice, string price, string high)
    {
      UpdatePriceHistory(name, symbol, ToDecimal(open),
        ToDateTime(lastTradeTime), ToDecimal(lastTradePrice),
        ToDecimal(price), ToDecimal(high));
    }

    private static void UpdatePriceHistory(string name, string symbol, 
      decimal open, DateTime lastTradeTime, 
      decimal lastTradePrice, decimal price, decimal high)
    {
      string connectionString = 
        "Data Source=.\\SQLExpress;Initial Catalog=StockHistory;" + 
        "Integrated Security=True;Pooling=False";
      
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("InsertQuote", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CompanyName", name);
        command.Parameters.AddWithValue("@CompanySymbol", symbol);
        command.Parameters.AddWithValue("@WhenRequested", DateTime.Now);
        SqlParameter p1 = command.Parameters.AddWithValue("@OpeningPrice", open);
        p1.DbType = DbType.Decimal;
        p1.Precision = 18;
        p1.Scale = 2;

        SqlParameter p2 = command.Parameters.AddWithValue("@LastTradePrice", lastTradePrice);
        p2.DbType = DbType.Decimal;
        p2.Precision = 18;
        p2.Scale = 2;

        command.Parameters.AddWithValue("@LastTradeTime", lastTradeTime);
        SqlParameter p3 = command.Parameters.AddWithValue("@CurrentPrice", price);
        p3.DbType = DbType.Decimal;
        p3.Precision = 18;
        p3.Scale = 2;

        SqlParameter p4 = command.Parameters.AddWithValue("@TodaysHigh", high);
        p4.DbType = DbType.Decimal;
        p4.Precision = 18;
        p4.Scale = 2;

        
        command.ExecuteNonQuery();
      }
    }

    private static decimal ToDecimal(string val)
    {
      return Convert.ToDecimal(val);
    }

    private static DateTime ToDateTime(string val)
    {
      return Convert.ToDateTime(val);
    }
  }
}

//http://download.finance.yahoo.com/d/?s=msft&f=nsolph
