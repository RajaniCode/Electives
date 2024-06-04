using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Routing;

namespace WCF_TempRoutingService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost Host = new ServiceHost(typeof(RoutingService));
            try
            {
                Host.Open();
                Console.WriteLine("Routing Service is Started...............");
                Console.ReadLine();
                Host.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
