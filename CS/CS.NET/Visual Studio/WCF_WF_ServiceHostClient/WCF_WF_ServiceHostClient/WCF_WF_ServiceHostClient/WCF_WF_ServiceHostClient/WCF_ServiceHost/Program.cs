using System;
using System.Linq;
using System.Threading;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;
namespace WCF_ServiceHost
{
    

    class Program
    {
        static void Main(string[] args)
        {
             string MyAddress = "http://localhost:1020/MyDataServiceApp";


           using (WorkflowServiceHost Host = new WorkflowServiceHost(typeof(WCF_ServiceHost.WF_DataService),new Uri(MyAddress)))
           {
               Host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
             //  Host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });  

               Host.AddDefaultEndpoints();

               Host.Open();

               Console.WriteLine("Service is Listening at :" + MyAddress);
               Console.WriteLine("Press ENTER to Exit");
               Console.ReadLine();

                Host.Close ();

               Console.ReadLine();


           }

        }
    }
}
