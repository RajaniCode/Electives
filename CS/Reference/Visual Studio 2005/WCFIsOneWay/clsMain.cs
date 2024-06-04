using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
namespace WCFSampleIsOneWay 
{
    class clsMain
    {
        public static void Main()
        {
            ServiceHost objServiceHost;
            Uri tcpUri = new Uri("net.tcp://localhost:8089/serviceisoneway");
            objServiceHost = new ServiceHost(typeof(serviceIsOneWay), tcpUri);
            objServiceHost.Open();
            Console.WriteLine("Service Started....");
            Console.ReadLine();
        }
    }
}
