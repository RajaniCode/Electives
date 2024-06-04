using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
namespace WCFSampleDuplex
{
    class clsMain
    {
        public static void Main()
        {
            ServiceHost objServiceHost;
            Uri httpuri = new Uri("http://localhost:8089/ServiceDuplex");
            objServiceHost = new ServiceHost(typeof(serviceDuplex), httpuri);
            objServiceHost.Open();
            Console.WriteLine("Service Started....");
            Console.ReadLine();
        }
    }
}
