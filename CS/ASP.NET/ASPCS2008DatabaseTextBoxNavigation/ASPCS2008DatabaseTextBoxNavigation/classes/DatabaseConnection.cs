using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SQLite;

public class DatabaseConnection
{
    SQLiteConnection ConnectionSQLite;
    
	private bool OpenDatabaseConnection()
	{
		try
		{
			string ConnectionString = GetConnectionString();
            ConnectionSQLite = new SQLiteConnection(ConnectionString);
			
            if(ConnectionSQLite.State == ConnectionState.Closed)
				ConnectionSQLite.Open();

			return true;
		}
		catch(Exception ex)
		{
            string Error = ex.ToString();
			ConnectionSQLite = null;
			return false;
		}
	}
    private bool OpenDatabaseConnection(ref string exError)
	{
		try
		{
            string ConnectionString = GetConnectionString();

            ConnectionSQLite = new SQLiteConnection(ConnectionString);
			if(ConnectionSQLite.State == ConnectionState.Closed)
				
			ConnectionSQLite.Open();
			return true;
		}
		catch(Exception ex)
		{
            exError = ex.ToString();
			ConnectionSQLite = null;
			return false;
		}
	}
	
	private void CloseDatabaseConnection()
	{
		try
		{
			if(ConnectionSQLite.State == ConnectionState.Open)
			{
				ConnectionSQLite.Close();
			}
		}
		catch(Exception ex)
		{
            string Error = ex.ToString();
		}
	}

	private string GetConnectionString()
	{
        string ConnectionString = string.Empty;
        ConnectionStringSettingsCollection CollectionConnectionStringSettings = ConfigurationManager.ConnectionStrings;
        ConnectionString = CollectionConnectionStringSettings["MSC_ConnectionString"].ConnectionString;            
        return ConnectionString;
	}

	public DataSet GetDataSet(string SQLiteQuery)
	{			
		try
		{				
			if(OpenDatabaseConnection())
			{
				DataSet DatSet= new DataSet();
                SQLiteDataAdapter DataAdapterSQLite = new SQLiteDataAdapter(SQLiteQuery, ConnectionSQLite);
				DataAdapterSQLite.Fill(DatSet);
				CloseDatabaseConnection();
				return DatSet;
			}
		}
		catch(Exception ex)
		{
			string Error = ex.ToString();
			return null;
		}
		finally
		{
			if(ConnectionSQLite.State==ConnectionState.Open)
			{
				ConnectionSQLite.Close();
			}
		}
		return null;
		
	}

	public DataSet GetDataSet(string SQLiteQuery, ref string exError)
	{			
		try
		{
			if(OpenDatabaseConnection(ref exError))
			{
				DataSet DatSet= new DataSet();
                SQLiteDataAdapter DataAdapterSQLite = new SQLiteDataAdapter(SQLiteQuery, ConnectionSQLite);
				DataAdapterSQLite.Fill(DatSet);
				CloseDatabaseConnection();
				return DatSet;
			}
		}
		catch(Exception ex)
		{
			exError = ex.ToString();
			return null;
		}
		finally
		{
			if(ConnectionSQLite.State==ConnectionState.Open)
			{
				ConnectionSQLite.Close();
			}
		}
        return null;		
	}

    public int ExecuteNonQuery(string SQLiteQuery)
	{			
		try
		{				
			if(OpenDatabaseConnection())
			{
                SQLiteCommand CommandSQLite = new SQLiteCommand(SQLiteQuery, ConnectionSQLite);
				int Result = CommandSQLite.ExecuteNonQuery();
				CloseDatabaseConnection();
				return Result;
			}
		}
		catch
		{
			return -1;
		}
		finally
		{
			if(ConnectionSQLite.State==ConnectionState.Open)
			{
				ConnectionSQLite.Close();
			}
		}
		return -1;			
	}
}

