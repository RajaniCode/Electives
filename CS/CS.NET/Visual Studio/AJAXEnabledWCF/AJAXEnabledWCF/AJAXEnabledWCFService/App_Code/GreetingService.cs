using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

[ServiceContract(Namespace = "GreetNM")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class GreetingService
{
	// Add [WebGet] attribute to use HTTP GET
	[OperationContract]
	public void DoWork()
	{
		// Add your operation implementation here
		return;
	}

	// Add more operations here and mark them with [OperationContract]
    [OperationContract]
    public string GreetUser(string uname)
    {
        return "Hello " + uname;
    }

}
