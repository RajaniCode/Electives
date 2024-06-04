//----------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.StubPendingTransactions
//
// File: StubPendingTransWebService.asmx.cs
//
// End 2 end Service Oriented scenario - stub version that does not require SAP, mainframe and 
// MQSeries adapters.  Web service to emulate the behavior of calling the Pending transactions
// mainframe system.
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

namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubPendingTransactions
{
	/// <summary>
	/// Web service acting as the Pending Transactions Web Service...
	/// </summary>

	[WebService(Namespace="http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/PendingTransactions")]

	public class StubPendingTransactionsWebService : System.Web.Services.WebService
	{
		public StubPendingTransactionsWebService()
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
		/// Obtain the pending transactions
		/// </summary>
		/// <param name="ptrq"> Pending transactions request
		/// </param>
		/// <returns>
		/// Pending transactions Response
		/// </returns>
		/// 
		[return: XmlElement(Namespace = "http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.PendingTransactionsResponse",
					 ElementName = "PendingTransactionsResponse")]
		[WebMethod]

		public PendingTransactionsResponse GetPendingTransactions([XmlElement("PendingTransactionsRequest", 
																	   Namespace="http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.PendingTransactionsRequest")] 
			PendingTransactionsRequest  ptrq)
		{
			return generateTransactionsLocally(ptrq);
		}

		/// <summary>
		/// Generate transactions locally without going to the mainframe
		/// </summary>
		/// <param name="ptrq">
		/// Pending Transactions Request
		/// </param>
		/// <returns>
		/// Pending Transactions Response
		/// </returns>
		private PendingTransactionsResponse generateTransactionsLocally(PendingTransactionsRequest  ptrq)
		{
			const int MAX_PENDING_TRANSACTIONS = 500;

			// Generate a random number (upto the max allowed) of pending transactions ...
			// There is at least one pending transaction...
			Random rand = new Random (unchecked((int)DateTime.Now.Ticks));
			int numTransactions = rand.Next(MAX_PENDING_TRANSACTIONS - 1 ) + 1;

			PendingTransactionsResponsePendingTransaction [] transactions = new PendingTransactionsResponsePendingTransaction [numTransactions];

			for (int i = 0 ; i < numTransactions; i++)
			{
				transactions[i] = new PendingTransactionsResponsePendingTransaction ();
				
				// Each transaction is posted randomly between now and 60 days ago and for amounts upto $1000

				transactions[i].AmountPosted = new Decimal(rand.Next(1000));
				TimeSpan ts = new TimeSpan(rand.Next(60), 0, 0, 0);
				transactions[i].DatePosted = System.DateTime.Now.Subtract(ts);
				transactions[i].MerchantCity = "MerchantCity - " + i.ToString();
				transactions[i].MerchantCountry = "USA";
				transactions[i].MerchantName = "Merchant Name - " + i.ToString();
			}

			PendingTransactionsResponseResponseStatusError ptErr = new PendingTransactionsResponseResponseStatusError ();
			ptErr.ErrorDescription = "";
			ptErr.ErrorNumber = "0000";
			ptErr.ErrorSource = "";

			PendingTransactionsResponseResponseStatus ptStatus = new PendingTransactionsResponseResponseStatus();

			ptStatus.Error = ptErr;
			ptStatus.Result = "SUCCESS";

			// Assemble the response...
			PendingTransactionsResponse ptResp = new PendingTransactionsResponse();

			ptResp.AccountNumber = ptrq.AccountNumber ;
			ptResp.PendingTransaction = transactions;
			ptResp.ResponseStatus = ptStatus;

			return ptResp;
		}
	}
}
