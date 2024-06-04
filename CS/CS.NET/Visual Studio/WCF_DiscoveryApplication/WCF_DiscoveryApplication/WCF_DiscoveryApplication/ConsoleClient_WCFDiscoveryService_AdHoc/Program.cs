using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Discovery;
using System.ServiceModel;

namespace ConsoleClient_WCFDiscoveryService_AdHoc
{
    class Program
    {

        static void Main(string[] args)
        {
            string opt = "y";
            while (opt == "y")
            {
                Console.WriteLine("Press any key when service is ready:");
                Console.ReadLine();

                #region Code For Discovery
                //Step 1: Create a DiscoveryClient
                DiscoveryClient discClient = new DiscoveryClient("udpDiscoveryEndpoint");
                //Step 2: Now Search for the Contract using 'FindCriteria'
                FindCriteria fCriteria = new FindCriteria(typeof(MyRef.IService));
                FindResponse fResponse = discClient.Find(fCriteria);

                EndpointAddress address = fResponse.Endpoints[0].Address;

                #endregion


                //Step 3 :Create the Proxy object
                MyRef.ServiceClient Proxy = new ConsoleClient_WCFDiscoveryService_AdHoc.MyRef.ServiceClient("ClientEdp");

                //Step 4: Associate the discovered Endpoint Address with Proxy
                Proxy.Endpoint.Address = address;

                Console.WriteLine("The discovered address is {0} on which method is called", address);

                Console.WriteLine("Res = " + Proxy.GetData(1000));
                Console.WriteLine("COntinte ?");
                opt = Console.ReadLine(); 
            }
            Console.ReadLine(); 
        }
    }
}
