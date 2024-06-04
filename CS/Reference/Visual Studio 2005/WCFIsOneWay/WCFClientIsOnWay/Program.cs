using System;
using System.Collections.Generic;
using System.Text;

namespace WFCClientIsOneway
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceOneWayProxy objProxy = new InterfaceOneWayProxy();
            objProxy.doHugeTask();
            Console.WriteLine(" I am done at " + DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
