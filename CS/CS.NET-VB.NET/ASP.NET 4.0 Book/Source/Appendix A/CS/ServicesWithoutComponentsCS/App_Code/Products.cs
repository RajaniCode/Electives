using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{
	public Products()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int AddProducts(string name, string description)
		{
			int productID;
            string connString = @"Data Source=PUNEET-PC;Initial Catalog=componentapp;Integrated Security=True";
			string commandName = "AddProducts";
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand command = new SqlCommand(commandName, conn);
				command.CommandType = CommandType.StoredProcedure;
				SqlParameter paramName = new SqlParameter("@Name",SqlDbType.VarChar, 50);
				paramName.Direction = ParameterDirection.Input;
				paramName.Value = name;
				command.Parameters.Add(paramName);
				SqlParameter paramDesc = new SqlParameter("@Description",SqlDbType.VarChar, 250);
				paramDesc.Direction = ParameterDirection.Input;
				paramDesc.Value = description;
				command.Parameters.Add(paramDesc);
				SqlParameter paramReturnValue = new SqlParameter("@@identity",SqlDbType.VarChar, 250);
				paramReturnValue.Direction = ParameterDirection.ReturnValue;
				command.Parameters.Add(paramReturnValue);
				command.ExecuteNonQuery();
				productID = (int)command.Parameters["@@identity"].Value;
				Console.WriteLine(productID);
				Console.ReadLine();
			}
			return productID;
		}
	

}