using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ServiceModel;
namespace WFCClientDuplex
{
    public class HandleCallBack : InterfaceDuplexCallback
    {
        public void Completed()
        {
            Console.WriteLine(" Called by the server at " + DateTime.Now.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext objInstanceContext = new InstanceContext(new HandleCallBack());
            InterfaceDuplexProxy objDuplexProxy = new InterfaceDuplexProxy(objInstanceContext);
            objDuplexProxy.doHugeTask();
            Console.ReadLine();
            objDuplexProxy.Close();
        }
    }
}
