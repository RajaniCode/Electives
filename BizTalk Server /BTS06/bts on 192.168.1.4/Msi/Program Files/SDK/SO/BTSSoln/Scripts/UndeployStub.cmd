REM ---------------------------------------------------------------------------------
REM  Microsoft.Samples.BizTalk.WoodgroveBank
REM  
REM  Command file to undeploy stub version of the orchestration
REM 
REM  Copyright (c) Microsoft Corporation. All rights reserved.  
REM  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
REM  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
REM  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
REM ---------------------------------------------------------------------------------
REM 

REM The MGMT_DB_SERVER variable points to the local server (localhost) for a single server install. Need to change this
REM for a multi-server install

SET MGMT_DB_SERVER=localhost
SET MGMT_DB=BizTalkMgmtDb

REM - the assignment value needs to be in quotes (") in order to preserve the embedded blanks. Otherwise
REM - the embedded blanks will become delimiters when the variable is used, causing unexpected results.

SET SOLNDIR="%ProgramFiles%\Microsoft BizTalk Server 2006\SDK\Scenarios\SO\BTSSoln"

SET BTS_APP_NAME="BTSScn.SO.CustomerService"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid:"Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"  

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid:"Microsoft.Samples.BizTalk.WoodgroveBank.Maps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded" 

cscript RemoveSendPort.vbs StubSAPWebServicePort
cscript RemoveSendPort.vbs StubPaymentTrackerWebServicePort
cscript RemoveSendPort.vbs StubPendingTransactionsWebServicePort

cscript RemoveReceivePort.vbs StubSOAWebServicePort

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid:"Microsoft.Samples.BizTalk.WoodgroveBank.Schemas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid="Microsoft.Samples.BizTalk.WoodgroveBank.Utilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid="Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid="Microsoft.Samples.BizTalk.WoodgroveBank.ErrorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid="Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveResource -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Luid="Microsoft.Samples.BizTalk.WoodgroveBank.ServiceLevelTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a1054514fc67bded"

btstask RemoveApp -ApplicationName:%BTS_APP_NAME%

gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed
gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.Maps
gacutil /uf Microsoft.Samples.Biztalk.WoodgroveBank.Schemas

gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.Utilities
gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper
gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.ErrorHelper
gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses
gacutil /uf Microsoft.Samples.BizTalk.WoodgroveBank.ServiceLevelTracking
