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
        Employee[] GetAllEmployees();
        [OperationContract]
        void CreateEmployee(Employee objEmp);
    }


    [DataContract]
    public class Employee
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
