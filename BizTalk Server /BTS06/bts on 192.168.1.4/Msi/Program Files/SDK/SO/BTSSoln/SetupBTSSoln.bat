@REM
@REM
@REM Summary: Build the Biztalk solution components of the SOA scenario 
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

@SET SOLUTION_NAME=Microsoft.Samples.BizTalk.WoodgroveBank.sln
@SET SOLUTION_KEY_FILE=Microsoft.Samples.BizTalk.WoodgroveBank.snk

@ECHO.

@IF NOT EXIST %SOLUTION_KEY_FILE% (sn -k %SOLUTION_KEY_FILE%)

@REM Extract the public key token from the key file generated so we can replace the pk tokens in the set 
@REM of files with the new PK token.
@REM

@SET TEMP_PK=%TEMP%\__TPK
@SET TEMP_TOKEN=%TEMP%\__TPK_TOKEN
sn -p %SOLUTION_KEY_FILE%  %TEMP_PK%
sn -t %TEMP_PK% >%TEMP_TOKEN%

@REM
@REM Replace the public key tokens with the new token corresponding to the key generated
@REM

cscript ReplacePKToken.wsf %TEMP_TOKEN%

@ECHO.
@ECHO Building the project...

devenv %SOLUTION_NAME% /Build "Debug|Mixed Platforms" /Out Build.log

@REM Build SSOApplicationConfig utility
@REM
@PUSHD ..\..\common\SSOApplicationConfig
@CALL Setup.bat
@POPD

REM - need to add scripts here to create the IIS virtual folders for the proxy directories.

@ENDLOCAL

@PAUSE
