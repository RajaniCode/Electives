using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASPCS2008SimpleModal
{
    public partial class HelperMethods
    {
        // METHOD: GetEmployee
        public static Employee GetEmployee(SqlDataReader reader)
        {
            Employee emp = new Employee();
            if (reader.IsClosed)
                reader.Read();

            emp.ID = reader["employeeid"].ToString();
            emp.FirstName = reader["firstname"].ToString();
            emp.LastName = reader["lastname"].ToString();
            return emp;
        }  

        // METHOD: FillEmployeeList
        public static void FillEmployeeList(EmployeeCollection coll, SqlDataReader reader)
        {
            while (reader.Read())
            {
                Employee emp = HelperMethods.GetEmployee(reader);
                coll.Add(emp);
            }
        }

    }
}