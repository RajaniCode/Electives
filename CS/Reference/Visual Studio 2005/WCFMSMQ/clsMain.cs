using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Messaging;
using System.Configuration;

namespace WCFMSMQ 

{
    class clsMain
    {
        public static void Main()
        {
            string strQueueName = ConfigurationManager.AppSettings["MSMQName"];
            // create the queue if it does not exists
            if (!MessageQueue.Exists(strQueueName))
            {
                MessageQueue.Create(strQueueName, true);
            }
            Uri objUri = new Uri("http://localhost:8000/ServiceMSMQ/service");
            ServiceHost objServiceHost = new ServiceHost(typeof(serviceMSMQ),objUri);
            objServiceHost.Open();
            Console.Write("Service Started on " + DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
