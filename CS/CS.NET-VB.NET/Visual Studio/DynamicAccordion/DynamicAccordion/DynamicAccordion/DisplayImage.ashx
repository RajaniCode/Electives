<%@ WebHandler Language="C#" Class="DisplayImage" %>
 
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
 
public class DisplayImage : IHttpHandler 
{
    byte[] empPic = null;
    long seq = 0;
    
    public void ProcessRequest(HttpContext context)
    {
       Int32 empno;
        
       if (context.Request.QueryString["id"] != null)
            empno = Convert.ToInt32(context.Request.QueryString["id"]);
       else
            throw new ArgumentException("No parameter specified");

       context.Response.OutputStream.Write(ShowEmpImage(empno), 78, Convert.ToInt32(seq) - 78);             
    }

    public byte[] ShowEmpImage(int empno)
    {
        string conn = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT photo FROM Employees WHERE EmployeeID = @ID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", empno);
        connection.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            seq = dr.GetBytes(0, 0, null, 0, int.MaxValue) - 1;
            empPic = new byte[seq + 1];
            dr.GetBytes(0, 0, empPic, 0, Convert.ToInt32(seq));
            connection.Close();
        }

        return empPic;
    }
 
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
 
 
}
