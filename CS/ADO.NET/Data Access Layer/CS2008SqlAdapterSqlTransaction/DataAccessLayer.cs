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
                        SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                        dataAdapterSql.InsertCommand = command;
                        dataAdapterSql.InsertCommand.Connection = connectionSql;

                        dataAdapterSql.InsertCommand.Transaction = transactionSql;
                        rowsAffacted = dataAdapterSql.InsertCommand.ExecuteNonQuery();
                        transactionSql.Commit();
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            transactionSql.Rollback();
                        }
                        catch (SqlException ex)
                        {
                            if (transactionSql.Connection != null)
                            {
                                string error = ex.Message;
                            }
                        }
                        string err = e.Message;
                        throw;
                    }
                }
            }
        }
        return rowsAffacted;
    }

    public int Update(SqlCommand commandSql)
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
                        SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                        dataAdapterSql.UpdateCommand = command;
                        dataAdapterSql.UpdateCommand.Connection = connectionSql;

                        dataAdapterSql.UpdateCommand.Transaction = transactionSql;
                        rowsAffacted = dataAdapterSql.UpdateCommand.ExecuteNonQuery();
                        transactionSql.Commit();
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            transactionSql.Rollback();
                        }
                        catch (SqlException ex)
                        {
                            if (transactionSql.Connection != null)
                            {
                                string error = ex.Message;
                            }
                        }
                        string err = e.Message;
                        throw;
                    }
                }
            }
        }
        return rowsAffacted;
    }

    public int Delete(SqlCommand commandSql)
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
                        SqlDataAdapter dataAdapterSql = new SqlDataAdapter();
                        dataAdapterSql.DeleteCommand = command;
                        dataAdapterSql.DeleteCommand.Connection = connectionSql;

                        dataAdapterSql.DeleteCommand.Transaction = transactionSql;
                        rowsAffacted = dataAdapterSql.DeleteCommand.ExecuteNonQuery();
                        transactionSql.Commit();
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            transactionSql.Rollback();
                        }
                        catch (SqlException ex)
                        {
                            if (transactionSql.Connection != null)
                            {
                                string error = ex.Message;
                            }
                        }
                        string err = e.Message;
                        throw;
                    }
                }
            }
        }
        return rowsAffacted;
    }
}
