//using static System.Console;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF
{
    public class Program
    {
        [ServiceContract]
        public interface IWCFService
        {
            [OperationContract]
            string GetData(string data); // data
        }

        public class WCFService : IWCFService
        {
            public string GetData(string data) { return "WCF Service: " + data; }
        }

        public static void Main()
        {
            string baseAddress = "http://localhost:8000/WCFService.svc";
            ServiceHost host = new ServiceHost(typeof(WCFService), new Uri(baseAddress));
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.AddServiceEndpoint(typeof(IWCFService), new BasicHttpBinding(), "");
            host.Open();
            System.Console.WriteLine("http://localhost:8000/WCFService.svc?wsdl");
            System.Console.WriteLine("Press ENTER to close");
            System.Console.ReadLine();
            host.Close();
        }
    }
}
