using System;
using System.Collections.Generic;
using System.Text;

namespace WCFClientMSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceMSMQProxy objProxy = new InterfaceMSMQProxy();
            for (int i=0; i < 10; i++)
            {
                objProxy.sendMessage("HI this is a offline message to the server");
            }
            Console.ReadLine();
        }
    }
}
