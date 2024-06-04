using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

using System.Configuration;

/// <summary> 
/// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
/// This class provides services for handling page view state. 
///  
/// Created on 26/6/2007. 
/// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
/// </summary> 
public static class PageViewStateServices
{
    private static  string ConnectionString
    {
        get
        {
            try
            {
                ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
                return ConnectionStringSetting["ConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                var Error = ex.Message;
                return string.Empty;
            }
        }
    }

    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    /// <summary> 
    /// Get a page view state by ID. 
    /// </summary> 
    /// <remarks> 
    ///         <author></author> 
    ///         <creation>Wednesday, 30 May 2007</creation> 
    /// </remarks> 
    /// <param name="id">ID.</param> 
    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    public static string GetByID(Guid id)
    {

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetByID";
                    command.Parameters.Add(new SqlParameter("@id", id));
                    return (string)command.ExecuteScalar();
                }
            }

            finally
            {
                connection.Close();
            }
        }

    }

    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    /// <summary> 
    /// Save the view state. 
    /// </summary> 
    /// <remarks> 
    ///         <author></author> 
    ///         <creation>Wednesday, 30 May 2007</creation> 
    /// </remarks> 
    /// <param name="id">Unique ID.</param> 
    /// <param name="value">View state value.</param> 
    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    public static void Save(Guid id, string value)
    {

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            try
            {

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SaveViewState";
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.Parameters.Add(new SqlParameter("@value", value));
                    command.ExecuteNonQuery();
                }

            }

            finally
            {
                connection.Close();
            }
        }

    }

}
