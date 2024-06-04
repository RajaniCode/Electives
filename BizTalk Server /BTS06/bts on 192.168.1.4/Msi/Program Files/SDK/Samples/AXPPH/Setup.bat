@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
@REM
@REM Sample: Arbitrary XPath Property Handler Pipeline Component SDK
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

@SET SolutionName=ArbitraryXPathPropertyHandler.sln

@ECHO.
@ECHO Building the pipeline component and copy it to the pipeline directory...

@DevEnv ArbitraryXPathPropertyHandler.sln /Build Debug /Out Build.log
@COPY bin\Debug\ArbitraryXPathPropertyHandler.dll "..\..\..\..\Pipeline Components\"


@pushd ArbitraryXPathSample

@ECHO.
@ECHO Building the sample application

@SeT SolutionName=ArbitraryXPathSample.sln
@SET AssemblyKeyFile=ArbitraryXPathSample.snk

@SET BindingFileName=ArbitraryXPathSampleBinding.xml

@SET SendPortName=ArbitraryXPathSampleSendPort
@SET ReceivePortName=ArbitraryXPathSampleReceivePort
@SET ReceiveLocationName=ArbitraryXPathSampleReceivePortLocation
@SET FileReceiveDirectory=Input
@SET FileReceiveLocation=\%FileReceiveDirectory%\*.xml
@SET FileSendDirectory=Output
@SET FileSendAddress=\%FileSendDirectory%\%%MessageID%%.xml
@SET OrchestrationName=ArbitraryXPathSample.CalculateTotalAmount
@SET AssemblyName=ArbitraryXPathSample

@ECHO.
@ECHO Creating the send and receive directories...

@IF NOT EXIST %FileReceiveDirectory% MD %FileReceiveDirectory%
@IF NOT EXIST %FileSendDirectory% MD %FileSendDirectory%

@ECHO.
@ECHO If key file is not found, will generate a new key file...

@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@REM ECHO.
@REM ECHO Building the project and deploying the sample assembly...

@DevEnv %SolutionName% /Deploy Development /Out Build.log

@REM ECHO.
@REM ECHO Creating and binding the ports...

@BTSTask ImportBindings -Source:%BindingFileName% -ApplicationName:ArbitraryXPathApplication > Binding.log


@ECHO.
@ECHO Calling the WMI script to start the send port...

@CScript /NoLogo "..\..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %SendPortName% %FileSendAddress%

@ECHO.
@ECHO Calling the WMI script to start the receive port...

@CScript /NoLogo "..\..\..\Admin\WMI\Enable Receive Location\VBScript\EnableRecLoc.vbs" %ReceivePortName% %ReceiveLocationName% %FileReceiveLocation%

@ECHO.
@ECHO Calling the WMI script to enlist and start the orchestration...

@CScript /NoLogo "..\..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" %OrchestrationName% %AssemblyName% Start

@popd

@ENDLOCAL

@PAUSE
