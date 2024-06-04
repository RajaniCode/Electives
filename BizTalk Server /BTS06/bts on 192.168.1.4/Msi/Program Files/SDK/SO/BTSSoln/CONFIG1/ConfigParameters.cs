//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.Config.ConfigParameters
// Helper class to read configuration values of the scenario.
//
// Copyright (c) Microsoft Corporation. All rights reserved  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

using System;
using System.Diagnostics;
using System.Threading;

using Microsoft.BizTalk.SSOClient.Interop;


namespace Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper
{
	/// <summary>
	/// Helper class to read configuration parameters for the scenario.
	/// </summary>
	public sealed class ConfigParameters
	{
		// SSO Config store parameter names
		private const string SSO_CONFIG_APP = "WoodgroveBank.CustomerService";
		private const string SSO_IDENTIFIER_NAME = "ConfigProperties";

		// no instances of this class are allowed...
		private ConfigParameters()
		{ 
		}

		public enum SsoConfigParameter
		{
			SapAdapterTimeout = 0,
			SapInlineTimeout = 1,
			SapInlineHostName = 2,
			SapInlineClientNumber = 3,
			SapInlineSystemNumber = 4,
			SapInlineUserName = 5,
			SapInlinePassword = 6,
			PendingTransactionsAdapterTimeout = 7,
			PendingTransactionsInlineTimeout = 8,
			PendingTransactionsUrl = 9,
			PendingTransactionsSsoAffiliateApp = 10,
			PaymentTrackingAdapterTimeout = 11,
			PaymentTrackingInlineTimeout = 12,
			PaymentTrackingQManager = 13,
			PaymentTrackingMQChannelDef = 14,
			PaymentTrackingRequestQueue = 15,
			PaymentTrackingResponseQueue = 16,
			PaymentTrackingSsoAffiliateApp = 17,
			StubSapWebServiceUrl = 18,
			PaymentTrackingReceivePipelineSchemaType = 19,
			PaymentTrackingSendPipelineSchemaType = 20
		};

		// SSO Config parameter names - associated with the above enumeration by array index...
		
		private static string[] ssoConfigParamNames = 
			{
				"SAP.Adapter.Timeout",
				"SAP.Inline.Timeout",
				"SAP.Inline.HostName",
				"SAP.Inline.ClientNumber",
				"SAP.Inline.SystemNumber",
				"SAP.Inline.UserName",
				"SAP.Inline.Password",
				"PendingTransactions.Adapter.Timeout",
				"PendingTransactions.Inline.Timeout",
				"PendingTransactions.Inline.URL",
				"PendingTransactions.Inline.SSOAffiliateApp",
				"PaymentTracking.Adapter.Timeout",
				"PaymentTracking.Inline.Timeout",
				"PaymentTracking.Inline.QManager",
				"PaymentTracking.Inline.MQChannelDefinition",
				"PaymentTracking.Inline.RequestQueue",
				"PaymentTracking.Inline.ResponseQueue",
				"PaymentTracking.Inline.SSOAffiliateApp",
                "StubSAPWebService.URL",
				"PaymentTrackerReceivePipeline.SchemaTypeName",
				"PaymentTrackerSendPipeline.SchemaTypeName"
	};

		private static Timer cacheRefreshTimer;
		private static ISSOConfigStore ssoConfigStore;
		private static ReaderWriterLock syncLock;

		// Cache refresh interval in milli seconds - it is set to 5 minutes.
		private const int CacheRefreshInterval = 5 * 60 * 1000;
		
		private static ConfigPropertyBag ssoPropBag;

		static ConfigParameters()
		{
			ssoConfigStore = new ISSOConfigStore();
			ssoPropBag = new ConfigPropertyBag();
			syncLock = new ReaderWriterLock();

			ssoConfigStore.GetConfigInfo(SSO_CONFIG_APP, SSO_IDENTIFIER_NAME, SSOFlag.SSO_FLAG_RUNTIME, ssoPropBag);

			cacheRefreshTimer = new Timer(new TimerCallback(ConfigParameters.cacheRefreshCallback), null, CacheRefreshInterval, CacheRefreshInterval);
		}

		private static void cacheRefreshCallback(object state)
		{
			// Disable the timer until we are done loading the cache...
			cacheRefreshTimer.Change(Timeout.Infinite, CacheRefreshInterval);

			System.Diagnostics.Trace.WriteLine("Loading SSO config data in cache");

			// Get the data from SSO in a different property bag so, we don't have to lock the property bag
			// used by the reader threads for a long time - the SSO call is a remote call and could take a bit to
			// complete...

			ConfigPropertyBag propBag2 = new ConfigPropertyBag();
			ssoConfigStore.GetConfigInfo(SSO_CONFIG_APP, SSO_IDENTIFIER_NAME, SSOFlag.SSO_FLAG_RUNTIME, propBag2);

			// Acquite a write Lock before updating the cached values...
			syncLock.AcquireWriterLock(Timeout.Infinite);

			try
			{
				ssoPropBag = propBag2;
			}
			finally 
			{
				syncLock.ReleaseWriterLock();
			}

			cacheRefreshTimer.Change(CacheRefreshInterval, CacheRefreshInterval);
		}

		public static string GetConfigParameter(SsoConfigParameter configParameter)
		{
			object propValue;

			syncLock.AcquireReaderLock(Timeout.Infinite);

			try
			{
				ssoPropBag.Read(ssoConfigParamNames[(int)configParameter], out propValue, 0);
			}
			finally
			{
				syncLock.ReleaseReaderLock();
			}
			
			return  (string)propValue;
		}
	}
}
