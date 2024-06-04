//---------------------------------------------------------------------
// File:	    UpdateMailingList.cs
// 
// Summary: 	Updates the mailing list database.
//
// Sample: 	    BizTalk Orchestration Compensation
//
//---------------------------------------------------------------------
// This file is part of the Microsoft BizTalk Server 2006 SDK
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Xml;

namespace Microsoft.Samples.BizTalk.Compensation
{
	/// <summary>
	/// UpdateMailingList is responsible for 
	/// updating the mailing list database
	/// using update data passed to the
	/// orchestration.
	/// </summary>
	[Serializable]
	public class UpdateMailingList
	{
        /// <summary>
        /// Update takes the updated customer record passed to
        /// the orchestration via the web service and attempts
        /// to update the mailing list database.
        /// </summary>
        /// <param name="updateDoc">
        /// An XML document containing updated data passed
        /// to the orchestration.
        /// </param>
        /// <returns>Returns either the original data or an error string.</returns>
        public string Update(XmlDocument updateDoc)
		{
            SqlConnection connection;           // Connects to the database to be updated.

		    SqlCommand command;                 // Contains the SQL query used to select records
                                                // to be updated.

		    SqlDataAdapter adapter;             // The adapter used to hold the results of the
                                                // SQL query.

		    DataSet dataSet;                    // DataSet to be filled by the adapter.
    		
            // Holds the value returned by the method --
            // either the original XML document passed
            // into this method, or an error string.
            string returnStatus = string.Empty;

            // Create an XmlDocument to store a copy of
            // the document passed into this method.
            // The document will be updated to contain
            // data currently in the mailing list
            // database.
            XmlDocument originalDoc = new XmlDocument();

            // Load the XML from the original document.
            originalDoc.LoadXml(updateDoc.InnerXml);

            // Connection string used to connect to the mailing list database.
            string connectString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BTSCompensationSampleMailingList;Data Source=(local)";

            connection = new SqlConnection(connectString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                // Set up database connection
                command = new SqlCommand("Select * from [Mailing List] where CustomerID = '" + originalDoc.SelectSingleNode("//CustomerID").InnerText + "'", connection);
                adapter = new SqlDataAdapter(command);
			
                // Get data currently in the database.
                dataSet = new DataSet("MailingList");
                dataSet.Locale = CultureInfo.InvariantCulture;
                adapter.Fill(dataSet, "Customers");

                // Use XPath queries to update the text in
                // the original XML document to those values
                // currently stored in the mailing list database.
                originalDoc.SelectSingleNode("//ContactName").InnerText =  dataSet.Tables["Customers"].Rows[0]["ContactName"].ToString();
                originalDoc.SelectSingleNode("//Address").InnerText =  dataSet.Tables["Customers"].Rows[0]["Address"].ToString();
                originalDoc.SelectSingleNode("//City").InnerText =  dataSet.Tables["Customers"].Rows[0]["City"].ToString();
                originalDoc.SelectSingleNode("//Region").InnerText =  dataSet.Tables["Customers"].Rows[0]["Region"].ToString();
                originalDoc.SelectSingleNode("//PostalCode").InnerText =  dataSet.Tables["Customers"].Rows[0]["PostalCode"].ToString();
                originalDoc.SelectSingleNode("//Country").InnerText =  dataSet.Tables["Customers"].Rows[0]["Country"].ToString();
                originalDoc.SelectSingleNode("//EmailAddress").InnerText =  dataSet.Tables["Customers"].Rows[0]["EmailAddress"].ToString();
							
                // Update data currently in the database using
                // data passed into this method.
                string
                updateQuery = "UPDATE [Mailing List] SET ";
                updateQuery = updateQuery + "[Mailing List].ContactName = '" + updateDoc.SelectSingleNode("//ContactName").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].Address = '" + updateDoc.SelectSingleNode("//Address").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].City = '" + updateDoc.SelectSingleNode("//City").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].Region = '" + updateDoc.SelectSingleNode("//Region").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].PostalCode = '" + updateDoc.SelectSingleNode("//PostalCode").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].Country = '" + updateDoc.SelectSingleNode("//Country").InnerText + "', ";
                updateQuery = updateQuery + "[Mailing List].EmailAddress = '" + updateDoc.SelectSingleNode("//EmailAddress").InnerText + "'";
                updateQuery = updateQuery + " WHERE ((([Mailing List].CustomerID)='" + updateDoc.SelectSingleNode("//CustomerID").InnerText + "'))";

                // Attempt to update the data in the database.
                command = new SqlCommand(updateQuery, connection);
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();

                returnStatus = originalDoc.InnerXml;
            }
            else 
            {
                // Return an error string if the database
                // connection failed.
                returnStatus = "Couldn't Connect";
            }

            return returnStatus;
        }                                                                                                                                                                                                                                                                                                                               
	}
}
