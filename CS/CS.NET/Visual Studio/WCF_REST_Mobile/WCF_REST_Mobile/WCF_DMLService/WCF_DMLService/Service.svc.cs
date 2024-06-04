using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WCF_DMLService
{
    public class Service : IService
    {

        #region IService Members

        public int InsertEmployee(string empNo, string empName, string salary, string deptNo)
        {
            int Inserterd = 0;
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Insert into Employee Values(@EmpNo,@EmpName,@Salary,@DeptNo)";
            
            Cmd.Parameters.AddWithValue("@EmpNo",Convert.ToInt32(empNo));
            Cmd.Parameters.AddWithValue("@EmpName", empName);
            Cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(salary));
            Cmd.Parameters.AddWithValue("@DeptNo", Convert.ToInt32(deptNo));

            Inserterd = Cmd.ExecuteNonQuery();

            Conn.Close(); 
            return Inserterd;
        }

        public int DeleteEmployee(string empNo)
        {
            int Deleted = 0;
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Delete from Employee where EmpNo=@EmpNo";
            Cmd.Parameters.AddWithValue("@EmpNo",Convert.ToInt32(empNo));
            Deleted = Cmd.ExecuteNonQuery(); 
            return Deleted;
        }

        public Employee[] GetAllEmployee()
        {
            List<Employee> lstEmp = new List<Employee>();  
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Employee",Conn);
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                lstEmp.Add(new Employee() 
                    { 
                         EmpNo=Convert.ToInt32(Reader["EmpNo"]),
                         EmpName = Reader["EmpName"].ToString(),
                         DeptNo = Convert.ToInt32(Reader["DeptNo"]),
                         Salary = Convert.ToInt32(Reader["Salary"])
                    });   
            }
            Reader.Close();

            Conn.Close();

            return lstEmp.ToArray();
        }

        #endregion
    }
}
