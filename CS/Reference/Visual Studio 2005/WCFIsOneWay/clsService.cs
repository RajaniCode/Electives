using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Threading;
namespace WCFSampleIsOneWay
{
    [ServiceContract()]
    public interface InterfaceOneWay
    {
        [OperationContract(IsOneWay=true)]
        void doHugeTask();
    }
    
    public class serviceIsOneWay : InterfaceOneWay
    {
        public void doHugeTask()
        {
            Console.WriteLine("I have still not finished my work");
            Thread.Sleep(5000);
            Console.WriteLine("I am done at " + DateTime.Now.ToString());
        }
    }
}

    