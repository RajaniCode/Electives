using System.Runtime.Serialization;
namespace SILV3_RESTDMLClient
{
    public class Employee
    {
        [DataMember]
        public int EmpNo { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int DeptNo { get; set; }
        [DataMember]
        public int Salary { get; set; }
    }
}
