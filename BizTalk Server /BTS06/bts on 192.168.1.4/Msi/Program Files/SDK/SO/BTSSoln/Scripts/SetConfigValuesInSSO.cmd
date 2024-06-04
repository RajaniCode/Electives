
@echo off

REM
REM ===================================================================================== 
REM                                                                                       
REM Microsoft.Samples.BizTalk.WoodgroveBank
REM End to end Service Oriented Scenatio sample for BizTalk Server.                       
REM                                                                                       
REM Command file to set the values of the configuration parameters in the SSO configuration
REM store application.  The configuration store application should have been created before 
REM running this command.
REM                                                                                     
REM Copyright (c) Microsoft Corporation. All rights reserved.                       
REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,          
REM EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES      
REM OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.                           
REM                                                                                       
REM =====================================================================================


REM Change the following values specific to your environment.  Refer to the documentation for more details
REM on these parameters.  Where possible, default values are provided here...

REM If there is no value for a field, use "" so the use of these variables later in the command lines result in 
REM empty string values.

set SAPAdapterTimeout=10000
set SAPInlineTimeout=10000
set SAPInlineHostName=""
set SAPInlineClientNumber=""
set SAPInlineSystemNumber=""
set SAPInlineUserName=""
set SAPInlinePassword=""
set PendingTransactionsAdapterTimeout=10000
set PendingTransactionsInlineTimeout=10000
set PendingTransactionsInlineURL=""
set PendingTransactionsInlineSSOAffiliateApp=WoodgroveBank.PendingTransactions
set PaymentTrackingAdapterTimeout=10000
set PaymentTrackingInlineTimeout=10000
set PaymentTrackingInlineQManager=""
set PaymentTrackingInlineMQChannelDefinition="" 
set PaymentTrackingInlineRequestQueue=LastPaymentsInputQueue
set PaymentTrackingInlineResponseQueue=LastPaymentsOutputQueue
set PaymentTrackingInlineSSOAffiliateApp=WoodgroveBank.PaymentTracker
set StubSAPWebServiceURL=""

REM end of settings to be changed... 

set PmntTrackReceivePipeSchemaType="Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.LastPaymentResponse, Microsoft.Samples.BizTalk.WoodgroveBank.Schemas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

set PmntTrackSendPipeSchemaType="Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.LastPaymentRequest, Microsoft.Samples.BizTalk.WoodgroveBank.Schemas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"


SET ConfigApp=WoodgroveBank.CustomerService 

REM run commnad to set the configuration values...

echo Setting Configuration values
..\..\..\Common\SSOApplicationConfig\bin\BTSScnSSOApplicationConfig.exe -set %ConfigAPP% ConfigProperties SAP.Adapter.Timeout %SAPAdapterTimeout% SAP.Inline.Timeout %SAPInlineTimeout% SAP.Inline.HostName %SAPInlineHostName% SAP.Inline.ClientNumber %SAPInlineClientNumber% SAP.Inline.SystemNumber %SAPInlineSystemNumber% SAP.Inline.UserName %SAPInlineUserName% SAP.Inline.Password %SAPInlinePassword% PendingTransactions.Adapter.Timeout %PendingTransactionsAdapterTimeout% PendingTransactions.Inline.Timeout %PendingTransactionsInlineTimeout% PendingTransactions.Inline.URL %PendingTransactionsInlineURL% PendingTransactions.Inline.SSOAffiliateApp %PendingTransactionsInlineSSOAffiliateApp% PaymentTracking.Adapter.Timeout %PaymentTrackingAdapterTimeout% PaymentTracking.Inline.Timeout %PaymentTrackingInlineTimeout% PaymentTracking.Inline.QManager %PaymentTrackingInlineQManager% PaymentTracking.Inline.MQChannelDefinition %PaymentTrackingInlineMQChannelDefinition% PaymentTracking.Inline.RequestQueue %PaymentTrackingInlineRequestQueue% PaymentTracking.Inline.ResponseQueue %PaymentTrackingInlineResponseQueue% PaymentTracking.Inline.SSOAffiliateApp %PaymentTrackingInlineSSOAffiliateApp% StubSAPWebService.URL %StubSAPWebServiceURL% PaymentTrackerReceivePipeline.SchemaTypeName %PmntTrackReceivePipeSchemaType% PaymentTrackerSendPipeline.SchemaTypeName %PmntTrackSendPipeSchemaType%


echo The configuration values are the following
echo "" 

..\..\..\Common\SSOApplicationConfig\bin\BTSScnSSOApplicationConfig.exe -get %ConfigAPP% ConfigProperties SAP.Adapter.Timeout SAP.Inline.Timeout SAP.Inline.HostName SAP.Inline.ClientNumber SAP.Inline.SystemNumber SAP.Inline.UserName SAP.Inline.Password PendingTransactions.Adapter.Timeout PendingTransactions.Inline.Timeout PendingTransactions.Inline.URL PendingTransactions.Inline.SSOAffiliateApp PaymentTracking.Adapter.Timeout PaymentTracking.Inline.Timeout PaymentTracking.Inline.QManager PaymentTracking.Inline.MQChannelDefinition PaymentTracking.Inline.RequestQueue PaymentTracking.Inline.ResponseQueue PaymentTracking.Inline.SSOAffiliateApp StubSAPWebService.URL PaymentTrackerReceivePipeline.SchemaTypeName PaymentTrackerSendPipeline.SchemaTypeName
