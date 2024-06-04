using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

class DataAccessLayer
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
        DataTable datTable = new DataTable();
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = commandSql)
            {
                command.Connection = connectionSql;
                command.Connection.Open();
                datTable.Load(command.ExecuteReader());
            }
        }
        return datTable;
    }

    public int Execute(SqlCommand commandSql)
    {
        int rowsAffacted = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = commandSql)
            {
                command.Connection = connectionSql;
                command.Connection.Open();
                rowsAffacted = command.ExecuteNonQuery();
            }
        }
        return rowsAffacted;
    }
}
