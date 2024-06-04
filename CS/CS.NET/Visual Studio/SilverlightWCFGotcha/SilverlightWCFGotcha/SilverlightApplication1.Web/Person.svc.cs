using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SilverlightApplication1.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Person
    {
        [OperationContract]
        public string GetSurname()
        {
            return "Sheridan";
        }
    }
}
