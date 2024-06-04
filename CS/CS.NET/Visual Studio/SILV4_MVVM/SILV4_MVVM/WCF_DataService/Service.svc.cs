using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
 

namespace WCF_DataService
{
    public class Service : IService
    {

        public Employee[] GetAllEmployees()
        {
            DbManager.OpenConnection();

            string strEmp = "Select * from Employee";

            DataTable dtVal = DbManager.GetAllRecords(strEmp);

            Employee [] arrEmp = new  Employee[dtVal.Rows.Count];

            int i = 0;
            foreach (DataRow Dr in dtVal.Rows)
            {
                arrEmp[i] = new Employee() 
                {
                     EmpNo = Convert.ToInt32(Dr["EmpNo"]),
                     EmpName = Dr["EmpName"].ToString(),
                     Salary = Convert.ToInt32(Dr["Salary"]),
                     DeptNo= Convert.ToInt32(Dr["DeptNo"]) 
                };
                i++;
            }

            DbManager.CloseConnection();

            return arrEmp;
        }

        public void CreateEmployee(Employee objEmp)
        {
            DbManager.OpenConnection();

            string strInsert = "Insert into Employee Values (";
            strInsert += objEmp.EmpNo + ",'" + objEmp.EmpName + "',";
            strInsert += objEmp.Salary + "," + objEmp.DeptNo + ")";

            DbManager.PerformDML(strInsert); 

            DbManager.CloseConnection();
        }
    }
}
