using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class DataAccessLayer
{
    private string ConnectionString
    {
        get
        {
            ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
            return ConnectionStringSetting["ConnectionString"].ConnectionString;
        }
    }

    public DataTable Select(SqlCommand commandSql)
    {
        DataTable datTable = new DataTable();
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.SelectCommand = commandSql;
                dataAdapterSql.SelectCommand.Connection = connectionSql;
                dataAdapterSql.Fill(datTable);
            }
        }
        return datTable;
    }

    public int Insert(SqlCommand commandSql)
    {
        int rowsAffacted = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.InsertCommand = commandSql;
                dataAdapterSql.InsertCommand.Connection = connectionSql;
                dataAdapterSql.InsertCommand.Connection.Open();
                rowsAffacted = dataAdapterSql.InsertCommand.ExecuteNonQuery();
            }            
        }
        return rowsAffacted;
    }

    public int Update(SqlCommand commandSql)
    {
        int rowsAffacted = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {       
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.UpdateCommand = commandSql;
                dataAdapterSql.UpdateCommand.Connection = connectionSql;
                dataAdapterSql.UpdateCommand.Connection.Open();
                rowsAffacted = dataAdapterSql.UpdateCommand.ExecuteNonQuery();
            }            
        }
        return rowsAffacted;
    }

    public int Delete(SqlCommand commandSql)
    {
        int rowsAffacted = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.DeleteCommand = commandSql;
                dataAdapterSql.DeleteCommand.Connection = connectionSql;
                dataAdapterSql.DeleteCommand.Connection.Open();
                rowsAffacted = dataAdapterSql.DeleteCommand.ExecuteNonQuery();
            }
        }
        return rowsAffacted;
    }
}
