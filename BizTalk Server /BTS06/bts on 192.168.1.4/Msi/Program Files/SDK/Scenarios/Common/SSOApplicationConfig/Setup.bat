@REM
@REM File: Setup.bat
@REM
@REM Summary: Build the SSOApplicationConfig that is common to the scenarios.
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

@SET SOLUTION_NAME=SSOApplicationConfig.sln
@SET SOLUTION_KEY_FILE=SSOApplicationConfig.snk

@ECHO.

@IF NOT EXIST %SOLUTION_KEY_FILE% (sn -k %SOLUTION_KEY_FILE%)

@ECHO.

@ECHO.
@ECHO Building the project and deploying the sample assembly...

devenv %SOLUTION_NAME% /Build "Debug|AnyCPU" /Out Build.log

@ENDLOCAL

@PAUSE
