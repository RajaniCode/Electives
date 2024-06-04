using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

using BusinessDataObject;
namespace WPF_WCFServiceHost
{
    //MsmqMessage : USed for Encapsulating message sent and received over
    //MSMQ integrated channel to and from Existing MSMQ applciation
    [ServiceContract]
    [ServiceKnownType(typeof(PatientMaster))]   
    public interface IService
    {
        [OperationContract(IsOneWay=true,Action="*")]
        void RegisterPatient(MsmqMessage<PatientMaster> objPatient);
    }
}
