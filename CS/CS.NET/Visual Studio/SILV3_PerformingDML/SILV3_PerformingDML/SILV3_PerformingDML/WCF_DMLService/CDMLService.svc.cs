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
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class CDMLService : IDMLService
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        #region IDMLService Members

        public int CreateEmployee(clsEmployee objEmp)
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Cmd = new SqlCommand();
            Conn.Open();

            Cmd.Connection = Conn;
            Cmd.CommandText = "Insert into Employee Values(@EmpNo,@EmpName,@Salary,@DeptNo)";
            Cmd.Parameters.AddWithValue("@EmpNo",objEmp.EmpNo);
            Cmd.Parameters.AddWithValue("@EmpName", objEmp.EmpName);
            Cmd.Parameters.AddWithValue("@Salary", objEmp.Salary);
            Cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);

            int Inserted = Cmd.ExecuteNonQuery();

            if (Inserted > 0)
            {
                Inserted = 1;
            }
            else
            {
                Inserted = 0;
            }

            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();


            return Inserted;
        }



        public int DeleteEmployeeByEmpNo(clsEmployee objEmp)
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Cmd = new SqlCommand();
            Conn.Open();

            Cmd.Connection = Conn;
            Cmd.CommandText = "Delete from Employee where EmpNo=@EmpNo";
            Cmd.Parameters.AddWithValue("@EmpNo", objEmp.EmpNo);

            int Deleted = Cmd.ExecuteNonQuery();
            if (Deleted > 0)
            {
                Deleted = 1;
            }
            else
            {
                Deleted = 0;
            }
            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();
            return  Deleted;
        }

        public clsEmployee[] GetAllEmployee()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Cmd = new SqlCommand();
            Conn.Open();

            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Employee";
            SqlDataReader Reader = Cmd.ExecuteReader();
            int i = 0;
            
            DataTable DtEmp = new DataTable ();
            DtEmp.Load (Reader);
            clsEmployee[] arrEmp = new clsEmployee[DtEmp.Rows.Count];

            foreach (DataRow Dr in DtEmp.Rows)
            {
                arrEmp[i] = new clsEmployee();
                arrEmp[i].EmpNo = Convert.ToInt32(Dr["EmpNo"]);
                arrEmp[i].EmpName = Dr["EmpName"].ToString();
                arrEmp[i].DeptNo = Convert.ToInt32(Dr["DeptNo"]);
                arrEmp[i].Salary = Convert.ToInt32(Dr["Salary"]);
                i = i + 1;
            }
            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();
            return arrEmp;

 
        }

        #endregion
 


        public int UpdateEmployee(clsEmployee objEmp)
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Cmd = new SqlCommand();
            Conn.Open();

            Cmd.Connection = Conn;
            Cmd.CommandText = "Update Employee Set EmpName=@EmpName,Salary=@Salary,DeptNo=@DeptNo where EmpNo=@EmpNo";
            Cmd.Parameters.AddWithValue("@EmpNo", objEmp.EmpNo);
            Cmd.Parameters.AddWithValue("@EmpName", objEmp.EmpName);
            Cmd.Parameters.AddWithValue("@Salary", objEmp.Salary);
            Cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);

            int Updated = Cmd.ExecuteNonQuery();

            if (Updated > 0)
            {
                Updated = 1;
            }
            else
            {
                Updated = 0;
            }

            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();
            return Updated;
        }
 
    }
}
