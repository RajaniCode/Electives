@REM --------------------------------------------------------------------
@REM File: Undeploy.bat
@REM
@REM Summary: Undeploy the Pure Messaging solution.
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

REM  Find the BizTalk install path ...
set TMPFile=%TEMP%\__BTSPATH_PMDep.cmd

pushd ..\..\common\StringUtils
cscript FindBTSInstallPath.wsf %TMPFile%
popd

REM - this should have generated the batch file with the set command to set the environment in it...
REM
call %TMPFile%

REM now the BizTalk install path should be in the BizTalkInstallPath environment variable...

@SET SendPortName1=PMSendPort_Compressed
@SET SendPortName2=PMSendPort_Normal
@SET ReceivePortName1=PMReceivePort_Normal
@SET ReceivePortName2=PMReceivePort_Compressed
@SET ReceiveLocationName1=PMReceiveLocation_Normal
@SET ReceiveLocationName2=PMReceiveLocation_Compressed

@PUSHD ..\Filedrop\
@SET FilePath=%CD%\
@POPD

SET BTSAppName="BTSScn.PM.CompresssionPipelines"

SET MgmtDbServer=localhost
SET MgmtDb=BizTalkMgmtDb

@ECHO .
@ECHO Removing Pure Messaging Send Ports
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Remove Send Port"\VBScript\RemoveSendPort.vbs %SendPortName1%
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Remove Send Port"\VBScript\RemoveSendPort.vbs %SendPortName2%

@ECHO .
@ECHO Removing Pure Messaging Receive Ports
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Remove Receive Port"\VBScript\RemoveReceivePort.vbs %ReceivePortName1%
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Remove Receive Port"\VBScript\RemoveReceivePort.vbs %ReceivePortName2%

@ECHO .
@ECHO Removing Pure Messaging Pipeline Assembly from database

btstask RemoveResource -ApplicationName:%BtsAppName% -Server:%MgmtDbServer% -Database:%MgmtDb% -Luid:"Microsoft.Samples.BizTalk.WingtipToys.PMPipelines, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7c613da897e0d8e7"

btstask RemoveResource -ApplicationName:%BtsAppName% -Server:%MgmtDbServer% -Database:%MgmtDb% -Luid:"Microsoft.Samples.BizTalk.WingtipToys.PMComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7c613da897e0d8e7"

btstask RemoveApp -ApplicationName:%BtsAppName%

@ECHO .
@ECHO Removing Custom Pipeline Components from BizTalk
@gacutil /uf Microsoft.Samples.BizTalk.WingtipToys.PMPipelines
@gacutil /uf Microsoft.Samples.BizTalk.WingtipToys.PMComponents

@ECHO .
@ECHO Removing Build and Binding log files

@ECHO .
@ECHO Removing Filedrop locations
@RD /s /q "%FilePath%"

@ECHO .

@ENDLOCAL

@PAUSE
