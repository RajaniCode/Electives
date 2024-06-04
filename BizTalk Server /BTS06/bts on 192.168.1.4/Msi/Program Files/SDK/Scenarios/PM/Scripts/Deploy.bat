@REM --------------------------------------------------------------------
@REM File: Deploy.bat
@REM
@REM Summary: Deploy the Pure messaging solution components.
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
set TMPFile=%TEMP%\__BTSPATH_PMDep.cmd

pushd ..\..\common\StringUtils
cscript FindBTSInstallPath.wsf %TMPFile%
popd

REM - this should have generated the batch file with the set command to set the environment in it...
call %TMPFile%

REM now the BizTalk install path should be in the BizTalkInstallPath environment variable...

@SET SolutionDirectory=%BizTalkInstallPath%\SDK\Scenarios\PM
@SET BindingFileName=%SolutionDirectory%\Bindings\PMBinding.xml

@SET SendPortName1=PMSendPort_Compressed
@SET SendPortName2=PMSendPort_Normal
@SET ReceivePortName1=PMReceivePort_Normal
@SET ReceivePortName2=PMReceivePort_Compressed
@SET ReceiveLocationName1=PMReceiveLocation_Normal
@SET ReceiveLocationName2=PMReceiveLocation_Compressed

@SET ComponentAssembly=Microsoft.Samples.BizTalk.WingtipToys.PMComponents.dll
@SET PipelineAssembly=Microsoft.Samples.BizTalk.WingtipToys.PMPipelines.dll

@IF NOT EXIST ..\FileDrop mkdir ..\Filedrop

@PUSHD ..\Filedrop\
@SET FilePath=%CD%\
@POPD

@SET FileReceiveLocation1=%FilePath%ReceiveNormal
@SET FileReceiveLocation2=%FilePath%ReceiveCompressed
@SET FileSendLocation1=%FilePath%SendCompressed
@SET FileSendLocation2=%FilePath%SendNormal

SET BTSAppName="BTSScn.PM.CompresssionPipelines"
SET BTSAppDesc="End to End Scenarios - Pure Messaging Scenario Sample"

SET MgmtDbServer=localhost
SET MgmtDb=BizTalkMgmtDb

REM Create the BizTalk application
btstask AddApp -ApplicationName:%BtsAppName% -Description:%BtsAppDesc% -Server:%MgmtDbServer% -Database:%MgmtDb%

REM add the pipelines and components assemblies as resources...
btstask AddResource -ApplicationName:%BtsAppName% -Type:Assembly -OverWrite -Server:%MgmtDbServer% -Database:%MgmtDb% -Options:GacOnAdd  -Source:%SolutionDirectory%\PMComponents\bin\Debug\%ComponentAssembly%

btstask AddResource -ApplicationName:%BtsAppName% -Type:BizTalkAssembly -OverWrite -Server:%MgmtDbServer% -Database:%MgmtDb% -Options:GacOnAdd  -Source:%SolutionDirectory%\PMPipelines\bin\Development\%PipelineAssembly%

@ECHO.
@ECHO Creating and binding the ports...
@IF NOT EXIST "%FileReceiveLocation1%"  mkdir "%FileReceiveLocation1%"
@IF NOT EXIST "%FileReceiveLocation2%"  mkdir "%FileReceiveLocation2%"
@IF NOT EXIST "%FileSendLocation1%"     mkdir "%FileSendLocation1%"
@IF NOT EXIST "%FileSendLocation2%"     mkdir "%FileSendLocation2%"

REM import the bindings
btstask ImportBindings -ApplicationName:%BtsAppName% -Server:%MgmtDbServer% -Database:%MgmtDb% -Source:%BindingFileName%

@REM The WMI scripts work off of current directory
@REM so we move to the Filedrop folder

@ECHO.
@ECHO Calling the WMI script to enable the receive locations...
@PUSHD "%FileReceiveLocation1%"
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Enable Receive Location"\VBScript\EnableRecLoc.vbs "%ReceivePortName1%" "%ReceiveLocationName1%" "\*.*"
@POPD
@PUSHD "%FileReceiveLocation2%"
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Enable Receive Location"\VBScript\EnableRecLoc.vbs "%ReceivePortName2%" "%ReceiveLocationName2%" "\*.gz"
@POPD

@ECHO.
@ECHO Calling the WMI script to start the send ports...
@PUSHD "%FileSendLocation1%"
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Start Send Port"\VBScript\StartSendPort.vbs "%SendPortName1%" "\%%MessageID%%.gz"
@POPD
@PUSHD "%FileSendLocation2%"
@CScript /NoLogo %BizTalkInstallPath%\SDK\Samples\Admin\WMI\"Start Send Port"\VBScript\StartSendPort.vbs "%SendPortName2%" "\%%MessageID%%"
@POPD

@ECHO.

@ENDLOCAL

@PAUSE
