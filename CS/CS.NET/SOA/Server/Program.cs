using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting service...");

            Type serviceType = typeof(RandomDelayService);

            ServiceHost host = new ServiceHost(serviceType, new Uri[] { new Uri("http://localhost:8080/") });

            // allow our service to be called through a simple Http requests.
            host.AddServiceEndpoint(serviceType, new BasicHttpBinding(), "RandomDelayService");

            // the following behavior sets up metadata exchange, so that the service
            // description (metadata) can be viewed in a browser. It also allows
            // Visual Studio to automatically generate a proxy class for you so that
            // you can just add this service using the Add Service tool under References.
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(behavior);
            host.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "MEX");

            // start the service...
            host.Open();

            Console.WriteLine("Service is ready, press any key to exit.");
            Console.ReadKey();
        }
    }

    [ServiceContract]
    class RandomDelayService
    {
        [OperationContract]
        string RandomDelay()
        {
            // hour:minute:second:milliseconds
            string startTime = DateTime.Now.ToString("hh:mm:ss:ffff");

            // generate a randome number between 1 and 10
            Random random = new Random();
            int wait = random.Next(1, 10);

            // pause the current thread for a randome number of seconds
            // (between 1 and 10 seconds
            Thread.Sleep(wait * 1000);

            // return the start time, seconds waited, and end time
            // returning both the start and end time can be used to demonstrate
            // the multi-threaded nature of WCF. Using a client that quickly
            // starts multiple operations will show very close start times,
            // demonstrating that multiple operations were running at the same time.
            return string.Format("Started at {0} and waited {1} second(s), the time is {2}", startTime, wait, DateTime.Now.ToString("hh:mm:ss.ffff"));
        }
    }
}
