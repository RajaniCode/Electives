using static System.Console;
using System;
using System.ServiceModel;
// using System.ServiceModel.Description;
// using System.ServiceModel.Web; //

namespace WCF 
{
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        // [WebGet] //
        string GetData(string data); // data
    }

    public class WCFService : IWCFService
    {
        public string GetData(string data)
        {
            WriteLine("Message Received : {0}", data);
            WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString());
            return string.Format("Message from Server {0}", data);
        }

        static void Main()
        {
            BasicHttpBinding binding = new BasicHttpBinding();            
            Uri serviceUri = new Uri("http://localhost:8000");
            ServiceHost host = new ServiceHost(typeof(WCFService), serviceUri);
            // SOAP endpoint
            host.AddServiceEndpoint(typeof(IWCFService), binding, "Soap");
            // Non-SOAP endpoint
            //ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IWCFService), new WebHttpBinding(), "Web");
            //endpoint.Behaviors.Add(new WebHttpBehavior());
            host.Open();
            WriteLine("Service is hosted to the Server: http://localhost:8000");
            WriteLine("Press Enter to close");
            ReadLine();
            host.Close();            
        }
    }
}