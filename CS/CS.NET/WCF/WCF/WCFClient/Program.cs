using System;
using System.ServiceModel;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFServiceClient client = new WCFServiceClient();

            Console.WriteLine(client.GetData("Rajani"));

            Console.ReadKey();
         
        }
    }
}
