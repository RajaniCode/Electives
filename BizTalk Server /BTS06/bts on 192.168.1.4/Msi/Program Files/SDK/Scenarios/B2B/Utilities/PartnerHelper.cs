//---------------------------------------------------------------------
// File:      PartnerHelper.cs
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
using System.Data;
using System.Data.SqlClient;
using System.Management;

namespace Microsoft.Samples.BizTalk.Litware.Utilities
{
	/// <summary>
	/// Summary description for PartnerHelper.
	/// </summary>
	public sealed class PartnerHelper
	{
		private static string MgmtDBConnString = String.Empty;
		private static object syncRoot = new object();

		private PartnerHelper()
		{
		}

		/// <summary>
		/// Return the name of the EDI partner, given the name of the EDI Receive location URI
		/// </summary>
		/// <param name="receiveLocation">
		/// string - Name of the Receive Location URI
		/// </param>
		/// <returns>
		/// name of the partner
		/// </returns>
		public static string GetPartnerId(string receiveLocation)
		{
			string partnerName = null;
			string partnerSID = null;

			PartnerHelper.GetPartyByAlias("EDI", "EDI", receiveLocation, out partnerName, out partnerSID);

			return partnerName;
		}

		public static string GetVendorId(string brokerId, string productId)
		{
			throw new NotImplementedException("GetVendorID method not implemented.");
		}

		/// <summary>
		/// Get party details from the management database, given an party alias name, party alias value and party 
		/// qualifier name
		/// </summary>
		/// <param name="aliasName">
		/// Name of the alis --> corresponds to the bts_party_alias.nvcName column...
		/// </param>
		/// <param name="aliasQualifier">
		/// Name of the qualifier --> corresponds to the bts_party_alias.nvcQualifier column
		/// </param>
		/// <param name="aliasValue">
		/// Value of the alias --> corresponds to the bts_party_alias.nvcValue column
		/// </param>
		/// <param name="partyName">
		/// output - the name of the party, from the bts_party.nvcName column
		/// </param>
		/// <param name="partySID">
		/// output - the sid of the party, from the bts_party.nvcSID column
		/// </param>
		public static void GetPartyByAlias(string aliasName, string aliasQualifier, string aliasValue, out string partyName, out string partySID)
		{
			if (aliasName.Length > 256) throw new ArgumentException("Length exceeds 256 characters", "aliasName");
			if (aliasQualifier.Length > 64) throw new ArgumentException("Length exceeds 64 characters", "aliasQualifier");
			if (aliasValue.Length > 256) throw new ArgumentException("Length exceeds 256 characters", "aliasValue");

			using (SqlConnection connection = new SqlConnection(GetMgmtDBConnectionString()))
			{

				using (SqlCommand partyResolveCMD = new SqlCommand("admsvr_GetPartyByAliasNameValue", connection))
				{
					partyResolveCMD.CommandType = CommandType.StoredProcedure;

					SqlParameter param = partyResolveCMD.Parameters.Add("@nvcAliasName", SqlDbType.NVarChar, 256);
					param.Value = aliasName;

					param = partyResolveCMD.Parameters.Add("@nvcAliasQualifier", SqlDbType.NVarChar, 64);
					param.Value = aliasQualifier;

					param = partyResolveCMD.Parameters.Add("@nvcAliasValue", SqlDbType.NVarChar, 256);
					param.Value = aliasValue;

					param = partyResolveCMD.Parameters.Add("@nvcSID", SqlDbType.NVarChar, 256);
					param.Direction = ParameterDirection.Output;
					param.Value = string.Empty;

					param = partyResolveCMD.Parameters.Add("@nvcName", SqlDbType.NVarChar, 256);
					param.Direction = ParameterDirection.Output;
					param.Value = string.Empty;

					connection.Open();

					using (SqlDataReader reader = partyResolveCMD.ExecuteReader())
					{
						partyName = partyResolveCMD.Parameters["@nvcName"].Value.ToString();
						partySID = partyResolveCMD.Parameters["@nvcSID"].Value.ToString();

						// If either of the 2 values are absent, set them to values corresponding to 'Guest'
						if (partyName.Length == 0) partyName = "Guest";
						if (partySID.Length == 0) partySID = "s-1-5-7";
					}
				}
			}
		}

		private static string GetMgmtDBConnectionString()
		{
			string BTSMgmtDBName = String.Empty, BTSMgmtDBServerName = String.Empty;
			
			//check to see if the string has already been retrieved.  If not, get it and store it.
			if( MgmtDBConnString.Length == 0 ) 
			{
				lock( syncRoot )
				{
					if( MgmtDBConnString.Length == 0)
					{
						ManagementObjectSearcher searcher =
							new ManagementObjectSearcher(@"root\MicrosoftBizTalkServer", "SELECT * FROM MSBTS_GroupSetting");
						foreach (ManagementObject Group in searcher.Get())
						{
							if(Group != null)
							{
								Group.Get();
								BTSMgmtDBName = Group["MgmtDbName"].ToString();
								BTSMgmtDBServerName = Group["MgmtDbServerName"].ToString();

							}						
						}

						if( BTSMgmtDBName.Length == 0 || BTSMgmtDBServerName.Length == 0 )
							throw new ApplicationException("Unable to find Management Database Name or Management Database Server Name");

						// Assuming Integrated Security is being used for database connection.
						MgmtDBConnString = string.Format("SERVER={0};DATABASE={1};Integrated Security=SSPI", BTSMgmtDBServerName, BTSMgmtDBName);
					}
				}
			}
		
			return MgmtDBConnString;
		}

	}
}
