using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Threading;


namespace IntroAjax
{
    public class EmployeeCommands
    {
        public static string cmdLoadAll = "SELECT * FROM employees";
        public static string cmdUpdate = "UPDATE employees SET ";
    }

    // CLASS Employee: holds information about the employee
    public class Employee
    {
        private string _id, _firstname, _lastname;

        public Employee()
        {
        }

        #region PROPERTIES

        // ID
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        // FirstName
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        // LastName
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        #endregion  
    }

    // CLASS EmployeeCollection: collection of Employee objects
    public class EmployeeCollection : Collection<Employee>
    {
    }

    // CLASS EmployeeManager: data-mapper class for the customer entity
    public class EmployeeManager
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString; }
        }

        #region METHOD: LoadAll
        public static EmployeeCollection LoadAll()
        {
            EmployeeCollection coll = new EmployeeCollection();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(EmployeeCommands.cmdLoadAll, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                HelperMethods.FillEmployeeList(coll, reader);
                reader.Close();
                conn.Close();
            }

            return coll;
        }
       #endregion

    }
}
