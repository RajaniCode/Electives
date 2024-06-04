using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ2CountryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country();
            string cntryCode = "IN";
            IEnumerable<CountryInfo> cntryInfo = country.SearchCountry(cntryCode);
            foreach (var c in cntryInfo)
            {
                Console.WriteLine("You searched for {0}. " +
                "The population of {0} is {1} and its capital is {2}. " +
                    "The CurrencyCode for {0} is {3} and it's area in Sq. Km is {4}",
                 c.CountryName, c.Population, c.Capital,
                 c.CurrencyCode, c.AreaSqKm);    
            }
            Console.ReadLine();
        }
    }
}
