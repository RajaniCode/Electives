using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class SQLServerHelper
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
        DataTable datTable = null;
        try
        {
            using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
                {
                    dataAdapterSql.SelectCommand = commandSql;
                    dataAdapterSql.SelectCommand.Connection = connectionSql;
                    datTable = new DataTable();
                    dataAdapterSql.Fill(datTable);
                    return datTable;
                }
            }
        }
        finally
        {
            datTable = null;
        }
    }

    public int Insert(SqlCommand commandSql)
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
                    SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                    dataAdapterSql.InsertCommand = commandSql;
                    dataAdapterSql.InsertCommand.Connection = connectionSql;
                    dataAdapterSql.InsertCommand.Transaction = transactionSql;
                    rowsAffected = dataAdapterSql.InsertCommand.ExecuteNonQuery();
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
                            string err = sqlex.Message;
                        }
                    }
                    string error = ex.Message;
                    throw;
                }
            }
        } 
        return rowsAffected;
    }

    public int Update(SqlCommand commandSql)
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
                    SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                    dataAdapterSql.UpdateCommand = commandSql;
                    dataAdapterSql.UpdateCommand.Connection = connectionSql;
                    dataAdapterSql.UpdateCommand.Transaction = transactionSql;
                    rowsAffected = dataAdapterSql.UpdateCommand.ExecuteNonQuery();
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
                            string err = sqlex.Message;
                        }
                    }
                    string error = ex.Message;
                    throw;
                }
            }
        } 
        return rowsAffected;
    }

    public int Delete(SqlCommand commandSql)
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
                    SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                    dataAdapterSql.DeleteCommand = commandSql;
                    dataAdapterSql.DeleteCommand.Connection = connectionSql;

                    dataAdapterSql.DeleteCommand.Transaction = transactionSql;
                    rowsAffected = dataAdapterSql.DeleteCommand.ExecuteNonQuery();
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
