@REM
@REM File: SetupMFAccess.bat
@REM
@REM Summary: Build the Mainframe Access solution components of the SOA scenario 
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

REM  need to make sure this is built with Visual Studio 2003, .net 1.1

@CALL "%VS71COMNTOOLS%vsvars32.bat"

@SET SolutionName=Microsoft.Samples.BizTalk.WoodgroveBank.MainframeAccess.sln
@SET SolutionKeyFile=Microsoft.Samples.BizTalk.WoodgroveBank.MainframeAccess.snk

@ECHO.

@IF NOT EXIST %SolutionKeyFile% sn -k %SolutionKeyFile%

@ECHO.
@ECHO Building the project...

@DevEnv %SolutionName% /build Debug /Out Build.log


@ENDLOCAL

@PAUSE
