//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
// SSO Configuration Helper class
//  
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.BizTalk.SSOClient.Interop;

namespace  Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
{
	/// <summary>
	/// Property bag for SsoConfigHelper
	/// </summary>
    [Serializable]
    internal class ConfigurationPropertyBag : Microsoft.BizTalk.SSOClient.Interop.IPropertyBag
	{
		private HybridDictionary properties;
		
		public ConfigurationPropertyBag() 
		{
			properties = new HybridDictionary();
		}

		public void Read(string name, out object data, int i) 
		{ 
			data = properties[name];
		}

		public void Write(string name, ref object data) 
		{ 
			properties.Add(name, data);
		}
	}

    /// <summary>
    /// SsoConfigHelper helps get configuration data
    /// </summary>
    [Serializable]
    public class SsoConfigHelper
    {
        // constants
        private const string AppName = "SouthridgeVideo.CableOrder";
        private const string Identifier = "ConfigProperties";
        private const string CableProvisioningSystemLocationPropName = "CableProvisioningSystemLocation";
        private const string TotalStagesPropName = "TotalStages";
        private const string CacheRefreshIntervalPropName = "CacheRefreshInterval";

        // instance members
        private string _cableProvisioningSystemLocation = string.Empty;
        private uint _totalStages;
        // Cache refresh interval is in milliseconds - it is set to 5 minutes.
        private int _cacheRefreshInterval = 5 * 60 * 1000;

		// static members
        private static Timer cacheRefreshTimer;
		private static ReaderWriterLock syncLock = new ReaderWriterLock();
        private static SsoConfigHelper _this = new SsoConfigHelper();

		/// <summary>
		/// Gets SsoConfigHelper singleton
		/// </summary>
		/// <returns>SsoConfigHelper singleton</returns>
        public static SsoConfigHelper Singleton
        {
            get { return _this; }
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static SsoConfigHelper()
		{
			// cacheRefreshInterval is a configuration parameter in the SSO store
            SsoConfigHelper.GetConfigData();
            cacheRefreshTimer = new Timer(new TimerCallback(SsoConfigHelper.cacheRefreshCallback), null, _this._cacheRefreshInterval, _this._cacheRefreshInterval);
		}

		/// <summary>
		/// Timer callback that refreshes property values
		/// </summary>
        /// <param name="state">unused</param>
        private static void cacheRefreshCallback(object state)
		{
			// Disable the timer until we are done loading the cache...
			cacheRefreshTimer.Change(Timeout.Infinite, _this._cacheRefreshInterval);

            try
            {
                GetConfigData();
            }
            catch (SsoConfigException)
            {
                Trace.WriteLine("Failed to get SSO data. Will try again with next cache refresh.");
            }

			cacheRefreshTimer.Change(_this._cacheRefreshInterval, _this._cacheRefreshInterval);
		}

        /// <summary>
        /// Singleton: Use GetSsoConfigHelper to construct a SsoConfigHelper 
        /// </summary>
        private SsoConfigHelper()
        {
        }

        /// <summary>
        /// Gets the configuration information from SSO.  
        /// This method must be called before trying to access the properties.
        /// </summary>
        private static void GetConfigData()
        {
            try
            {
                Trace.WriteLine("Loading SSO config data in cache");

                ConfigurationPropertyBag configBag = new ConfigurationPropertyBag();
                ISSOConfigStore ssoStore = new ISSOConfigStore();

                ssoStore.GetConfigInfo(AppName, Identifier, 4, (Microsoft.BizTalk.SSOClient.Interop.IPropertyBag)configBag);

                // Acquite a write Lock before updating the cached values...
                syncLock.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    NumberFormatInfo provider = new NumberFormatInfo();
                    object cableProvisioningSystemLocationPropValue = null;
                    configBag.Read(CableProvisioningSystemLocationPropName, out cableProvisioningSystemLocationPropValue, 0);
                    if (null != cableProvisioningSystemLocationPropValue)
                    {
                        _this._cableProvisioningSystemLocation = (string)cableProvisioningSystemLocationPropValue;
                    }

                    object totalStagesPropValue = null;
                    configBag.Read(TotalStagesPropName, out totalStagesPropValue, 0);
                    if (null != totalStagesPropValue)
                    {
                        // if we store the value as an integer into the config store then we can just cast it
                        // otherwise it's a string that we need to convert
                        _this._totalStages = Convert.ToUInt32((string)totalStagesPropValue, provider);
                    }

                    object cacheRefreshIntervalPropValue = null;
                    configBag.Read(CacheRefreshIntervalPropName, out cacheRefreshIntervalPropValue, 0);
                    if (null != cacheRefreshIntervalPropValue)
                    {
                        // if we store the value as an integer into the config store then we can just cast it
                        // otherwise it's a string that we need to convert
                        _this._cacheRefreshInterval = Convert.ToInt32((string)cacheRefreshIntervalPropValue, provider);
                    }
                }
                finally
                {
                    syncLock.ReleaseWriterLock();
                }
            }
            catch (Exception ex)
            {
                string entry = "Failed to get SSO config data because:/n" + ex.Message;
                Trace.WriteLine(entry);
                EventLog.WriteEntry("SouthridgeVideo", entry, EventLogEntryType.Error);
                SsoConfigException configEx = new SsoConfigException(entry, ex);
                throw configEx;
            }
        }

        /// <summary>
        /// Gets the CableProvisioningSystemLocation configuration property
        /// </summary>
        public string CableProvisioningSystemLocation
        {
            get 
            {
                string location = string.Empty;
                syncLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    location = this._cableProvisioningSystemLocation;
                }
                finally
                {
                    syncLock.ReleaseReaderLock();
                }

                return location;
            }
        }

        /// <summary>
        /// Gets the NumStages configuration property
        /// </summary>
        [CLSCompliant(false)]
        public uint TotalStages
        {
            get
            {
                uint stages = 0;
                syncLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    stages = this._totalStages;
                }
                finally
                {
                    syncLock.ReleaseReaderLock();
                }

                return stages;
            }
        }
    }
    /// <summary>
    /// Exception thrown when a getting configuration data from SSO fails
    /// </summary>
    [Serializable]
    public class SsoConfigException : Exception
    {
        /// <summary>
        /// Initializes a new instance of a SsoConfigException
        /// </summary>
        public SsoConfigException() { }

        /// <summary>
        /// Initializes a new instance of the SsoConfigException class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public SsoConfigException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the SsoConfigException class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception. 
        /// </param>
        public SsoConfigException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the SsoConfigException class with
        /// serialized data.
        /// </summary>
        /// <remarks>
        /// System.Exception impliments ISerializable and therefore the derived
        /// class must impliment its deserialization constructor as orchestrations
        /// will reconstruct objects during the dehyrdration/rehydration process.
        /// </remarks>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected SsoConfigException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

 
