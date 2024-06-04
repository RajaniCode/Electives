@REM
@REM File: DeployBPM.cmd
@REM
@REM Summary: Deploy the BizTalk solution components of the BPM scenario 
@REM
@REM --------------------------------------------------------------------
@REM This file is part of the Microsoft BizTalk Server 2006 SDK
@REM
@REM Copyright (c) Microsoft Corporation. All rights reserved.
@REM
@REM This source code is intended only as a supplement to Microsoft
@REM BizTalk Server 2006 release and/or on-line documentation. See these
@REM other materials for detailed information regarding Microsoft code samples.
@REM
@REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
@REM KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
@REM IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
@REM PARTICULAR PURPOSE.
@REM --------------------------------------------------------------------

@SETLOCAL

@CALL "%VS80COMNTOOLS%vsvars32.bat"

@REM
@REM DEPLOYMENT
@REM

@REM  Find the BizTalk install path ...
@REM
@set TMPSettingsFile=%TEMP%\__BTSPATH_PMDep.cmd
@pushd ..\..\common\StringUtils
@FindBTSInstallPath.wsf %TMPSettingsFile%
@popd
@REM - this should have generated the batch file with the set command to set the environment in it...
@call %TMPSettingsFile%

@REM - now the BizTalk install path should be in the BizTalkInstallPath environment variable...
@REM
@SET BTSDIR=%BizTalkInstallPath%
@SET SOLNDIR=%BizTalkInstallPath%\SDK\Scenarios\BPM
@SET SOLUTION_NAME=Microsoft.Samples.BizTalk.SouthridgeVideo.sln
@SET BPM_BUILD_TYPE=Debug

@REM The MGMT_DB_SERVER variable points to the local server (localhost) for a single server install. Need to change this
@REM for a multi-server install
@REM 
@SET MGMT_DB_SERVER=localhost
@SET MGMT_DB=BizTalkMgmtDb

@REM Binding Files
@REM
@SET MSG_TEST_BINDING=%SOLNDIR%\Bindings\MessagingAppBindings-test.xml
@SET BROKER_TEST_BINDING=%SOLNDIR%\Bindings\OrderBrokerAppBindings-test.xml
@SET CABLE_TEST_BINDING=%SOLNDIR%\Bindings\CableOrderAppBindings-test.xml
@SET MSG_BINDING=%SOLNDIR%\Bindings\MessagingAppBindings.xml
@SET BROKER_BINDING=%SOLNDIR%\Bindings\OrderBrokerAppBindings.xml
@SET CABLE_BINDING=%SOLNDIR%\Bindings\CableOrderAppBindings.xml

@REM Application Names
@REM
@SET MSG_APP_NAME="BTSScn.BPM.MessagingApp"
@SET BROKER_APP_NAME="BTSScn.BPM.OrderBrokerApp"
@SET CABLE_APP_NAME="BTSScn.BPM.CableOrderApp"

@REM - the assignment value needs to be in quotes (") in order to preserve the embedded blanks. Otherwise
@REM - the embedded blanks will become delimiters when the variable is used, causing unexpected results.
@REM
@SET MSG_APP_DESC="Messaging App configuration for BPM Scenario"
@SET BROKER_APP_DESC="Order Broker App configuration for BPM Scenario"
@SET CABLE_APP_DESC="Cable Order App configuration for BPM Scenario"

@SET MSG_TEST_APP_NAME="BTSScn.BPM.MessagingApp.Test"
@SET BROKER_TEST_APP_NAME="BTSScn.BPM.OrderBrokerApp.Test"
@SET CABLE_TEST_APP_NAME="BTSScn.BPM.CableOrderApp.Test"

@SET MSG_TEST_APP_DESC="Messaging App test bindings for BPM Scenario"
@SET BROKER_TEST_APP_DESC="Order Broker App test bindings for BPM Scenario"
@SET CABLE_TEST_APP_DESC="Cable Order App test bindings for BPM Scenario"


@REM Create the BizTalk applications...
@REM
btstask AddApp -ApplicationName:%MSG_APP_NAME% -Description:%MSG_APP_DESC%
btstask AddApp -ApplicationName:%BROKER_APP_NAME% -Description:%BROKER_APP_DESC%
btstask AddApp -ApplicationName:%CABLE_APP_NAME% -Description:%CABLE_APP_DESC%

@REM Create the BizTalk test applications...
@REM
btstask AddApp -ApplicationName:%MSG_TEST_APP_NAME% -Description:%MSG_TEST_APP_DESC%
btstask AddApp -ApplicationName:%BROKER_TEST_APP_NAME% -Description:%BROKER_TEST_APP_DESC%
btstask AddApp -ApplicationName:%CABLE_TEST_APP_NAME% -Description:%CABLE_TEST_APP_DESC%

REM Add the application references
@REM
.\CreateAppReferences.vbs

REM Deploy the scenario
@REM The BizTalk projects are configured to be deployed to particular applications
@REM Deploying this solution will create the MessagingApp, OrderBrokerApp, and OrderManagerApp applications
@REM
devenv ..\%SOLUTION_NAME% /Deploy "%BPM_BUILD_TYPE%|Mixed Platforms" /Out Deploy.log


REM Add the assemblies as a resource to the messaging application (GACs the assemblies)
@REM
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\SchemaClasses\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.dll
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\Utilities\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities.dll
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\ServiceLevelTracking\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.ServiceLevelTracking.dll

btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\OperationsClient\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.OperationsClient.dll
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\OperationsHandler\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.OperationsHandler.dll
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\IOperationsSystem\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.IOperationsSystem.dll

REM Add the assemblies as a resource to the cable order application
@REM
btstask AddResource -ApplicationName:%CABLE_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\CableProvisioningSystemClient\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystemClient.dll
btstask AddResource -ApplicationName:%CABLE_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\OrderHandler\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.OrderHandler.dll
btstask AddResource -ApplicationName:%CABLE_APP_NAME% -Type:Assembly -OverWrite -Options:GacOnAdd,GacOnInstall  -Source:%SOLNDIR%\IOrderHandler\bin\%BPM_BUILD_TYPE%\Microsoft.Samples.BizTalk.SouthridgeVideo.IOrderHandler.dll

REM Add the rules engine policy as a resources to the cable order application
@REM
btstask AddResource -ApplicationName:%CABLE_APP_NAME% -Type:Rules -Name:DecodeAndValidateOrder -Version:1.0

REM Bind the test applications
@REM
btstask ImportBindings -ApplicationName:%MSG_TEST_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%MSG_TEST_BINDING%
btstask ImportBindings -ApplicationName:%BROKER_TEST_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%BROKER_TEST_BINDING%
btstask ImportBindings -ApplicationName:%CABLE_TEST_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%CABLE_TEST_BINDING%

REM Bind the applications
@REM
btstask ImportBindings -ApplicationName:%MSG_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%MSG_BINDING%
btstask ImportBindings -ApplicationName:%BROKER_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%BROKER_BINDING%
btstask ImportBindings -ApplicationName:%CABLE_APP_NAME% -Server:%MGMT_DB_SERVER% -Database:%MGMT_DB% -Source:%CABLE_BINDING%

REM Deploy the BAM defintion file
@REM
%BTSDIR%\tracking\BM deploy-all -DefinitionFile:%SOLNDIR%\BAM\BAMServiceOrder.xls

REM Add the definition file as a BAM resource
@REM
btstask AddResource -ApplicationName:%MSG_APP_NAME% -Type:Bam -Overwrite -Source:%SOLNDIR%\BAM\BAMServiceOrder.xls

REM Create the SSO Application (once per group)
@REM
@CALL CreateSouthridgeVideoApplication.cmd


@REM Call the installer for the utilities (on each BTS machine hosting the BPM orchestrations)
REM This will register the SouthridgeVideo event source
@REM
installutil /logToConsole=false /logFile= ..\Utilities\bin\debug\Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities.dll

@REM Deploy the order broker orchestration web service proxy (on each web server)
@REM
@REM iisvdir /create "Default Web Site" BTSScn.BPM.OrderBroker_Proxy %SOLNDIR%\OrderBroker_Proxy

@REM An example of how to use the BizTalk web service publishing wizard
@REM BTSWebSvcPub.exe "Orchestrations\OrderBroker\bin\Development\Microsoft.Samples.BizTalk.SouthridgeVideo.OrderBroker.dll" -TargetNamespace:http://Microsoft.Samples.BizTalk.SouthridgeVideo/ -Namespace:Microsoft.Samples.BizTalk.SouthridgeVideo.WebServices -Location:http://localhost/BTSScnBPM.OrderBroker_Proxy -Name:OrderBroker_Proxy -Overwrite

REM Create test directories (on each file host)
@REM
@REM @CALL CreateTestDirectories.cmd

@REM - create the IIS virtual folders for CSR web application.
@REM
@REM iisvdir /create "Default Web Site" CSRWebApp %SOLNDIR%\CSRWebApp

@REM - create MSMQ queues (for MSMQ host and backend servers)
@REM
@REM .\CreateQueues.vbs

@ENDLOCAL