//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.StubSAPCall
// Helper assembly to call the Stub SAP web service to get the account details
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

#region Using directives

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

using Microsoft.XLANGs.BaseTypes;

using Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper;
using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;

#endregion


namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubSapCall
{
    /// <summary>
    /// Helper class to call the stub SAP web service.
    /// </summary>
    public sealed class StubSapCallHelper
    {
        
		// No instances of this class allowed...
		private StubSapCallHelper()
        {
        }

        /// <summary>
		/// Helper function to call the Stub SAP web service...
		/// </summary>
		/// <param name="requestMsg">
		/// XLang message representing the BAPI_BANKACTT_GET_DETAIL request
		/// </param>
		/// <returns>
		/// BAPI_BANKACCT_GET_DETAIL reseponse
		/// </returns>

        public static BAPI_BANKACCT_GET_DETAIL_Response GetAccountDetails(XLANGMessage requestMsg)
        {
			if (null == requestMsg) throw new ArgumentNullException("requestMsg", "Request message can not be null");

            try
            {
                BAPI_BANKACCT_GET_DETAIL_Request request = (BAPI_BANKACCT_GET_DETAIL_Request)requestMsg[0].RetrieveAs(typeof(BAPI_BANKACCT_GET_DETAIL_Request));
                BAPI_BANKACCT_GET_DETAIL_Response resp;
                using (StubSapWSProxy proxy = new StubSapWSProxy())
                {
                    proxy.Url = ConfigParameters.GetConfigParameter(ConfigHelper.ConfigParameters.SsoConfigParameter.StubSapWebServiceUrl);
                    proxy.Timeout = Convert.ToInt32(
						ConfigParameters.GetConfigParameter(
							ConfigHelper.ConfigParameters.SsoConfigParameter.SapInlineTimeout),
						System.Globalization.CultureInfo.CurrentCulture
					);

                    resp = proxy.GetAccountDetails(request);
                   
                }
                return resp;
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    throw new StubSapTimeoutException();
                }
                else
                {
                    Trace.WriteLine("Other Net.WebException: " + webEx.ToString() + (null == webEx.InnerException ? "" : ("Inner Exception: " + webEx.InnerException.ToString())));
                    throw;
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Other Exception: " + ex.ToString() + (null == ex.InnerException ? "" : ("Inner Exception: " + ex.InnerException.ToString())));
                throw;
            }
        }
    }
}
