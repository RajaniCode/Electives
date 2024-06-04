//using static System.Console;
using System.ServiceModel;

namespace WCFClient
{   
    public class Client 
    {
        [ServiceContract]
        public interface IWCFService
        {
            [OperationContract]
            string GetData(string data);
        }

        static void Main()
        {
            System.Console.WriteLine("Press Enter to call Server");
            System.Console.ReadLine();
            BasicHttpBinding binding = new BasicHttpBinding();
            // WCFService.cs // host.AddServiceEndpoint(typeof(IWCFService), new BasicHttpBinding(), "");
            ChannelFactory<IWCFService> factory = new ChannelFactory<IWCFService>(binding, new EndpointAddress("http://localhost:8000/WCFService.svc")); 
            IWCFService proxy = factory.CreateChannel();
            string data = proxy.GetData("WCF Client");            
            System.Console.WriteLine(data);
            System.Console.ReadLine();
        }
    }
}