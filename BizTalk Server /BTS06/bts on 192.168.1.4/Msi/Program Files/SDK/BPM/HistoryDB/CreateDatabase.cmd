@REM
@REM File: CreateDatabase.cmd
@REM
@REM Summary: Create the SouthridgeVideo History database of the BPM scenario 
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

@REM This will allow the user the ability to run this locally and change the Servername from Local to any servername\instance.

@REM For instance if the Server was not on the same machine and was on a machine named PROD1 
@REM and it was running on an instance named SQL2005Instance 
@REM you can change the SQLSERVERNAME parameter to: @SET SQLSERVERNAME= PROD1\SQL2005Instance


@SET SQLSERVERNAME=(Local)
osql -E -S %SQLSERVERNAME% -i ..\HistoryDB\SouthridgeVideoHistory.sql -o HISTORYDBREsults.TXT -n 

