using System.ServiceModel;

namespace WCF
{
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        string GetData(string Data);
    }
}
