REM
REM ===================================================================================== 
REM                                                                                       
REM Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations                                           
REM Generate classes from schemas 
REM                                                                                       
REM Copyright (c) Microsoft Corporation. All rights reserved.                    
REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,          
REM EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES      
REM OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.                           
REM                                                                                       
REM ===================================================================================== 

xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses LastPaymentResponse.xsd
xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses LastPaymentRequest.xsd

xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses PendingTransactionsResponse.xsd
xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses PendingTransactionsRequest.xsd

xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses BAPI_BANKACCT_GET_DETAIL.xsd

xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses CustomerServiceRequest.xsd
xsd /c /l:CS /n:Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses CustomerServiceResponse.xsd

move LastPaymentRequest.cs ..\SchemaClasses
move LastPaymentResponse.cs ..\SchemaClasses
move PendingTransactionsRequest.cs ..\SchemaClasses
move PendingTransactionsResponse.cs ..\SchemaClasses
move BAPI_BANKACCT_GET_DETAIL.cs ..\SchemaClasses
move CustomerServiceRequest.cs ..\SchemaClasses
move CustomerServiceResponse.cs ..\SchemaClasses

