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

                //IsolationLevel.ReadCommitted
                //Shared locks are held while the data is being read to avoid dirty reads, 
                //but the data can be changed before the end of the transaction, resulting in non-repeatable reads or phantom data.                 
                using (SqlTransaction transactionSql = connectionSql.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        command.Transaction = transactionSql;
                        rowsAffacted = command.ExecuteNonQuery();
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
        }
        return rowsAffacted;
    }
}
