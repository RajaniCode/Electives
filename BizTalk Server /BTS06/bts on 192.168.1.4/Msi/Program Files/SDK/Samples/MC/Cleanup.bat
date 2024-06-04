@REM --------------------------------------------------------------------
@REM File: Cleanup.bat
@REM
@REM Summary: Calls scripts and programs to stop and undeploy the sample.
@REM
@REM Sample: Method Call
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

@SET OrchestrationName=Microsoft.Samples.BizTalk.MethodCallSample.MethodCallService
@SET AssemblyName=MethodCallSample
@SET SendPortName=MethodCallSendPort
@SET ReceivePortName=MethodCallReceivePort

@ECHO.
@ECHO Calling the WMI script to stop and unenlist the orchestration...

@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" %OrchestrationName% %AssemblyName% Unenlist

@ECHO.
@ECHO Undeploying the assembly...

@BTSDeploy Remove Assembly=MethodCallSample\bin\Development\%AssemblyName%.dll Uninstall=True Log=Undeploy

@ECHO.
@ECHO We need to remove the .NET assembly from the GAC...
@GacUtil /u MathLibrary

@ECHO.
@ECHO Calling the WMI script to remove the send port...

@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" %SendPortName%

@ECHO.
@ECHO Calling the WMI script to remove the receive port...

@CScript /NoLogo "..\..\Admin\WMI\Remove Receive Port\VBScript\RemoveReceivePort.vbs" %ReceivePortName%

@ENDLOCAL

@PAUSE