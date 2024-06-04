REM ---------------------------------------------------------------------------------
REM  Microsoft.Samples.BizTalk.WoodgroveBank
REM  
REM  Command file to deploy the stub version of the orchestration
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

SET STUB_ORCH_BINDING=%SOLNDIR%\Bindings\StubSOAOrchBindings.xml

SET BTS_APP_NAME="BTSScn.SO.CustomerService"
SET BTS_APP_DESC="End to End Scenarios - Service Oriented Scenario Sample"

REM - Create the BizTalk application...
btstask AddApp -ApplicationName:%BTS_APP_NAME% -Description:%BTS_APP_DESC% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB%

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:Assembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\ConfigHelper\bin\Debug\Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:Assembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\SchemaClasses\bin\Debug\Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:Assembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\ServiceLevelTracking\bin\Debug\Microsoft.Samples.BizTalk.WoodgroveBank.ServiceLevelTracking.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:Assembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\ErrorHelper\bin\Debug\Microsoft.Samples.BizTalk.WoodgroveBank.ErrorHelper.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:Assembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\Utilities\bin\Debug\Microsoft.Samples.BizTalk.WoodgroveBank.Utilities.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:System.BizTalk:BiztalkAssembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall -Source:%SOLNDIR%\Schemas\bin\Development\Microsoft.Samples.BizTalk.WoodgroveBank.Schemas.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:System.BizTalk:BiztalkAssembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall -Source:%SOLNDIR%\Maps\bin\Development\Microsoft.Samples.BizTalk.WoodgroveBank.Maps.dll

btstask AddResource -ApplicationName:%BTS_APP_NAME% -Type:System.BizTalk:BiztalkAssembly -OverWrite -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Options:GacOnAdd,GacOnInstall -Source:%SOLNDIR%\Orchestrations\Stub\bin\Development\Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed.dll 

btstask ImportBindings -ApplicationName:%BTS_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%STUB_ORCH_BINDING%

