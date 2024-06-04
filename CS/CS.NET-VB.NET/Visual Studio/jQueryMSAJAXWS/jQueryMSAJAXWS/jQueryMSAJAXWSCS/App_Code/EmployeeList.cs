using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for EmployeeList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class EmployeeList : System.Web.Services.WebService {

    public EmployeeList () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public List<Employee> GetEmployees()
    {
        string nwConn = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        var empList = new List<Employee>();
        using (SqlConnection conn = new SqlConnection(nwConn))
        {
            const string sql = @"SELECT TOP 10 FirstName, LastName, Title, BirthDate FROM Employees";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader(
                    CommandBehavior.CloseConnection);
                if (dr != null)
                    while (dr.Read())
                    {
                        var emp = new Employee
                        {
                            FirstName = dr.GetString(0),
                            LastName = dr.GetString(1),
                            Title = dr.GetString(2),
                            BirthDate = dr.GetDateTime(3)
                        };
                        empList.Add(emp);
                    }
                return empList;
            }
        }
    }
    
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime BirthDate { get; set; }
}

//public class Employee
//{
//    public int ID { get; set; }
//    public string FName { get; set; }
//    public string MName { get; set; }
//    public string LName { get; set; }
//    public DateTime DOB { get; set; }
//    public char Sex { get; set; }
//}

