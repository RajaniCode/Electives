@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Calls scripts and programs to build, deploy, and start the sample.
@REM
@REM Sample: End To End Litware scenario
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

@SET SolutionName=Microsoft.Samples.BizTalk.Litware.sln
@SET SolutionKeyFile=Microsoft.Samples.BizTalk.Litware.snk

@ECHO.

@IF NOT EXIST %SolutionKeyFile% sn -k %SolutionKeyFile%

@REM Extract the public key token from the key file generated so we can replace the pk tokens in the set 
@REM of files with the new PK token.
@REM

@SET TEMP_PK=%TEMP%\__TPKB2B
@SET TEMP_TOKEN=%TEMP%\__TPK_TOKENB2B
sn -p Microsoft.Samples.BizTalk.Litware.snk %TEMP_PK%
sn -t %TEMP_PK% >%TEMP_TOKEN%

@REM
@REM Replace the public key tokens with the new token corresponding to the key generated
@REM

cscript ./ReplacePKToken.wsf %TEMP_TOKEN%

@ECHO.
@ECHO Building the project and deploying the assembly...
@ECHO Manually build the solution using VS.NET as mentioned in documentation if it fails to build.

devenv %SolutionName% /Build "Debug|Mixed Platforms" /Out Build.log

@REM Build SSOApplicationConfig utility
@REM
@PUSHD ..\common\SSOApplicationConfig
@CALL Setup.bat
@POPD

@ENDLOCAL

@PAUSE

