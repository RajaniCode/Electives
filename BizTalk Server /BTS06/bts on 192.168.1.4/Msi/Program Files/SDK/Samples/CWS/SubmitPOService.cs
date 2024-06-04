//---------------------------------------------------------------------
// File: SubmitPOService.asmx.cs
//
// Summary: This is an abstraction of a real world Web Service. This Web
//          Service takes fields out of the incoming message and writes
//          it to disk. In reality, this Web Service could be modified to
//          manipulate the data within the message and act accordingly.
//
// Sample: ConsumeWebService
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using System.Xml;

namespace Microsoft.Samples.BizTalk.POWebService
{
	/// <summary>
	/// This sample web service is used to illustrate how orchestrations can
	/// interact with external web services. This particular web service has
	/// a single method which receives a PO order from an orchestration and
	/// returns an Invoice based on the information within the PO.
	/// </summary>
	[WebService(Namespace = "http://Microsoft.Samples.BizTalk.ConsumeWebService/webservices/")]
	public class POWebService : System.Web.Services.WebService
	{

		public POWebService()
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
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion

		public class InboundPO
		{
			public string PO_Num;
			public string Date;
		}

		public class Invoice
		{
			public string InvoiceNumber;
		}


		// This method accepts a PO represented as a XML document for processing. It then
		// replies back to the calling client and returns an invoice as a XML
		// document
		[WebMethod]
		public Invoice submitPO(InboundPO PODocument)
		{
			// Create a new Invoice document and set the InvoiceNumber equal to that of
			// the incoming PO_Num
			Invoice invoiceDocument = new Invoice();
			invoiceDocument.InvoiceNumber = PODocument.PO_Num;
			return invoiceDocument;
		}
	}
}
