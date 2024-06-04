using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCF_AdHocDiscoveryHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost Host = new ServiceHost(typeof(WCF_ServiceFor_AdHoc_Discovery.CService));
            Host.Open();
            Console.WriteLine("Service Started....");
            Console.ReadLine();
            Host.Close();
            Console.ReadLine(); 

        }
    }
}
