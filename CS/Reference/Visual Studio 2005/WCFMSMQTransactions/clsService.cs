using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Threading;

namespace WCFMSMQTransactions
{
    [ServiceContract()]
    public interface InterfaceMSMQ
    {
        [OperationContract(IsOneWay=true)]
        void sendMessage(string strMessage);
    }
    
    public class serviceMSMQ : InterfaceMSMQ
    {
        [OperationBehavior(TransactionScopeRequired=true,TransactionAutoComplete=true)]
        public void sendMessage(string strMessage)
        {
            Console.WriteLine(" Received Message " + strMessage + "\n");
        }
    }
}

    