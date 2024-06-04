using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_DataService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        clsEmployee[] GetAllEmployees();
        [OperationContract]
        int InsertEmployee(clsEmployee objEmp);

    }

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

   
}
