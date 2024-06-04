@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
@REM
@REM Sample: Expose Web Service
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

@SET SolutionName=ExposeWebService.sln
@SET AssemblyKeyFile=ExposeWebService.snk
@SET BindingFileName=ExposeWebServiceBinding.xml
@SET OrchestrationName=Microsoft.Samples.BizTalk.ExposeWebService.ProcessClientRequest
@SET AssemblyName=ExposeWebService
@SET VirtualDirectoryName=ExposeWebServiceDriver
@SET VirtualDirectoryPath=\ExposeWebServiceDriver

@ECHO.
@ECHO Configuring the IIS vRoot...

@CScript /NoLogo ..\..\ConfigureIIS.vbs %VirtualDirectoryName% %VirtualDirectoryPath%

@ECHO.
@ECHO If key file is not found, will generate a new key file...

@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@REM Since the Web Service Publishing Wizard gives large names to these files, they
@REM must be renamed to fit onto CDFS. We are know changing them back to their
@REM correct names.
@IF EXIST "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.disco" (
	@RENAME "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.disco" Microsoft_Samples_BizTalk_ExposeWebService_ProcessClientRequest_SOAPPort.disco
)
@IF EXIST "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.discomap" (
	@RENAME "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.discomap" Microsoft_Samples_BizTalk_ExposeWebService_ProcessClientRequest_SOAPPort.discomap
)
@IF EXIST "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.wsdl" (
	@RENAME "ExposeWebServiceDriver\App_WebReferences\localhost\EWS_PCR_SOAPP.wsdl" Microsoft_Samples_BizTalk_ExposeWebService_ProcessClientRequest_SOAPPort.wsdl
)

@ECHO.
@ECHO Building the Web Service driver...

@DevEnv ExposeWebServiceDriver\ExposeWebServiceDriver.sln /Build Debug /Out Build.log

@ECHO.
@ECHO Building the project and deploying the sample assembly...

@DevEnv %SolutionName% /Deploy Development /Out Build.log

@ECHO.
@ECHO Creating and binding the ports...

@BTSTask ImportBindings -Source:%BindingFileName% > Binding.log


@ECHO.
@ECHO Calling the WMI script to enlist and start the orchestration...

@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" %OrchestrationName% %AssemblyName% Start

@ENDLOCAL

@PAUSE