using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace WCFSampleServices
{
    [ServiceContract]
    public interface IWCFSampleService
    {
        [OperationContract]
        string GetData(string Data);
    }
}
