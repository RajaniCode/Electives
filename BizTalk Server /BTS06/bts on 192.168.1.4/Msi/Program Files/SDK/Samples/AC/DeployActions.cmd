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

@SET AssemblyKeyFile=Actions.snk
@SET UtilObjectsProjectName=UtilObjects\UtilObjects.csproj
@SET AssignSolutionName=Assign\Assign.sln
@SET DelegateSolutionName=Delegate\Delegate.sln
@SET SendPortName=SendTaskMessageStaticPort
@SET ResponseSendPortName=SendTaskResponseMessagePort
@SET FileSendDirectory=TaskMessage
@SET FileSendAddress=\%FileSendDirectory%\%%MessageID%%.xml
@SET AssignOrchestrationName=Microsoft.Samples.BizTalk.Actions.Assign
@SET AssignAssemblyName=AssignTask
@SET DelegateOrchestrationName=Microsoft.Samples.BizTalk.Actions.Delegate
@SET DelegateAssemblyName=DelegateTask

@ECHO.
@ECHO Creating the send directory...

@IF NOT EXIST %FileSendDirectory% MD %FileSendDirectory%

@ECHO.
@ECHO If key file is not found, will generate a new key file...

@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@ECHO.
@ECHO Building the Solutions...

@DevEnv %UtilObjectsProjectName% /Build "Release|AnyCPU" /Out UtilObjectsBuild.log
@DevEnv %AssignSolutionName% /Build "Release|AnyCPU" /Out AssignSolutionBuild.log
@DevEnv %DelegateSolutionName% /Build "Release|AnyCPU" /Out DelegateSolutionBuild.log

@ECHO.
@ECHO GAC the Assemblies...

@Gacutil /i "..\..\..\..\Developer Tools\BizTalkWizards\ActionApp\Templates\bin\Microsoft.BizTalk.Hws.TemplateExceptions.dll" /f
@Gacutil /i ".\UtilObjects\UtilObjects.dll" /f

@ECHO Deploy the Assemblies...
@BTSDeploy DEPLOY Assembly=BaseSchema\BaseSchema.dll Install=True Log=BaseSchemaLog
@BTSDeploy DEPLOY Assembly=Assign\obj\Deployment\AssignTask.dll Binding=AssignBinding.xml Install=True Log=AssignTaskActionLog
@BTSDeploy DEPLOY Assembly=Delegate\obj\Deployment\DelegateTask.dll Binding=DelegateBinding.xml Install=True Log=DelegateTaskActionLog

@ECHO.
@ECHO Calling the WMI script to start the send ports...

@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %SendPortName% %FileSendAddress%
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %ResponseSendPortName%

@ECHO.
@ECHO Calling the WMI script to enlist and start the orchestrations...

@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" %AssignOrchestrationName% %AssignAssemblyName% Start
@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" %DelegateOrchestrationName% %DelegateAssemblyName% Start

@ENDLOCAL

@PAUSE
