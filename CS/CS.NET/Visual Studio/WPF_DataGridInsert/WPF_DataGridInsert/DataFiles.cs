using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace WPF_DataGridInsert
{
    public class clsEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }

    public class DataAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI"); 
        }

        public ObservableCollection<clsEmployee> GetAllEmployee()
        {
            ObservableCollection<clsEmployee> EmpCol = new ObservableCollection<clsEmployee>();  
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Employee";
            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                EmpCol.Add(new clsEmployee() 
                {
                  EmpNo=Convert.ToInt32(Reader["EmpNo"]),
                  EmpName = Reader["EmpName"].ToString (),
                  Salary = Convert.ToInt32(Reader["Salary"]),
                   DeptNo = Convert.ToInt32(Reader["DeptNo"])
                }); 
            }

            Conn.Close();
            return EmpCol;
        }

        public void InsertEmployee(clsEmployee objEmp)
        {
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Insert into Employee Values(@EmpNo,@EmpName,@Salary,@DeptNo)";
            Cmd.Parameters.AddWithValue("@EmpNo", objEmp.EmpNo);
            Cmd.Parameters.AddWithValue("@EmpName", objEmp.EmpName);
            Cmd.Parameters.AddWithValue("@Salary", objEmp.Salary);
            Cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);
            Cmd.ExecuteNonQuery(); 
            Conn.Close();
        }
    }
}
