using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace Mobile_Client_Of_WCFREST
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
