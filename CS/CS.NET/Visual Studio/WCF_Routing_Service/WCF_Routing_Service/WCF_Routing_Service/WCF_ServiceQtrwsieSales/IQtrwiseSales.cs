using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_ServiceQtrwsieSales
{
    [ServiceContract]
    public interface IQtrwiseSales
    {
        [OperationContract]
        List<Sales> GetSalesDetsils();
    }


    [DataContract]
    public class Sales
    {
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public decimal Q1 { get; set; }
        [DataMember]
        public decimal Q2 { get; set; }
        [DataMember]
        public decimal Q3 { get; set; }
        [DataMember]
        public decimal Q4 { get; set; }
    }
}
