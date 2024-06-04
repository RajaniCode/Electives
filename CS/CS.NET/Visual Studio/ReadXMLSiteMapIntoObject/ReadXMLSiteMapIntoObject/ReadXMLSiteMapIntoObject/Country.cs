using System.Collections.Generic;

namespace ReadXMLSiteMapIntoObject
{
    class Country
    {
        public string countryName { get; set; }
        public IList<States> states = new List<States>();
    }

    class States
    {
        public string stateName { get; set; }
    }

}
