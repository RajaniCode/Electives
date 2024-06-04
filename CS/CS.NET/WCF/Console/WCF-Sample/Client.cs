using static System.Console;
using System.ServiceModel;

namespace WCFClient
{   
    public class Client 
    {
        [ServiceContract] 
        public interface IWCFService
        {
            [OperationContract]
            string GetData(string data); // data
        }

        static void Main()
        {
            WriteLine("Press Enter to call Server");
            ReadLine();
            BasicHttpBinding binding = new BasicHttpBinding();
            // Service.cs // host.AddServiceEndpoint(typeof(IWCFService), binding, "Soap");
            ChannelFactory<IWCFService> factory = new ChannelFactory<IWCFService>(binding, new EndpointAddress("http://localhost:8000/Soap")); 
            // ChannelFactory<IWCFService> factory = new ChannelFactory<IWCFService>(binding, new EndpointAddress("http://localhost:8000/Web")); 
            IWCFService proxy = factory.CreateChannel();
            string data = proxy.GetData("Hello World!");            
            WriteLine(data);
            ReadLine();
        }
    }
}