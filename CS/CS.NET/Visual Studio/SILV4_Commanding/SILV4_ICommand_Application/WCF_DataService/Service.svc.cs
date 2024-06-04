using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


using System.Data;
using System.Data.SqlClient; 

namespace WCF_DataService
{
    public class Service : IService
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public Service()
        {
           Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
        }

        public clsEmployee[] GetAllEmployees()
        {
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Employee";
            SqlDataReader Reader = Cmd.ExecuteReader();
            int i = 0;

            DataTable DtEmp = new DataTable();
            DtEmp.Load(Reader); 

            clsEmployee[] arrEmp = new clsEmployee[DtEmp.Rows.Count];

            foreach (DataRow Dr in DtEmp.Rows)
            {
                arrEmp[i] = new clsEmployee() 
                {
                      EmpNo = Convert.ToInt32(Dr["EmpNo"]),
                      EmpName = Dr["EmpName"].ToString(),
                      Salary = Convert.ToInt32(Dr["Salary"]),
                      DeptNo = Convert.ToInt32(Dr["DeptNo"])
                };
                i++;
            }
            Conn.Close(); 
            return arrEmp;
        }

        public int InsertEmployee(clsEmployee objEmp)
        {

            int Res = 0;
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            
            Cmd.CommandText = "Insert into Employee Values(@EmpNo,@EmpName,@Salary,@DeptNo)";
            
            Cmd.Parameters.AddWithValue("@EmpNo",objEmp.EmpNo);
            Cmd.Parameters.AddWithValue("@EmpName", objEmp.EmpName);
            Cmd.Parameters.AddWithValue("@Salary", objEmp.Salary);
            Cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);


            Res = Cmd.ExecuteNonQuery();

            if (Res > 0)
            {
                Res = 1;
            }

            Conn.Close();

            return Res; 
        }
    }
}
