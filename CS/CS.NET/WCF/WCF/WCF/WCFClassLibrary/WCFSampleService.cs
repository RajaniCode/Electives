using System;
using System.ServiceModel;

namespace WCFSampleServices
{
    public class WCFSampleService : IWCFSampleService
    {
        public string GetData(string Data)
        {
            string Message = string.Empty;
            try
            {
                //var v = 1 / Convert.ToInt32(Data);

                Message = "Your Data: " + Data;
            }
            catch
            {
                throw new FaultException("There was a problem with your data.");
            }

            return Message;
        }
    }
}
