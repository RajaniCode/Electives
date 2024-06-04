//----------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactions
//
// File: PendingTransactions.asmx.cs
//
// End 2 end Service Oriented scenario - web service to interact with the mainframe
// to obtain and return the pending transactions 
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
using System.Runtime.InteropServices;

using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;
//using SOHISTIUsingNet;
//using SOServer;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactions
{
	/// <summary>
	/// Web Service to query the mainframe for pending transactiosn and return them.
	/// </summary>
	
	[WebService(Namespace="http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/PendingTransactions")]

	public class PendingTransactionsWebService : System.Web.Services.WebService
	{
		public PendingTransactionsWebService()
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
		/// Obtain the Pending Transactions
		/// </summary>
		/// <param name="ptrq">
		/// Pending Transactions Request
		/// </param>
		/// <returns>
		/// Pending Transactions Response
		/// </returns>
		[return: XmlElement(Namespace = "http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.PendingTransactionsResponse",
					 ElementName = "PendingTransactionsResponse")]
		[WebMethod]

		public PendingTransactionsResponse GetPendingTransactions([XmlElement("PendingTransactionsRequest", 
																	   Namespace="http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.PendingTransactionsRequest")] 
			PendingTransactionsRequest  request)
		{
			if (null == request) 
			{
				throw new ArgumentNullException ("request", "Request can not be null");
			}

			short errorNum ;
			string errorDesc;
			string errorSrc;

			PendingTransactionsResponse ptResp;
			
			ptResp = new PendingTransactionsResponse();
			PendingTransactionsResponsePendingTransaction [] transactions;
			PendingTransactionsResponseResponseStatusError ptErr = new PendingTransactionsResponseResponseStatusError ();
			PendingTransactionsResponseResponseStatus ptStatus = new PendingTransactionsResponseResponseStatus();

			SOHISTIUsingCOM.PendingTransInCICS ptObj = null;

			try
			{
				ptObj = new SOHISTIUsingCOM.PendingTransInCICS();

				string accountNum = request.AccountNumber;
		
				SOHISTIUsingCOM.TRAN_TBL tranTbl;
				
				ptObj.GetPendingTransactions(ref accountNum, out errorDesc, out errorNum, out errorSrc, out tranTbl );

				transactions = new PendingTransactionsResponsePendingTransaction [tranTbl.COUNT];

				for (int i = 0 ; i < tranTbl.COUNT ; i++)
				{
					SOHISTIUsingCOM.TRANS_REC transactionRec = (SOHISTIUsingCOM.TRANS_REC)tranTbl.MEMBER1.GetValue(i);

					transactions[i] = new PendingTransactionsResponsePendingTransaction ();
					
					string mfDate = transactionRec.TRAN_DATE;

					int month = System.Convert.ToInt32(mfDate.Substring(0,2), System.Globalization.CultureInfo.CurrentCulture);
					int day = System.Convert.ToInt32(mfDate.Substring(2,2), System.Globalization.CultureInfo.CurrentCulture);
					int year = System.Convert.ToInt32(mfDate.Substring(4,4), System.Globalization.CultureInfo.CurrentCulture);
					int hour = System.Convert.ToInt32(mfDate.Substring(8,2), System.Globalization.CultureInfo.CurrentCulture) - 1; // Mainframe numbers hours from 1
					int minute = System.Convert.ToInt32(mfDate.Substring(10,2), System.Globalization.CultureInfo.CurrentCulture);

					// In certain cases, due to a bug in the cobol code in the mainframe, hour/minute
					// values returned could be out of range... addresss these here...
										
					if (hour < 0) hour = 0;
					if (hour > 23) hour = 23;
					if (minute < 0) minute = 0;
					if (minute > 59) minute = 59;

					transactions[i].DatePosted = new System.DateTime(year, month, day, hour, minute, 0);
					
					transactions[i].AmountPosted = (Decimal)transactionRec.TRAN_AMOUNT ;
					transactions[i].MerchantCity = transactionRec.MERCHANT_CITY;
					transactions[i].MerchantCountry = transactionRec.MERCHANT_COUNTRY;
					transactions[i].MerchantName = transactionRec.MERCHANT_NAME;
				}

				ptErr.ErrorDescription = "";
				ptErr.ErrorNumber = "0000";
				ptErr.ErrorSource = "";

				ptStatus.Error = ptErr;
				ptStatus.Result = "SUCCESS";

				// Assemble the response...
				ptResp.AccountNumber = request.AccountNumber ;
				ptResp.PendingTransaction = transactions;
				ptResp.ResponseStatus = ptStatus;


				return ptResp;
			}
				// Catch timeout and translate into a timeout error...
			catch (System.Runtime.InteropServices.COMException comEx)
			{
				const long HIS_TIMEOUT_ERROR = 2157;
				if ((comEx.ErrorCode & 0x00000000FFFFFFFF) != HIS_TIMEOUT_ERROR)
				{
					throw;	// Rethrow if this is not a timeout...
				}

				ptErr.ErrorDescription = "Timeout from Pending Transactions Mainframe System";
				ptErr.ErrorNumber = "0100";
				ptErr.ErrorSource = "Mainframe";

				ptStatus.Error = ptErr;
				ptStatus.Result = "ERROR";

				// No transactions as there was an exception
				transactions = new PendingTransactionsResponsePendingTransaction [0];

				ptResp.AccountNumber = request.AccountNumber ;
				ptResp.PendingTransaction = transactions;
				ptResp.ResponseStatus = ptStatus;

				return ptResp;

			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Trace.WriteLine("Exception: " + ex.ToString());

				// Send the exception stuff in the response.
				string errMsg = ex.ToString();
				string innerMsg = null != ex.InnerException ? ex.InnerException.ToString() : "" ;

				ptErr.ErrorDescription = "Exception:\n" + errMsg + "\n" + "Inner Exception:\n" + innerMsg;
				ptErr.ErrorNumber = "0001";
				ptErr.ErrorSource = "Mainframe";

				ptStatus.Error = ptErr;
				ptStatus.Result = "ERROR";

				// No transactions as there was an exception
				transactions = new PendingTransactionsResponsePendingTransaction [0];

				ptResp.AccountNumber = request.AccountNumber ;
				ptResp.PendingTransaction = transactions;
				ptResp.ResponseStatus = ptStatus;

				return ptResp;

			}
			finally
			{
				// Even though Releasing the com object is not strictly necessary as the interop layer
				// will release it, it is still a good idea to release it to expedite the releasing
				// process..
				if (null != ptObj)
				{
					while (Marshal.ReleaseComObject(ptObj) > 0 )
						;
					GC.SuppressFinalize(ptObj);
				}
				ptObj = null;
			}
		}
	}
}
