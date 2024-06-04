@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
@REM
@REM Sample: Envelope Processing
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

@SET SolutionName=EnvelopeProcessing.sln
@SET AssemblyKeyFile=EnvelopeProcessing.snk
@SET BindingFileName=EnvelopeProcessingBinding.xml
@SET SendPortName=EnvelopeProcessing_SP
@SET ReceivePortName=EnvelopeProcessing_RP
@SET ReceiveLocationName=EnvelopeProcessing_RL
@SET FileReceiveDirectory=EnvInput
@SET FileReceiveLocation=\%FileReceiveDirectory%\*.txt
@SET FileSendDirectory=EnvOutput
@SET FileSendAddress=\%FileSendDirectory%\%%MessageID%%.xml

@ECHO.
@ECHO Creating the send and receive directory...

@IF NOT EXIST %FileReceiveDirectory% MD %FileReceiveDirectory%
@IF NOT EXIST %FileSendDirectory% MD %FileSendDirectory%

@ECHO.
@ECHO If key file is not found, will generate a new key file...

@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%

@ECHO.
@ECHO Building the project and deploying the sample assembly...

@DevEnv %SolutionName% /Deploy Development /Out Build.log

@ECHO.
@ECHO Creating and binding the ports...

@BTSTask ImportBindings -Source:%BindingFileName% -ApplicationName:EnvelopeProcessingApplication > Binding.log

@ECHO.
@ECHO Calling the WMI script to start the send port...

@CScript /NoLogo "..\..\..\Admin\WMI\Start Send Port\VBScript\StartSendPort.vbs" %SendPortName% %FileSendAddress%

@ECHO.
@ECHO Calling the WMI script to enable the receive location...

@CScript /NoLogo "..\..\..\Admin\WMI\Enable Receive Location\VBScript\EnableRecLoc.vbs" %ReceivePortName% %ReceiveLocationName% %FileReceiveLocation%

@ENDLOCAL

@PAUSE