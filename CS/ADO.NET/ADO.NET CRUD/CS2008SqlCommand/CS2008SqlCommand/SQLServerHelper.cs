using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

class SQLServerHelper
{
    private string ConnectionString
    {
        get
        {
            ConnectionStringSettingsCollection connectionStringSettings = ConfigurationManager.ConnectionStrings;
            return connectionStringSettings["ConnectionString"].ConnectionString;
        }
    }

    public DataTable Select(SqlCommand commandSql)
    {
        DataTable datTable = null;
        try
        {
            using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
            {
                commandSql.Connection = connectionSql;
                commandSql.Connection.Open();
                datTable = new DataTable();
                datTable.Load(commandSql.ExecuteReader());
                return datTable;
            }               
        }
        finally
        {
            datTable = null;
        }
    }

    public int Execute(SqlCommand commandSql)
    {
        int rowsAffected = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            commandSql.Connection = connectionSql;
            commandSql.Connection.Open();
            rowsAffected = commandSql.ExecuteNonQuery();           
        }
        return rowsAffected;
    }
}
