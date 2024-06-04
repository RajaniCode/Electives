using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ReadXMLSiteMapIntoObject
{
class Program
{
static void Main(string[] args)
{
XDocument xdoc = XDocument.Load("../../CountryState.xml");
List<Country> countries = (from cntry in xdoc.Element("Countries").Elements("Country")
               select new Country
               {
                   countryName = cntry.Element("CountryName").Value,
                   states = (from ste in cntry.Element("States").Elements("State")
                             select new States
                             {
                                 stateName = ste.Value
                             }).ToList()
               }).ToList();


    foreach (var co in countries)
    {
         Console.WriteLine(co.countryName);
        foreach (var st in co.states)
        {
            Console.WriteLine(st.stateName);
        }
}

Console.ReadLine();
}
}
}
