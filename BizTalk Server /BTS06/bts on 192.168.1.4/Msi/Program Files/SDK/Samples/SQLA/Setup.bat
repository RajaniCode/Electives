@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
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

@ECHO Creating Databases...
@osql -S localhost -E -i Create_Database.sql
@osql -S localhost -E -d BTS2004_SQL_Adapter_Loans -i Create_Tables.sql
@osql -S localhost -E -d BTS2004_SQL_Adapter_Loans -i Create_SPROCs.sql
@osql -S localhost -E -d BTS2004_SQL_Adapter_Loans -i Populate_Tables.sql

@SETLOCAL

@CALL "%VS80COMNTOOLS%vsvars32.bat"

@SET SolutionName="SQL Adapter Sample.sln"
@SET AssemblyKeyFile=Key.snk
@SET FileReceiveDirectory=\Input_Folder
@SET FileSendDirectory=\Result_Folder

@ECHO.
@ECHO Creating the send and receive directories...
@IF NOT EXIST ."%FileReceiveDirectory%" MD ."%FileReceiveDirectory%"
@IF NOT EXIST ."%FileSendDirectory%" MD ."%FileSendDirectory%"

@ECHO.
@ECHO If key file is not found, will generate a new key file...
@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@ECHO.
@ECHO Building the project and deploying the sample assembly...
@DevEnv %SolutionName% /Deploy Development /Out Build.log

@ECHO.
@ECHO Creating and binding the ports...
@BTSTask ImportBindings -Source:Agent_Report_Binding.xml -ApplicationName:SQLAdapterApplication > Binding.log
@BTSTask ImportBindings -Source:Loan_Acceptance_Binding.xml -ApplicationName:SQLAdapterApplication > Binding.log
@BTSTask ImportBindings -Source:New_Customer_Binding.xml -ApplicationName:SQLAdapterApplication > Binding.log
@BTSTask ImportBindings -Source:Loan_Assignment_Binding.xml -ApplicationName:SQLAdapterApplication > Binding.log

@ECHO.
@ECHO Calling the WMI script to adjust and start the send ports...
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" "Agent_Report_Save_port" "%FileSendDirectory%\Agent_Report.xml"
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" "Loan_Acceptance_Result_port" "%FileSendDirectory%\Accepted_Loan_%%MessageID%%.xml"
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" "New_Customer_Processing_Result_port" "%FileSendDirectory%\New_Customer_%%MessageID%%.xml"
@CScript /NoLogo "..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" "Loan_Assignment_Result_port" "%FileSendDirectory%\Assigned_loan_%%MessageID%%.xml"

@ECHO.
@ECHO Calling the WMI script to adjust and enable the receive location...
@CScript /NoLogo "..\..\Admin\WMI\Enable Receive Location\VBScript\EnableRecLoc.vbs" "Loan_Acceptance_Input_port" "Loan Receiver" "%FileReceiveDirectory%\*.xml"
@CScript /NoLogo "..\..\Admin\WMI\Enable Receive Location\VBScript\EnableRecLoc.vbs" "Agent_Report_port" "Report Receiver"

@ECHO.
@ECHO Calling the WMI script to enlist and start the orchestrations...
@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" "Loan_Acceptance.Orchestration_1" "Loan Acceptance" Start
@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" "New_Customer_Processing.Orchestration_1" "New Customer Processing" Start
@CScript /NoLogo "..\..\Admin\WMI\Enlist Orchestration\VBScript\EnlistOrch.vbs" "Loan_Assignment.Orchestration_1" "Loan Assignment" Start

@ENDLOCAL

@PAUSE