//----------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.StubPaymentTracker
//
// File: StubPaymentTrackerWebService.asmx.cs
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

namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubPaymentTracker
{
	/// <summary>
	/// Web service to emulate the behavior of calling into the Payment Tracking system in the
	/// end to end so scenario.
	/// </summary>
	
	[WebService(Namespace="http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/PaymentTracker/")]
	
	public class StubPaymentTrackerWebService : System.Web.Services.WebService
	{
		public StubPaymentTrackerWebService()
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


		[return: XmlElement(Namespace = "http://Microsoft.Sampsles.BizTalk.WoodgroveBank.Schemas.LastPaymentResponse",
					 ElementName = "LastPaymentResponse")]
		[WebMethod]

		public LastPaymentResponse GetLastPayments([XmlElement("LastPaymentRequest", 
													 Namespace="http://Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.LastPaymentRequest")] 
			LastPaymentRequest  req)
		{
			const int MAX_LAST_PAYMENTS = 5;

			// Generate a random number (upto the max allowed) of payments...
			// Make sure there is at least one payment...
			Random rand = new Random (unchecked((int)DateTime.Now.Ticks));
			int numPayments = rand.Next(MAX_LAST_PAYMENTS - 1) + 1;
			LastPaymentResponsePayment[] payments = new LastPaymentResponsePayment[numPayments];

			// Fill in each of these payments with values that are randomly generated...
			for (int i = 0 ; i < numPayments ; i++)
			{
				payments[i] = new LastPaymentResponsePayment();
				// Each payment was made (randomly) between now and 60 days ago...
				TimeSpan ts = new TimeSpan(rand.Next(60),0,0,0);
				payments[i].DateLastPayment = System.DateTime.Now.Subtract(ts);

				// Each payment can be between 1 and 500
				payments[i].AmountLastPayment = new Decimal (rand.Next(500));
			}

			// Create response status 
			LastPaymentResponseResponseStatusError lpError = new LastPaymentResponseResponseStatusError();
			lpError.ErrorNumber = "0000";
			lpError.ErrorDescription = "";
			lpError.ErrorSource = "";

			LastPaymentResponseResponseStatus responseStatus = new LastPaymentResponseResponseStatus();
			responseStatus.Error = lpError;
			responseStatus.Result = "SUCCESS";

			// Assemble the response
			LastPaymentResponse	resp = new LastPaymentResponse();
			resp.ResponseStatus = responseStatus;
			resp.Payment = payments;

			// Copy the account number and name info from the request itself...
			resp.AccountNumber = req.AccountNumber;
			resp.CustomerName = req.CustomerName;

			return resp;
		}

	}
}
