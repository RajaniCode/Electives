//---------------------------------------------------------------------
// File:      TPMAccess.asmx.cs
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Configuration; 

namespace TPMAccess
{
	/// <summary>
	/// Summary description for TPMAccess.
	/// </summary>
//	public class Partner
//	{
//		public string ID;
//	}
	[WebService(Namespace="http://TPMAccess/WS/")]
	public class TPMAccess : System.Web.Services.WebService
	{
		public TPMAccess()
		{
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

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod]
		public string GetPartner(string partnerID)
		{

			TPPubWS tpWS = new TPPubWS(ServerName());
			tpWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
			return tpWS.GetPartner(partnerID);
		}

		[WebMethod]
		public void UpdatePartner(string partnerXml)
		{
			TPPubWS tpWS = new TPPubWS(ServerName());
			tpWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
			tpWS.UpdatePartner(partnerXml);
		}

		public string ServerName()
		{
			string servername = (string)ConfigurationSettings.AppSettings["Server"];
			return servername;
		}
	}
}
