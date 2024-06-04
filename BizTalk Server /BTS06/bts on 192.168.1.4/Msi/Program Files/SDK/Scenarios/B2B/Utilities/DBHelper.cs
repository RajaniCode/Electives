//---------------------------------------------------------------------
// File:      DBHelper.cs
// 
// Summary:   
//
// Sample:    Litware scenario
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
//---------------------------------------------------------------------
using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace Microsoft.Samples.BizTalk.Litware.Utilities
{
	/// <summary>
	/// Summary description for DBHelper.
	/// </summary>
	public sealed class DBHelper
	{
		private static string _connDBString = SSOConfigHelper.Read("DBConn");

		private DBHelper()
		{
		}

		public static bool PlaceOrder (string partnerId, string orderId, XmlDocument orderXml)
		{
			if (null == orderXml) throw new ArgumentNullException("orderXml", "Order can not be null");	

			bool result = false;
			System.DateTime modifiedDate = System.DateTime.Parse(
				orderXml.DocumentElement.Attributes["LastModified"].InnerText,
				System.Globalization.CultureInfo.CurrentCulture);

			using (SqlConnection connDB = new SqlConnection(_connDBString))
			{
				connDB.Open();
				using (SqlCommand cmdDB = new SqlCommand())
				{
					try
					{
						cmdDB.Connection = connDB;
						cmdDB.CommandType = CommandType.StoredProcedure;
						cmdDB.CommandText = "PlaceOrder";
						cmdDB.Parameters.AddWithValue("@PartnerID", partnerId);
						cmdDB.Parameters.AddWithValue("@OrderID", orderId);
						cmdDB.Parameters.AddWithValue("@UpdatedTime", modifiedDate);
						cmdDB.Parameters.AddWithValue("@OrderXML", orderXml.OuterXml);
						cmdDB.ExecuteNonQuery();
						result = true;
					}
					catch (SqlException sqlEx)
					{
						const int DuplicateKeyForOrderError = 2627;		// SQL Server error code 2627, Violation of Primary Key for the order
						if (DuplicateKeyForOrderError == sqlEx.Number)
						{
							string msg = String.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"Duplicate order received. Partner id = <{0}> Order Id = <{1}>.  Order not accepted",
												partnerId, orderId);

							throw new ApplicationException(msg);
						}
						else
						{
							throw;
						}
					}
				}
			}
			return result;
		}

		public static bool IsOrderExist (string partnerId, string orderId)
		{
			bool result = false;

			using (SqlConnection connDB = new SqlConnection(_connDBString))
			{
				connDB.Open();
				
				using (SqlCommand cmdDB = new SqlCommand())
				{
					cmdDB.Connection = connDB;
					cmdDB.CommandType = CommandType.StoredProcedure;
					cmdDB.CommandText = "IsOrderExist";
					cmdDB.Parameters.AddWithValue("@PartnerID", partnerId);
					cmdDB.Parameters.AddWithValue("@OrderID", orderId);

					SqlParameter tempParm = new SqlParameter();
					tempParm.ParameterName = "@RetVal";
					tempParm.Direction = ParameterDirection.ReturnValue;
					cmdDB.Parameters.Add (tempParm);
					cmdDB.ExecuteNonQuery ();

					// SP return 1 if exists
					result = (cmdDB.Parameters["@RetVal"].Value.ToString() == "1");
				}
			}
			return result;
		}
		public static bool UpdateOrder (string partnerId, string orderId, XmlDocument orderXml)
		{
			if (null == orderXml) throw new ArgumentNullException("orderXml", "order can not be null");
			
			bool result = false;
			
			System.DateTime modifiedDate = System.DateTime.Parse( 
					orderXml.DocumentElement.Attributes["LastModified"].InnerText,
					System.Globalization.CultureInfo.CurrentCulture );
			
			if (CompareOrderTimeStamp (partnerId, orderId, modifiedDate))
			{
				using (SqlConnection connDB = new SqlConnection(_connDBString))
				{					
					connDB.Open();
					using (SqlCommand cmdDB = new SqlCommand())
					{
						cmdDB.Connection = connDB;
						cmdDB.CommandType = CommandType.StoredProcedure;
						cmdDB.CommandText = "UpdateOrder";
						cmdDB.Parameters.AddWithValue("@PartnerID", partnerId);
						cmdDB.Parameters.AddWithValue("@OrderID", orderId);
						cmdDB.Parameters.AddWithValue("@UpdatedTime", modifiedDate);
						cmdDB.Parameters.AddWithValue("@OrderXML", orderXml.OuterXml);
						cmdDB.ExecuteNonQuery ();

						result = true;
					}
				}
			}
			else
			{
				throw new ApplicationException("Only newer updates are accepted.");
			}

			return result;
		}

		public static XmlDocument GetOrder (string partnerId, string orderId)
		{
			using (SqlConnection connDB = new SqlConnection(_connDBString))
			{
				connDB.Open();
				using (SqlCommand cmdDB = new SqlCommand())
				{
					cmdDB.Connection = connDB;
					cmdDB.CommandType = CommandType.StoredProcedure;
					cmdDB.CommandText = "GetOrder";
					cmdDB.Parameters.AddWithValue("@PartnerID", partnerId);
					cmdDB.Parameters.AddWithValue("@OrderID", orderId);

					DataSet ds = new DataSet();
					SqlDataAdapter dataAd = new SqlDataAdapter(cmdDB);
					dataAd.Fill(ds);

					// if no row, exception is thrown
					DataRow dr = ds.Tables[0].Rows[0];
					XmlDocument xdoc = new XmlDocument();
					xdoc.LoadXml(dr[0].ToString());
					return xdoc;
				}
			}
		}

		public static string GetVendorId(string brokerId, string productId)
		{
			using (SqlConnection connDB = new SqlConnection(_connDBString))
			{
				connDB.Open();

				using (SqlCommand cmdDB = new SqlCommand())
				{
					cmdDB.Connection = connDB;
					cmdDB.CommandType = CommandType.StoredProcedure;
					cmdDB.CommandText = "GetVendorID";
					cmdDB.Parameters.AddWithValue("@BrokerID", brokerId);
					cmdDB.Parameters.AddWithValue("@ProductID", productId);
					object objvendor = cmdDB.ExecuteScalar();
					return objvendor.ToString();
				}
			}
		}

		private static bool CompareOrderTimeStamp (string partnerId, string orderId, System.DateTime modifiedDate)
		{
			bool result = false;

			using (SqlConnection connDB = new SqlConnection(_connDBString))
			{
				connDB.Open();
				SqlCommand cmdDB = new SqlCommand();
				cmdDB.Connection = connDB;
				cmdDB.CommandType = CommandType.StoredProcedure;
				cmdDB.CommandText = "GetOrderStamp";
				cmdDB.Parameters.AddWithValue("@PartnerID", partnerId);
				cmdDB.Parameters.AddWithValue("@OrderID", orderId);

				DataSet ds = new DataSet();
				SqlDataAdapter dataAd = new SqlDataAdapter (cmdDB);
				dataAd.Fill(ds);

				// if no row, exception is thrown
				DataRow dr = ds.Tables[0].Rows[0];
				System.DateTime lastupdateDB = Convert.ToDateTime( dr[0], System.Globalization.CultureInfo.CurrentCulture );
				
				if( lastupdateDB < modifiedDate)
					result = true;
			}
			return result;
		}

	}
}