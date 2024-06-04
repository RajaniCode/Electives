//===============================================================================
// Filename:	Employee.cs
// Author:		Lancelot Web Solutions, LLC
// Date:		05/30/2004
// Purpose:		This file contains the Employee class which is used to perform 
//				business rules on Employee information.
//===============================================================================

#region Namespace References
/// <summary>
/// Declare all the NameSpaces to be referenced
/// </summary>
using System;
using System.Data;
using System.Data.SqlClient;
#endregion Namespace References

namespace ConcurrencyADONet1
{
	#region Employee Class
	/// <summary>
	/// The Employee class is used to perform business rules on Employee information.
	/// </summary>
	/// <remarks name="Employee" classtype="Public" inherits="">
	/// </remarks>
	public class Employee
	{

		#region Employee - Properties
		///<summary>
		/// Definitions of class level properties 
		///</summary>
		//private string m_sClassName = "[Employee]";	//--- The name of the class		#endregion Employee - Properties
		#region Employee - Constructors		/// <summary>
		/// This method will setup the Employee class for use. 
		/// The Common library class is created here.
		/// </summary>
		/// <remarks overloaded="no">
		/// </remarks>
		/// <param/>
		public Employee()
		{
		}
		#endregion Employee - Constructors	
		#region Employee - Public Methods
		/// <summary>
		/// This method will retrieve all Employees
		/// </summary>
		/// <remarks name="GetEmployee" classtype="public" overloaded="no">
		/// e.g.:
		///		DataSet oDs = GetEmployee();
		/// </remarks>
		/// <returns type="DataSet">The DataSet containing the Employees</returns>
		public dsEmployee GetEmployee()
		{
			//string sMethodName = "[public dsEmployee GetEmployee()]";

			//===============================================================================
			//--- Establish local variables
			//===============================================================================
			string sProcName;
			string sConnString = Common.BuildConnectionString();
			SqlDataAdapter oDa = new SqlDataAdapter();
			dsEmployee oDs = new dsEmployee();

			//===============================================================================
			//--- Set up the Connection
			//===============================================================================
			using (SqlConnection oCn = new SqlConnection(sConnString))
			{
				//===============================================================================
				//--- Set up the SELECT Command
				//===============================================================================
				sProcName = "prGet_Employees";
				using (SqlCommand oSelCmd = new SqlCommand(sProcName, oCn))
				{
					try
					{
						//===============================================================================
						//--- Get the Employee records
						//===============================================================================
						oSelCmd.CommandType = CommandType.StoredProcedure;
						oDa.SelectCommand = oSelCmd;
						oDa.Fill(oDs, "Employee");
					}
					catch (Exception ex)
					{
						//---------------------------------------------------------
						//--- Re-throw the Exception.
						//---------------------------------------------------------
						throw(ex);
					}
					finally
					{
						oDa.Dispose();
					}
				}
			}
			
			return oDs;
		}

		/// <summary>
		/// This method will retrieve all Employees
		/// </summary>
		/// <remarks name="GetEmployee" classtype="public" overloaded="no">
		/// e.g.:
		///		DataSet oDs = GetEmployee();
		/// </remarks>
		/// <returns type="DataSet">The DataSet containing the Employees</returns>
		public dsEmployee GetEmployee(int iEmployeeID)
		{
			//string sMethodName = "[public dsEmployee GetEmployee(int iEmployeeID)]";

			//===============================================================================
			//--- Establish local variables
			//===============================================================================
			string sProcName;
			string sConnString = Common.BuildConnectionString();
			SqlDataAdapter oDa = new SqlDataAdapter();
			dsEmployee oDs = new dsEmployee();

			//===============================================================================
			//--- Set up the Connection
			//===============================================================================
			using (SqlConnection oCn = new SqlConnection(sConnString))
			{
				//===============================================================================
				//--- Set up the SELECT Command
				//===============================================================================
				sProcName = "prGet_Employee";
				using (SqlCommand oSelCmd = new SqlCommand(sProcName, oCn))
				{
					try
					{
						//===============================================================================
						//--- Get the Employee records
						//===============================================================================
						oSelCmd.CommandType = CommandType.StoredProcedure;
						oSelCmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
						oSelCmd.Parameters["@EmployeeID"].Direction = ParameterDirection.Input;
						oSelCmd.Parameters["@EmployeeID"].Value = iEmployeeID;
						oDa.SelectCommand = oSelCmd;
						oDa.Fill(oDs, "Employee");
					}
					catch (Exception ex)
					{
						//---------------------------------------------------------
						//--- Re-throw the Exception.
						//---------------------------------------------------------
						throw(ex);
					}
					finally
					{
						oDa.Dispose();
					}
				}
			}
			
			return oDs;
		}

		/// <summary>
		/// This method will pass a DataSet in which contains 1 Employee and 
		/// will update it in the database.
		/// </summary>
		/// <remarks name="SaveEmployee" classtype="public" overloaded="no">
		/// e.g.:
		///		DataSet oDs = SaveEmployee(oDs);
		/// </remarks>
		/// <param name="oDs">The DataSet that contains the new Employee(s)</param>
		/// <param name="bLastInWins">Determines which stored proc to call</param>
		/// <returns type="DataSet">Returns a DataSet containing the changed records with any additional modifications</returns>
		public dsEmployee SaveEmployee(dsEmployee oDs, bool bLastInWins)
		{
			//string sMethodName = "[public void SaveEmployee(dsEmployee oDs, bool bLastInWins)]";

			//===============================================================================
			//--- Establish local variables
			//===============================================================================
			string sProcName;
			string sConnString = Common.BuildConnectionString();
			SqlDataAdapter oDa = new SqlDataAdapter();
			SqlConnection oCn = null;
			SqlCommand oUpdCmd = null;

			try
			{
				//===============================================================================
				//--- Set up the Connection
				//===============================================================================
				oCn = new SqlConnection(sConnString);

				//===============================================================================
				//--- Open the Connection
				//===============================================================================
				oCn.Open();

				//===============================================================================
				//--- Set up the UPDATE Command
				//===============================================================================
				if (bLastInWins)
				{
					sProcName = "prUpdate_EmployeeViaLastInWins";
				}
				else
				{
					sProcName = "prUpdate_Employee";
				}
				oUpdCmd = new SqlCommand(sProcName, oCn);
				oUpdCmd.CommandType = CommandType.StoredProcedure;
				oUpdCmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4, "EmployeeID"));
				oUpdCmd.Parameters.Add(new SqlParameter("@LastUpdateDateTime", SqlDbType.DateTime, 8, "LastUpdateDateTime"));
				oUpdCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10,"FirstName"));
				oUpdCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20, "LastName"));
				oUpdCmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 30, "Title"));
				oUpdCmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.DateTime, 8, "BirthDate"));
				oUpdCmd.Parameters.Add(new SqlParameter("@HireDate", SqlDbType.DateTime, 8, "HireDate"));
				oUpdCmd.Parameters.Add(new SqlParameter("@Extension", SqlDbType.NVarChar, 4, "Extension"));
				oUpdCmd.Parameters.Add(new SqlParameter("@NewLastUpdateDateTime", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "LastUpdateDateTime", DataRowVersion.Current, null));
				oUpdCmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
				oDa.UpdateCommand = oUpdCmd;

				//===============================================================================
				//--- Update the Employee record(s)
				//===============================================================================
				Common.ShowRowStates(oDs.Employee, "*** BEFORE Employee UPDATES ***");
				oDa.Update(oDs.Employee.Select("", "", DataViewRowState.ModifiedCurrent));
				
				Common.ShowRowStates(oDs.Employee, "*** AFTER ALL ***");

				oCn.Close();
			}
			catch (DBConcurrencyException exDBC)
			{
				//---------------------------------------------------------
				//--- Re-throw the Exception.
				//--- The DBConcurrencyException class exposes a System.Data.DataRow
				//--- object which represents the row that caused the 
				//--- concurrency violation. This can be examined and/or 
				//--- reported on.
				//--- i.e. exDBC.Row
				//---------------------------------------------------------
				throw(exDBC);
			}
			catch (Exception ex)
			{
				//---------------------------------------------------------
				//--- Re-throw the Exception.
				//---------------------------------------------------------
				throw(ex);
			}
			finally
			{
				oUpdCmd.Dispose();
				oDa.Dispose();
				oCn.Dispose();
			}
			oCn.Close();
			return oDs;
		}
		
		#endregion Employee - Public Methods

		#region Employee - Events & Handlers
		#endregion Employee - Events & Handlers
	}
	#endregion Employee Class
}
