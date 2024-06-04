using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CommaSeparatedFileFromXML
{
  class Program
  {
    static void Main(string[] args)
    {
      XElement blackjackStats = XElement.Load("..\\..\\CurrentStats.xml");
      string file = 
        (from elem in blackjackStats.Elements("Player")
        let statistics = elem.Element("Statistics")
        select string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}" +
        "{9},{10},{11},{12},{13},{14},{15}{16}",
          (string)elem.Attribute("Name"),
          (string)statistics.Element("AverageAmountLost"),
          (string)statistics.Element("AverageAmountWon"),
          (string)statistics.Element("Blackjacks"),
          (string)statistics.Element("Losses"),
          (string)statistics.Element("NetAverageWinLoss"),
          (string)statistics.Element("NetWinLoss"),
          (string)statistics.Element("PercentageOfBlackJacks"),
          (string)statistics.Element("PercentageOfLosses"),
          (string)statistics.Element("PercentageOfPushes"),
          (string)statistics.Element("PercentageOfWins"),
          (string)statistics.Element("Pushes"),
          (string)statistics.Element("Surrenders"),
          (string)statistics.Element("TotalAmountLost"),
          (string)statistics.Element("TotalAmountWon"),
          (string)statistics.Element("Wins"),
          Environment.NewLine)).
            Aggregate(new StringBuilder(), 
              (builder, str) => builder.Append(str), 
                builder => builder.ToString());

        Console.WriteLine(file);
        Console.ReadLine();
  
    }
  }
}
