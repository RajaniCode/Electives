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

@SET AssignOrchestrationName=Microsoft.Samples.BizTalk.Actions.Assign
@SET AssignAssemblyName=AssignTask
@SET DelegateOrchestrationName=Microsoft.Samples.BizTalk.Actions.Delegate
@SET DelegateAssemblyName=DelegateTask
@SET SendPortName=SendTaskMessageStaticPort
@SET ResponseSendPortName=SendTaskResponseMessagePort
@SET IntReceivePortName=ActionInterruptPort
@SET ActReceivePortName=ActionActivationPort

@ECHO.
@ECHO Calling the WMI script to stop and unenlist the orchestrations...

@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" %AssignOrchestrationName% %AssignAssemblyName% Unenlist
@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" %DelegateOrchestrationName% %DelegateAssemblyName% Unenlist

@ECHO.
@ECHO Undeploying the assembly...

@BTSDeploy Remove Assembly=Assign\obj\Deployment\AssignTask.dll Uninstall=True Log=Undeploy
@BTSDeploy Remove Assembly=Delegate\obj\Deployment\DelegateTask.dll Uninstall=True Log=Undeploy
@BTSDeploy Remove Assembly=BaseSchema\BaseSchema.dll Uninstall=True Log=Undeploy

@ECHO.
@ECHO Removing the assemblies from the GAC...
@GacUtil /u UtilObjects

@ECHO.
@ECHO Calling the WMI script to remove the send ports...

@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" %SendPortName%
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" %ResponseSendPortName%

@ECHO.
@ECHO Calling the WMI script to remove the receive ports...

@CScript /NoLogo "..\..\Admin\WMI\Remove Receive Port\VBScript\RemoveReceivePort.vbs" %IntReceivePortName%
@CScript /NoLogo "..\..\Admin\WMI\Remove Receive Port\VBScript\RemoveReceivePort.vbs" %ActReceivePortName%

@ENDLOCAL

@PAUSE
