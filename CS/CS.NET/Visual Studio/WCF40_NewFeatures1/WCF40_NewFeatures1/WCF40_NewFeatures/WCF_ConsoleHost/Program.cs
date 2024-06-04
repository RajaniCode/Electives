using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ServiceModel;
namespace WCF_ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost Host = new ServiceHost(typeof(WCF_NewService.Service), new Uri("http://localhost:7777/Services/Hello"),
            //                                                                                                      new Uri("net.tcp://localhost:7778/Services/Hello"));



           ServiceHost Host = new ServiceHost(typeof(WCF_NewService.Service),new Uri("http://localhost:7777/Services/Hello") );
            Host.Open();

           
            Console.WriteLine("Started....");   
            Console.ReadLine();
            Host.Close();
            Console.ReadLine(); 
        }
    }
}
