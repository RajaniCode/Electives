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

using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml.Serialization;

using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;

#endregion

namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubSapCall
{
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "StubSAPWebServiceSoap", Namespace = "http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/SAP/")]
    
    internal class StubSapWSProxy : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        /// <remarks/>
        internal StubSapWSProxy()
        {
             this.Url = "http://localhost/Microsoft.Samples.BizTalk.WoodgroveBank.StubSAP/StubSAPWebService.asmx";
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/SAP/GetAccountDetails", 
			RequestNamespace = "http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/SAP/", 
			ResponseNamespace = "http://Microsoft.Samples.Biztalk.WoodgroveBank.CustomerService/SAP/", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]

        [return: System.Xml.Serialization.XmlElementAttribute("BAPI_BANKACCT_GET_DETAIL_Response", Namespace = "http://schemas.microsoft.com/BizTalk/2003")]
        public BAPI_BANKACCT_GET_DETAIL_Response GetAccountDetails([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/BizTalk/2003")] BAPI_BANKACCT_GET_DETAIL_Request BAPI_BANKACCT_GET_DETAIL_Request)
        {
            object[] results = this.Invoke("GetAccountDetails", new object[] {
                BAPI_BANKACCT_GET_DETAIL_Request
            });
            return ((BAPI_BANKACCT_GET_DETAIL_Response)(results[0]));
        }
    }
}
