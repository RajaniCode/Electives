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
            Uri baseAddress = new Uri("http://localhost:8080//service1");
            objServiceHost = new ServiceHost(typeof(serviceGetCost),baseAddress);
            objServiceHost.Open();
            Console.WriteLine("Service Started....");
            Console.ReadLine();
        }
    }
}
