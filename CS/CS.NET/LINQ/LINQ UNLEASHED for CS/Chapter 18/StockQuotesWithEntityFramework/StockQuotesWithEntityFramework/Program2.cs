using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using StockHistoryModel;

namespace StockQuotesWithEntityFramework
{
  class Program2
  {
    static void _Main(string[] args)
    {

      string connectionString =
        ConfigurationManager.ConnectionStrings["StockHistoryEntities"].ConnectionString;

      
      EntityConnection connection = new EntityConnection(connectionString);

      connection.Open();

      EntityCommand command = new EntityCommand(
        "SELECT company.CompanyID, company.CompanyName FROM StockHistoryEntities.Company as company " +
        "WHERE company.CompanySymbol IN {'MSFT', 'F'}", connection);

      DbDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

      while (reader.Read())
      {
        Console.WriteLine("Company name: {0}", reader.GetValue(1));
      }

      Console.ReadLine();

    }
  }
}
