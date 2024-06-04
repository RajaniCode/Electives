using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_SecureService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string [] GetNames();
    }
}
