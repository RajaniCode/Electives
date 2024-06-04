using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Threading;
namespace WCFSampleDuplex
{
    [ServiceContract(Namespace="http://WCFSampleDuplex",Session=true ,
                   CallbackContract = typeof(InterfaceDuplexCallBack))]
    public interface InterfaceDuplex
    {
        [OperationContract(IsOneWay=true)]
        void doHugeTask();
    }
    public interface InterfaceDuplexCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Completed();
    }
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class serviceDuplex : InterfaceDuplex
    {
        public void doHugeTask()
        {
            Console.WriteLine("Called by client at" + DateTime.Now.ToString());
            Thread.Sleep(5000);
            Console.WriteLine("I am done at " + DateTime.Now.ToString());
            OperationContext.Current.GetCallbackChannel<InterfaceDuplexCallBack>().Completed();
        }
        
    }
}

    