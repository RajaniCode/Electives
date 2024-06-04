using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_DataService
{
    public class Service : IService
    {

        public clsEmployee[] GetAllEmployees()
        {
            return new clsEmployee[] 
            {
                 new clsEmployee(){EmpNo=101,EmpName="Emp_1"},
                 new clsEmployee(){EmpNo=102,EmpName="Emp_2"},
                 new clsEmployee(){EmpNo=103,EmpName="Emp_3"},
                 new clsEmployee(){EmpNo=104,EmpName="Emp_4"},
                 new clsEmployee(){EmpNo=105,EmpName="Emp_5"},
            };

        }
    }
}
