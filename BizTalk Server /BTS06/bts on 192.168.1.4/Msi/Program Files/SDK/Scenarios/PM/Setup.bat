@REM --------------------------------------------------------------------
@REM File: Setup.bat
@REM
@REM Summary: Sets up the solution with the right keys and compiles the
@REM solution, ready for deployment
@REM
@REM Sample: End To End Pure Messaging
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

REM  Find the BizTalk install path ...
set TMPFile=%TEMP%\__BTSPATH_PM.cmd

pushd ..\common\StringUtils
cscript FindBTSInstallPath.wsf %TMPFile%
popd

REM - this should have generated the batch file with the set command to set the environment in it...
call %TMPFile%

REM now the BizTalk install path should be in the BizTalkInstallPath environment variable...

@SET SolutionName=Microsoft.Samples.BizTalk.WingtipToys.sln

@SET StrongNameKey=Microsoft.Samples.BizTalk.WingtipToys.snk

@ECHO.
@ECHO If key file is not found, will generate a new key file...
@IF NOT EXIST %StrongNameKey% sn -k %StrongNameKey%

@REM Extract the public key token from the key file generated so we can replace the pk tokens in the set 
@REM of files with the new PK token.
@REM

@SET TEMP_PK=%TEMP%\__TPK
@SET TEMP_TOKEN=%TEMP%\__TPK_TOKEN
sn -p %StrongNameKey% %TEMP_PK%
sn -t %TEMP_PK% >%TEMP_TOKEN%

@REM
@REM Replace the public key tokens with the new token corresponding to the key generated
@REM Replce the base directory token in the binding files with the real directory names...
@REM

@REM All receive locations and send ports are created in the FileDrop under the scenario install directory.
SET BaseDirForReceiveSend=%BizTalkInstallPath%\FileDrop

cscript .\ReplaceTokens.wsf %TEMP_TOKEN% %BaseDirForReceiveSend%

@ECHO.
@ECHO Building the solution 
@ECHO If there are errors, please check to make sure the reference
@ECHO to Microsoft.BizTalk.Pipeline.Components is correct

@ECHO .

@DevEnv %SolutionName% /build  "Development|Any CPU" /out Build.log

@ECHO .

echo "Solution compiled. Use Deploy and Undeploy scripts to deploy/undeploy the application"

@ENDLOCAL

@PAUSE
