using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
namespace WCFSampleGetCost
{
    class clsMain
    {
        public static void Main()
        {
            ServiceHost objServiceHost;
            Uri httpUri = new Uri("http://localhost:8088/servicemulti");
            Uri tcpUri = new Uri("net.tcp://localhost:8089/servicemulti");
            objServiceHost = new ServiceHost(typeof(serviceGetCost),tcpUri,httpUri);
            objServiceHost.Open();
            Console.WriteLine("Service Started....");
            Console.ReadLine();
        }
    }
}
