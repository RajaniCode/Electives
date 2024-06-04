using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace WCF 
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);
    }

    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }

    public class Host
    {
        static void Main()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            
            Uri serviceUri = new Uri(@"http://localhost:8000");
            ServiceHost host = new ServiceHost(typeof(Service), serviceUri);
            // SOAP endpoint
            host.AddServiceEndpoint(typeof(IService), binding, "Soap");
            // Non-SOAP endpoint
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "Web");
            endpoint.Behaviors.Add(new WebHttpBehavior());
            host.Open();

            // http://localhost:8000/Web/EchoWithGet?s=Hello, world!
            /* 
            Type "http://localhost:8000/Web/EchoWithGet?s=Hello, world!" in the browser and press ENTER
            The URL contains the base address of the service ("http://localhost:8000/"), the relative address of the endpoint (""), 
            the service operation to call ("EchoWithGet"), and a question mark followed by a list of named parameters separated by an ampersand (&)
            */
            Console.WriteLine("Published to endpoint: http://localhost:8000");

            Console.ReadLine();
            host.Close();            
        }
    }
}