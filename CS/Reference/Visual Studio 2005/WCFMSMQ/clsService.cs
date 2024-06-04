using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Threading;

namespace WCFMSMQ
{
    [ServiceContract()]
    public interface InterfaceMSMQ
    {
        [OperationContract(IsOneWay=true)]
        void sendMessage(string strMessage);
    }
  
    public class serviceMSMQ : InterfaceMSMQ
    {
        public void sendMessage(string strMessage)
        {
            Console.WriteLine(" Received Message " + strMessage + "\n");
 
        }
    }
}

    