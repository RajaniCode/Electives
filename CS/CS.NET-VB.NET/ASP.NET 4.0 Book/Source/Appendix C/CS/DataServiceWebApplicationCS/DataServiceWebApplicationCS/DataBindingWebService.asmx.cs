using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceWebApplicationCS
{
    /// <summary>
    /// Summary description for DataBindingWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataBindingWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet GetData()
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            sqlConnection1.ConnectionString = "Data Source=ANAMIKA-PC\\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True";
            string selectStr = "SELECT EmployeeID, FirstName, LastName,  City, Country FROM Employees";
            SqlDataAdapter da = new SqlDataAdapter(selectStr, sqlConnection1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return (ds);
        }
    }
}
