using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_DMLService
{
    [ServiceContract]
    public interface IDMLService
    {
        [OperationContract]
        int CreateEmployee(clsEmployee objEmp);
        [OperationContract]
        int UpdateEmployee(clsEmployee objEmp);
        [OperationContract]
        int DeleteEmployeeByEmpNo(clsEmployee objEmp);
        [OperationContract]
        clsEmployee[] GetAllEmployee();
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
