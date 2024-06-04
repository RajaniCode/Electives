using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LINQ2CountryInfo
{
    class Country
    {
        public IEnumerable<CountryInfo> SearchCountry(string countryCode)
        {
            string uri = Uri.EscapeUriString(countryCode);
            string url = FormatUrl(uri);
            XDocument xdoc = XDocument.Load(url);
            IEnumerable<CountryInfo> results =
            from cntry in xdoc.Descendants("country")
            select new CountryInfo
            {
                CountryName = cntry.Element("countryName").Value,
                Capital = cntry.Element("capital").Value,
                AreaSqKm = Convert.ToSingle(cntry.Element("areaInSqKm").Value),
                Population = Convert.ToInt64(cntry.Element("population").Value),
                CurrencyCode = cntry.Element("currencyCode").Value
            };
            return results;
        }

        string FormatUrl(string cCode)
        {
            return "http://ws.geonames.org/countryInfo?" +
                "country=" + cCode;
        }
    }

    class CountryInfo
    {
        public string CountryName { get; set; }
        public long Population { get; set; }
        public string Capital { get; set; }
        public string CurrencyCode { get; set; }
        public float AreaSqKm { get; set; }        
    }
}