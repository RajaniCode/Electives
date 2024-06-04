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

@SET AssemblyKeyFile=ADAdapterKey.snk
@SET ADRetrieverSolutionName=AdAdapter.sln

@ECHO.
@ECHO.
@ECHO If key file is not found, will generate a new key file...
@IF NOT EXIST %AssemblyKeyFile% sn -k %AssemblyKeyFile%
@ECHO.
@ECHO Building the Solutions...
@DevEnv %ADRetrieverSolutionName% /Build Release /Out Build.log

@ECHO.
@ECHO GAC the Assemblies...

@Gacutil /i "bin\Release\ADAdapter.dll" /f

@ENDLOCAL

@PAUSE
