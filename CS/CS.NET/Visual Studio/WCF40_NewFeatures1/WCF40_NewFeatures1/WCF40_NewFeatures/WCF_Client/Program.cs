using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCF_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            MyRef.ServiceClient Proxy = new WCF_Client.MyRef.ServiceClient("NetTcpBinding_IService");
            Console.WriteLine("Result = " + Proxy.GetData(100) );  
            Console.ReadLine();  
        }
    }
}
