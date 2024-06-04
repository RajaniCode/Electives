@REM --------------------------------------------------------------------
@REM File: Cleanup.bat
@REM
@REM Summary: Calls scripts and programs to stop and undeploy the sample.
@REM
@REM Sample: Hello World
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

@ECHO.
@ECHO Calling the WMI script to stop and unenlist the orchestrations...

@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" "Loan_Assignment.Orchestration_1" "Loan Assignment" Unenlist
@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" "New_Customer_Processing.Orchestration_1" "New Customer Processing" Unenlist
@CScript /NoLogo "..\..\Admin\WMI\Stop Orchestration\VBScript\StopOrch.vbs" "Loan_Acceptance.Orchestration_1" "Loan Acceptance" Unenlist


@ECHO.
@ECHO Calling the WMI script to remove the send ports...

@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Agent_Report_Save_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Loan_Acceptance_Result_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "New_Customer_Processing_Result_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Loan_Assignment_Result_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Loan_Assignment_SPROC_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Loan_Assignment_Updategram_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "Loan_Acceptance_SPROC_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "New_Customer_SPROC_port" UnenlistOnly
@CScript /NoLogo "..\..\Admin\WMI\Remove Send Port\VBScript\RemoveSendPort.vbs" "New_Customer_Processing_Updategram_port" UnenlistOnly

@ECHO.
@ECHO Undeploying the assemblies and removing sample application ...

@BTSTask RemoveApp -ApplicationName:SQLAdapterApplication > Undeploy.log


@ENDLOCAL

@PAUSE