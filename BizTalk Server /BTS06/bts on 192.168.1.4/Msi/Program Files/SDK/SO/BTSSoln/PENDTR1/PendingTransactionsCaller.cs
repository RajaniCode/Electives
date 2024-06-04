//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactionsCall
// Helper assembly to call the Pending Transaction System inline from orchestrations.
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Net;

using Microsoft.XLANGs.BaseTypes;
using Microsoft.BizTalk.SSOClient.Interop;

using Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper;
using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;
using Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactionsCall.PendingTransactionsWS;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactionsCall
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public sealed class PendingTransactionsCaller
	{
		
		// No instances of this class are allowed...
		private PendingTransactionsCaller()
		{
		}

		private static ISSOTicket ssoTicket = new ISSOTicket();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="requestMsg"></param>
		/// <returns></returns>
		public static PendingTransactionsResponse GetPendingTransactionsResponse(XLANGMessage requestMsg)
		{
			if (null == requestMsg) throw new ArgumentNullException("requestMsg", "Request message can not be null");

			try
			{
				// Get config parameter values...
				int ptTimeout = Convert.ToInt32(
						ConfigParameters.GetConfigParameter(
							ConfigParameters.SsoConfigParameter.PendingTransactionsInlineTimeout),
						System.Globalization.CultureInfo.CurrentCulture
					);

				string ptURL = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PendingTransactionsUrl);

				string ssoAffliateApp = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PendingTransactionsSsoAffiliateApp);

				// Rededdm the SSO ticket and get the userid/password to use to interact with Payment Tracking System 
				string msgTicket = (string)requestMsg.GetPropertyValue(typeof(BTS.SSOTicket));
				string originatorSID = (string)requestMsg.GetPropertyValue(typeof(Microsoft.BizTalk.XLANGs.BTXEngine.OriginatorSID));


				string pendTransUserName;
				string[] pendTransCredential = ssoTicket.RedeemTicket(ssoAffliateApp, originatorSID, msgTicket, SSOFlag.SSO_FLAG_NONE, out pendTransUserName); 

				PendingTransactionsRequest req = (PendingTransactionsRequest)requestMsg[0].RetrieveAs(typeof(PendingTransactionsRequest));
				PendingTransactionsResponse resp;

				using (PendingTransactionsWebService   svc = new PendingTransactionsWebService())
				{
					svc.Url = ptURL;
					svc.Timeout = ptTimeout;
										
					// The web service is is using basic authentication, so need to send the user id and 
					// password in the request...

					CredentialCache credCache = new CredentialCache();
					NetworkCredential credentialToUse = new NetworkCredential(pendTransUserName, pendTransCredential[0]);
					credCache.Add(new Uri(svc.Url), "Basic", credentialToUse);
					svc.Credentials = credCache;

					resp = svc.GetPendingTransactions(req);
				}
				return resp;				
			}
			catch (System.Net.WebException webEx)
			{
				if (webEx.Status == WebExceptionStatus.Timeout)
				{
					throw new PendingTransactionsTimeoutException();
				}
				else
				{
					Trace.WriteLine("Other Net.WebException: " + webEx.ToString() + (null == webEx.InnerException ? "" : ("Inner Exception: " + webEx.InnerException.ToString())));
					throw;
				}
			}
			catch(System.Exception ex)
			{
				Trace.WriteLine("Other Exception: " + ex.ToString() + (null == ex.InnerException ? "" : ("Inner Exception: " + ex.InnerException.ToString())));
				throw;
			}
		}
	}
}
