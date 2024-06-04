using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
namespace AddressBookDatabase
{
	/// <summary>
	/// This is the Data layer component which will
	/// interact heavily with database
	/// </summary>
	public class addressBookDB
	{
		// strConnection property will have connection string
		private string strConnectionString;
		// This property will decide which type of
		// database to access. Currently there will be two kind of
		// database support access and sql server.
		// Access intDatabaseType = 1
		// SQL Server intDatabaseType = 2
		// Oracle intDatabaseType = 3
		// Please note i will not be coding anything for SQL Server and Oracle. I am leaving that 
		// to the readers for practice.
		private int intDatabaseType;
		// External client using this application can override which
		// kind of database to use
		public int databaseType
		{
			set
			{
				intDatabaseType = value;
			}
			get
			{
				return intDatabaseType;
			}
		}

		// External client can set connection string 
		public string connectionString
		{
			set
			{
				strConnectionString = value; 
			}
			// No need of get property but just added who knows
			get
			{
				return strConnectionString;
			}
			
		}
		public addressBookDB()
		{
			// Use the app.config file and set connectionstring and databasetype
			
			System.Configuration.AppSettingsReader objAppsettingreader = new System.Configuration.AppSettingsReader();
			strConnectionString = (string) objAppsettingreader.GetValue("ConnectionString",typeof(string));
			intDatabaseType = (int) objAppsettingreader.GetValue("DatabaseType",typeof(int));;
		}
		// This function returns all address in the 
		// database
		public IDataReader GetAddresses()
		{
			try
			{
				IDbConnection objConnection = null;
				IDbCommand objCommand = null;
				IDataReader objDataReader = null;
				// First get the connection
				objConnection = GetConnectionObject();
				// open the connection
				objConnection.Open();
				// get the command object using this connection object
				objCommand = GetCommand(objConnection);
				// current this DAL component will only support simple SQL 
				// and not Stored procedures
				objCommand.CommandType = CommandType.Text;
				// the sql text
				objCommand.CommandText = "Select * from Address";
				// finally get the reader
				objDataReader =  objCommand.ExecuteReader();
				
				return objDataReader;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			

		}
		/// <summary>
		/// This method loads address by addressid
		/// </summary>
		/// <param name="intAddressid"> This is the id which represents the addressid</param>
		/// <returns></returns>
		public IDataReader GetAddresses(int intAddressid)
		{
			try
			{
				IDbConnection objConnection = null;
				IDbCommand objCommand = null;
				IDataReader objDataReader = null;
				// First get the connection
				objConnection = GetConnectionObject();
				// open the connection
				objConnection.Open();
				// get the command object using this connection object
				objCommand = GetCommand(objConnection);
				// current this DAL component will only support simple SQL 
				// and not Stored procedures
				objCommand.CommandType = CommandType.Text;
				// the sql text
				objCommand.CommandText = "Select * from Address where addressid=" + intAddressid.ToString();
				// finally get the reader
				objDataReader =  objCommand.ExecuteReader();
				return objDataReader;
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
			

		}

		/// <summary>
		/// This method adds /updates new address to database
		/// It adds to address database if Addressid == 0
		/// and updates if Addressid <> 0
		/// </summary>
		public void addAddress(int intAddressid,
								string strName, 
								string strAddressName , 
								string strPhoneNumber)
		{
			try
			{
				IDbConnection objConnection = null;
				IDbCommand objCommand = null;
				// First get the connection
				objConnection = GetConnectionObject();
				// open the connection
				objConnection.Open();
				// get the command object using this connection object
				objCommand = GetCommand(objConnection);
				// current this DAL component will only support simple SQL 
				// and not Stored procedures
				objCommand.CommandType = CommandType.Text;
				// this method will do both adding and updating
				// if the addressid is zero that mean we have to add
				// if the addressid is not zero that means we have to update
				if (intAddressid==0)
				{
					objCommand.CommandText = "insert into Address(Name,Address,Phonenumber) values('" + strName + "','" + strAddressName + "','" + strPhoneNumber + "')" ;
				}
				else
				{
					objCommand.CommandText = "update Address set name='" + strName + "', Address='" + strAddressName + "',phonenumber='" + strPhoneNumber + "' where addressid=" + intAddressid.ToString();
				}
				objCommand.ExecuteNonQuery();
				objCommand.Connection.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		// This function will return connection object depending
		// on what is the current database type.
		public IDbConnection GetConnectionObject()
		{
			IDbConnection objConnection = null;
			
			if (intDatabaseType==0)
			{
				throw new Exception("Illegal Databasetype provided");
			}
			// if its access then use OleDbConnection object;
			if (intDatabaseType == 1)
			{
				objConnection = new OleDbConnection();
			}
			
			// set the connection string 
			objConnection.ConnectionString = strConnectionString;
			return objConnection;
		}

		// This function will return the command object depending
		// on the connection object passed to it
		public IDbCommand GetCommand(IDbConnection objDbConnection)
		{
			IDbCommand objCommand = objDbConnection.CreateCommand();
			return objCommand;
		}
	
	
	}
}
