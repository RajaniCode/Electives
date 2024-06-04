using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_ServiceSalesData
{
    [ServiceContract]
    public interface ISalesData
    {
        [OperationContract]
        List<SalesData> GetSalesDetsils();
    }


    [DataContract]
    public class SalesData
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int SalesQty { get; set; }
    }
}
