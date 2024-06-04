using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace clsDataContracts
{
    [DataContract]
    public class clsEmployee
    {
        [DataMember]
        public int EmpNo { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int Salary { get; set; }
        [DataMember]
        public int DeptNo { get; set; }
    }

    [DataContract]
    public class clsSales
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
    [DataContract]
    public class clsSalesData
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int SalesQty { get; set; }
    }

    [DataContract]
    public class clsStatewiseSales
    {
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public decimal SalesQuantity { get; set; }
    }
}
