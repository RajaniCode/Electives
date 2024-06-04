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

            //IsolationLevel.ReadCommitted
            //Shared locks are held while the data is being read to avoid dirty reads, 
            //but the data can be changed before the end of the transaction, resulting in non-repeatable reads or phantom data.                 
            using (SqlTransaction transactionSql = connectionSql.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    commandSql.Transaction = transactionSql;
                    rowsAffected = commandSql.ExecuteNonQuery();
                    transactionSql.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transactionSql.Rollback();
                    }
                    catch (SqlException sqlex)
                    {
                        if (transactionSql.Connection != null)
                        {
                            string error = sqlex.Message;
                        }
                        throw;
                    }
                    string err = ex.Message;
                    throw;
                }
            }                
        }
        return rowsAffected;
    }
}
