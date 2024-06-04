using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

using System.Collections.Generic;

/// <summary>
/// Summary description for EmailIDs
/// </summary>

public class clsEmailIDs
{
    int _id;
    string _emailid;
    string _userid;

    const string select = "SELECT * FROM dbo.tblEmailAccounts";
    const string insert = "INSERT INTO dbo.tblEmailAccounts(EmailId, UserId) VALUES(@EmailId, @UserId)";
    const string update = "UPDATE dbo.tblEmailAccounts SET EmailId = @EmailId, UserId = @UserId WHERE Id = @Id";
    const string delete = "DELETE FROM dbo.tblEmailAccounts WHERE Id = @Id";

    public int Identity
    {
        get
        {
            return _id;
        }
    }

    public string EmailIdentity
    {
        get
        {
            if (!String.IsNullOrEmpty(_emailid))
                return _emailid;
            else 
                return null;
        }
        set 
        { 
            _emailid = value; 
        }
    }

    public string UserIdentity
    {
        get
        {
            if (!String.IsNullOrEmpty(_userid))
                return _userid;
            else 
                return null;
        }
        set 
        { 
            _userid = value; 
        }
    }    

    public clsEmailIDs()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public clsEmailIDs(int id, string ei, string ui)
    {
        _id = id;
        _emailid = ei;
        _userid = ui;
    }

    public string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }

    public List<clsEmailIDs> SelectTable()
    {
        List<clsEmailIDs> EmailIDList = new List<clsEmailIDs>();

        SqlConnection connection = new SqlConnection(ConnectionString);

        SqlCommand command = new SqlCommand(select, connection);

        connection.Open();

        SqlDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            clsEmailIDs objEmailIds = new clsEmailIDs((int)dr["Id"], (string)dr["EmailId"], (string)dr["UserId"]);
            EmailIDList.Add(objEmailIds);
        }

        connection.Close();

        dr.Close();

        command.Dispose();

        if (EmailIDList != null && EmailIDList.Count > 0)
            return EmailIDList;
        else 
            return null;
    }  
    
    public void InsertTable(string ei, string ui)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);       

        SqlCommand command = new SqlCommand(insert, connection);

        command.Parameters.AddWithValue("@EmailId", ei);
        command.Parameters.AddWithValue("@UserId", ui);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void UpdateTable(int Identity, string EmailId, string UserId)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);

        SqlCommand command = new SqlCommand(update, connection);

        command.Parameters.AddWithValue("@Id", Identity);
        command.Parameters.AddWithValue("@EmailId", EmailId);
        command.Parameters.AddWithValue("@UserId", UserId);     

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void DeleteTable(int Identity)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);

        SqlCommand command = new SqlCommand(delete, connection);

        command.Parameters.AddWithValue("@Id", Identity);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }   
}
