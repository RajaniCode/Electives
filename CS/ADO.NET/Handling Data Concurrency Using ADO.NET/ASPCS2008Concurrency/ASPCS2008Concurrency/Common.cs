//===============================================================================
// Filename:	Common.cs
// Author:		
// Date:		
// Purpose:		This file contains the Common class which stores commonly 
//				used functions
//===============================================================================

#region namespaces
/// <summary>
/// Declare all the NameSpaces to be referenced
///</summary>
using System;
using System.Data;
using System.Configuration;
#endregion namespaces

namespace ConcurrencyADONet1
{
	#region Common Class
	/// <summary>
	/// The Common class is used to store all commonly used functions throughout a project
	/// </summary>
	/// <remarks name="Common" classtype="Public" inherits="">
	/// </remarks>
	public class Common
	{
		#region Common - Properties
		///<summary>
		/// Definitions of class level properties 
		///</summary>
		//private string m_sClassName = "[Common]";
		#endregion Common - Properties
	
		#region Common - Constructors		/// <summary>
		/// This method will ...
		/// </summary>
		/// <remarks overloaded="no">
		/// </remarks>
		/// <param/>
		public Common()
		{
		}
		#endregion Common - Constructors
		#region Common - Public Methods
		/// <summary>
		/// This method will build a connection string.
		/// </summary>
		/// <remarks name="BuildConnectionString" classtype="public" overloaded="no">
		/// </remarks>
		/// <returns type="string">A properly formatted connection string</returns>
		public static string BuildConnectionString()
		{
			return ConfigurationSettings.AppSettings["connStr"];
		}
		/// <summary>
		/// This method will show the rows states for a DataTable.
		/// </summary>
		/// <remarks name="ShowRowStates" classtype="public" overloaded="no">
		/// </remarks>
		/// <param name="oDt">The DataTable to display the rows and their states</param>
		/// <param name="sTitle">The title to display to the debug window</param>
		public static void ShowRowStates(DataTable oDt, string sTitle)
		{
			try
			{
				System.Diagnostics.Debug.WriteLine("***");
				System.Diagnostics.Debug.WriteLine(sTitle);
				ShowDataRowsByRowVersion(oDt, DataViewRowState.Added, "*** ADDED ROWS ***");
				ShowDataRowsByRowVersion(oDt, DataViewRowState.Deleted, "*** DELETED ROWS ***");
				ShowDataRowsByRowVersion(oDt, DataViewRowState.ModifiedCurrent, "*** MODIFIED CURRENT ROWS ***");
				System.Diagnostics.Debug.WriteLine("***");
			}
			catch
			{
				//Ignore the errors;
			}
			System.Diagnostics.Debug.WriteLine("***");
		}

		/// <summary>
		/// This method will display the content of a DataSet.
		/// </summary>
		/// <remarks name="DisplayDataSet" classtype="public" overloaded="no">
		/// </remarks>
		/// <param name="oDs">The DataSet to display the data values for.</param>
		/// <param name="sTitle">The title to display to the debug window</param>
		public static void DisplayDataSet(DataSet oDs, string sTitle)
		{
			System.Diagnostics.Debug.WriteLine(sTitle);
			//--- Loop through the DataTables
			foreach (DataTable T in oDs.Tables)
			{
				System.Diagnostics.Debug.WriteLine("*** DataTable: " + T.TableName + "***");
				//--- Loop through each DataTable's DataRows
				foreach (DataRow R in T.Rows)
				{
					//--- Display the original values, if there are any.
					if (R.HasVersion(System.Data.DataRowVersion.Original))
					{
						System.Diagnostics.Debug.Write("Original Row Values ===> ");
						foreach(DataColumn C in T.Columns)
						{
							System.Diagnostics.Debug.Write(C.ColumnName + " = " + R[C, System.Data.DataRowVersion.Original] + ", ");
						}
						System.Diagnostics.Debug.WriteLine("");
					}
					//--- Display the current values, if there are any.
					if (R.HasVersion(System.Data.DataRowVersion.Current))
					{
						System.Diagnostics.Debug.Write("Current Row Values ====> ");
						foreach(DataColumn C in T.Columns)
						{
							System.Diagnostics.Debug.Write(C.ColumnName + " = " + R[C, System.Data.DataRowVersion.Current] + ", ");
						}
						System.Diagnostics.Debug.WriteLine("");
					}
					System.Diagnostics.Debug.WriteLine("");
				}
			}
		}
		#endregion Common - Public Methods

		#region Common - Private Methods
		/// <summary>
		/// This method will display the content of a DataSet.
		/// </summary>
		/// <remarks name="ShowDataRowsByRowVersion" classtype="private" overloaded="no">
		/// </remarks>
		/// <param name="oDt">The DataTable to display.</param>
		/// <param name="oDvrs">The row state of the rows to display.</param>
		/// <param name="sTitle">The title of the DataRows to show.</param>
		private static void ShowDataRowsByRowVersion(DataTable oDt, DataViewRowState oDvrs, string sTitle)		{			System.Diagnostics.Debug.WriteLine(sTitle);
			DataRow[] Rows = oDt.Select("", "", oDvrs);			foreach (DataRow R in Rows)
			{
				System.Diagnostics.Debug.Indent();
				//--- Display the original values, if there are any.
				if (R.HasVersion(System.Data.DataRowVersion.Original))
				{
					System.Diagnostics.Debug.Write("Original Row Values ===> ");
					foreach(DataColumn C in oDt.Columns)
					{
						System.Diagnostics.Debug.Write(C.ColumnName + " = " + R[C, System.Data.DataRowVersion.Original] + ", ");
					}
					System.Diagnostics.Debug.WriteLine("");
				}
				//--- Display the current values, if there are any.
				if (R.HasVersion(System.Data.DataRowVersion.Current))
				{
					System.Diagnostics.Debug.Write("Current Row Values ====> ");
					foreach(DataColumn C in oDt.Columns)
					{
						System.Diagnostics.Debug.Write(C.ColumnName + " = " + R[C, System.Data.DataRowVersion.Current] + ", ");
					}
					System.Diagnostics.Debug.WriteLine("");
				}
				System.Diagnostics.Debug.Unindent();
			}
		}		#endregion Common - Private Methods
	}
	#endregion Common Class
}