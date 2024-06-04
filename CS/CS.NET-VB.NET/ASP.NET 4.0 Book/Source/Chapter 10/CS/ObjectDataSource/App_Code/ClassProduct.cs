using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for ClassProduct
/// </summary>
public class ClassProduct
{
    public DataSet getinfo()
    {
       
        SqlConnection con = new SqlConnection("Data Source=PUNEET-PC\\SQLEXPRESS;Initial Catalog=northwnd;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter("Select * from Products", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
	
}