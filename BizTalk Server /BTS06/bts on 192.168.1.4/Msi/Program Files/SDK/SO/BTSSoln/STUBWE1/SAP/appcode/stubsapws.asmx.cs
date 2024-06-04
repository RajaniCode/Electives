//----------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.StubSAP
//
// File: StubSAPWebService.asmx.cs
//
// End 2 end Service Oriented scenario - stub version that does not require SAP and 
// MQSeries adapters.  Web service to emulate the behavior of calling SAP.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. THE
// ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE AND
// INFORMATION REMAINS WITH THE USER.
//
//----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubSAP
{
	/// <summary>
	/// Web service to emulate the behavior of calling SAP.
	/// </summary>
	/// 

	[WebService(Namespace="http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/SAP/")]

	public class StubSAPWS : System.Web.Services.WebService
	{
		public StubSAPWS()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		/// <summary>
		///  Get account details by randomly generating account information.
		/// </summary>
		/// <param name="acctReq"> BAPI_BANKACCT_GET_DETAIL_Request - account information containing the request
		/// </param>
		/// <returns>
		/// BAPI_BANKACCT_GET_DETAIL_Response - response with account details.
		/// </returns>
		[return: XmlElement(Namespace = "http://schemas.microsoft.com/BizTalk/2003",
					 ElementName = "BAPI_BANKACCT_GET_DETAIL_Response")]
		[WebMethod]

		public BAPI_BANKACCT_GET_DETAIL_Response GetAccountDetails ([XmlElement("BAPI_BANKACCT_GET_DETAIL_Request", 
																		 Namespace = "http://schemas.microsoft.com/BizTalk/2003")]
			BAPI_BANKACCT_GET_DETAIL_Request acctReq)
		{	
			BAPI_BANKACCT_GET_DETAIL_ResponseE_ACCOUNT  respAccount = new BAPI_BANKACCT_GET_DETAIL_ResponseE_ACCOUNT();	

			// These values are modeled after the test SAP system. 
			respAccount.ACCTEXT = "Test SAP account for Stub version of the scenario";
			respAccount.ACCTYPE = "";
			respAccount.BANKAREA = "US00";
			respAccount.COMPANY = "F300";
			respAccount.CURRENCY = "USD";
			respAccount.CURRENCY_OLD = "";
			respAccount.DELDATE = "00000000";
			respAccount.IBAN = "US37720003267890123456";
			respAccount.NOSTRO = "";
			respAccount.OPENDATE = "20041202";
			respAccount.PRODEXT = "CREDITCARD";
			respAccount.STATUS = "1";
			respAccount.STATUS_ADD = "0010";
			respAccount.TXTACCTYPE = "Credit Card Management" ;
			respAccount.VERSION = "001";

			const int NUM_ACCT_LIMITS = 4;
			BAPI_BANKACCT_GET_DETAIL_ResponseT_LIMIT[] respLimit = new BAPI_BANKACCT_GET_DETAIL_ResponseT_LIMIT[NUM_ACCT_LIMITS];

			for (int i = 0 ; i < NUM_ACCT_LIMITS ; i++)
			{
				respLimit[i] = new BAPI_BANKACCT_GET_DETAIL_ResponseT_LIMIT();
				respLimit[i].VALID_FROM = "20000101";
				respLimit[i].VALID_TO = "99991231";
				respLimit[i].LIM_CUR  = "USD";
				respLimit[i].LIM_OK = "X";
				respLimit[i].REFLIMIT = "";
			}

			// These amount numbers are hard coded as we really don't have an SAP system to talk to...

			respLimit[0].LIMSUM = "10000";			// Credit limit of 10K always...
			respLimit[0].LIMTYPE = "02";			// Limit type code corresponding to credit limit
			respLimit[0].TXTLIMTYPE = "Internal account limit";

			respLimit[1].LIMSUM = "2000";
			respLimit[1].LIMTYPE = "01";			// Limit type code from SAP
   			respLimit[1].TXTLIMTYPE = "Account overdraft limit";

			respLimit[2].LIMSUM = "1000";
			respLimit[2].LIMTYPE = "03";			// Limit type code from SAP
			respLimit[2].TXTLIMTYPE = "External account limit";

			respLimit[3].LIMSUM = "1000";
			respLimit[3].LIMTYPE = "08";			// Limit type code from SAP
			respLimit[3].TXTLIMTYPE = "Cash Advance Limit";

			// No entries in the balance table
			const int NUM_ENTRIES_BALANCE = 0;
			BAPI_BANKACCT_GET_DETAIL_ResponseT_BALANCE[] respBalance = new BAPI_BANKACCT_GET_DETAIL_ResponseT_BALANCE[NUM_ENTRIES_BALANCE];

			BAPI_BANKACCT_GET_DETAIL_Response resp = new BAPI_BANKACCT_GET_DETAIL_Response();
			resp.T_BALANCE = respBalance;
			resp.T_LIMIT = respLimit;
			resp.E_ACCOUNT = respAccount;
			
			resp.E_BALANCE = "";

			resp.E_RC = "";			// Success...

			return resp;
		}
	}
}
