using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WCF_DataService
{
    public class clsDataAccess
    {
        public Employee[] GetAllEmployee()
        {
            Employee[] arrEmp = null;
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            SqlCommand Cmd = new SqlCommand();
            Conn.Open();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Employee";
            SqlDataReader Reader = Cmd.ExecuteReader();
            DataTable DtEmp = new DataTable();
            DtEmp.Load(Reader);
            arrEmp = new Employee[DtEmp.Rows.Count];
            int i = 0;
            foreach (DataRow Dr in DtEmp.Rows)
            {
                arrEmp[i] = new Employee();
                arrEmp[i].EmpNo = Convert.ToInt32(Dr["EmpNo"]);
                arrEmp[i].EmpName = Dr["EmpName"].ToString();
                arrEmp[i].Salary = Convert.ToInt32(Dr["Salary"]);
                arrEmp[i].DeptNo = Convert.ToInt32(Dr["DeptNo"]);
                i = i + 1;
            }


            return arrEmp;
        }
    }


    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }
}