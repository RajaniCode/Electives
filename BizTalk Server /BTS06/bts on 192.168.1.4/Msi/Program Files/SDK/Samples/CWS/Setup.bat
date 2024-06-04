@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
@REM
@REM Sample: Consume Web Service
@REM
@REM --------------------------------------------------------------------
@REM This file is part of the Microsoft BizTalk Server 2006 SDK
@REM
@REM Copyright (c) Microsoft Corporation. All rights reserved.
@REM
@REM This source code is intended only as a supplement to Microsoft BizTalk
@REM Server 2006 release and/or on-line documentation. See these other
@REM materials for detailed information regarding Microsoft code samples.
@REM
@REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
@REM KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
@REM IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
@REM PURPOSE.
@REM --------------------------------------------------------------------

@SETLOCAL

@CALL "%VS80COMNTOOLS%vsvars32.bat"

@SET SolutionName=ConsumeWebService.sln
@SET AssemblyKeyFile=ConsumeWebService.snk
@SET BindingFileName=ConsumeWebServiceBinding.xml
@SET InvoiceSendPortName=consumeWebServiceInvoiceSP
@SET POSendPortName=consumeWebServicePOSP
@SET ReceivePortName=consumeWebServiceRP
@SET ReceiveLocationName=consumeWebServiceRL
@SET FileReceiveDirectory=In
@SET FileReceiveLocation=\%FileReceiveDirectory%\*.xml
@SET FileSendDirectory=Out
@SET FileSendAddress=\%FileSendDirectory%\%%MessageID%%.xml
@SET OrchestrationName=Microsoft.Samples.BizTalk.ConsumeWebService.ReceivePOandSubmitToWS
@SET AssemblyName=ConsumeWebService
@SET VirtualDirectoryName=POWebService
@SET VirtualDirectoryPath=\POWebService

@ECHO.
@ECHO Creating the send and receive directory...

@IF NOT EXIST %FileReceiveDirectory% MD %FileReceiveDirectory%
@IF NOT EXIST %FileSendDirectory% MD %FileSendDirectory%

@ECHO.
@ECHO Configuring the IIS vRoot...

@CScript /NoLogo ..\..\ConfigureIIS.vbs %VirtualDirectoryName% %VirtualDirectoryPath%

@ECHO.
@ECHO If key file is not found, will generate a new key file...

@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@ECHO.
@ECHO Building the sample Web Service...

@DevEnv POWebService\POWebService.sln /Build Debug /Out Build.log

@ECHO.
@ECHO Building the project and deploying the sample assembly...

@DevEnv %SolutionName% /Deploy Development /Out Build.log

@REM ECHO.
@REM ECHO Creating and binding the ports...

@BTSTask ImportBindings -Source:%BindingFileName% > Binding.log

@ECHO.
@ECHO Calling the WMI script to start the send ports...

@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %InvoiceSendPortName% %FileSendAddress%
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %POSendPortName%

@ECHO.
@ECHO Calling the WMI script to enable the receive location...

@CScript /NoLogo "..\..\Admin\WMI\Enable Receive Location\VBScript\EnableRecLoc.vbs" %ReceivePortName% %ReceiveLocationName% %FileReceiveLocation%

@ECHO.
@ECHO Calling the WMI script to enlist and start the orchestration...

@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" %OrchestrationName% %AssemblyName% Start

@ENDLOCAL

@PAUSE