@if "%_echo%"=="" echo off

@rem
@rem Manage BizTalk Adapter for MQSeries Release Bits Tracing
@rem

echo MQSTrace - Manage BizTalk Adapter for MQSeries Bits Tracing.

@rem
@rem Jump to where we handle usage
@rem 
if /I "%1" == "help" goto Usage
if /I "%1" == "-help" goto Usage
if /I "%1" == "/help" goto Usage
if /I "%1" == "-h" goto Usage
if /I "%1" == "/h" goto Usage
if /I "%1" == "-?" goto Usage
if /I "%1" == "/?" goto Usage

@rem
@rem Set Tools environment variable
@rem
if /I %1. == -tools. shift&goto SetToolsPath
if /I %1. == /tools. shift&goto SetToolsPath
goto EndSetToolsPath
:SetToolsPath
if /I not "%~1" == "" goto :DoSetToolPath
echo ERROR: Argument '-tools' specified without argument for Trace Tools folder.
echo Usage example: MQSTrace -tools "C:\Program Files\Common Files\BizTalk Adapter Trace Utility"
goto :eof
:DoSetToolPath
if not exist %1\tracelog.exe goto ToolsNotFound
if not exist %1\tracefmt.exe goto ToolsNotFound
echo Setting TRACE_TOOL_SEARCH_PATH to %1
set TRACE_TOOL_SEARCH_PATH=%~1&shift
goto :eof
:ToolsNotFound
echo ERROR: Could not find trace tools in folder %1
goto :eof
:EndSetToolsPath

@rem
@rem Set TraceFormat environment variable
@rem
if /I "%1" == "-path" shift&goto SetPath
if /I "%1" == "/path" shift&goto SetPath
goto EndSetPath
:SetPath
if /I not "%~1" == "" goto DoSetPath
echo ERROR: Argument '-path' specified without argument for TraceFormat folder.
echo Usage example: MQSTrace -path x:\symbols.pri\TraceFormat
goto :eof
:DoSetPath
echo Setting TRACE_FORMAT_SEARCH_PATH to '%1'
set TRACE_FORMAT_SEARCH_PATH=%1&shift
goto :eof
:EndSetPath

@rem
@rem Set Tool paths
@rem
setlocal
if defined TRACE_TOOL_SEARCH_PATH goto SetToolsPathExplicit
set MZRT_TRACELOG_EXE=tracelog.exe
set MZRT_TRACEFMT_EXE=tracefmt.exe
goto EndSetToolsPath
:SetToolsPathExplicit
set MZRT_TRACELOG_EXE="%TRACE_TOOL_SEARCH_PATH%\tracelog.exe"
echo Using %MZRT_TRACELOG_EXE% to log traces
set MZRT_TRACEFMT_EXE="%TRACE_TOOL_SEARCH_PATH%\tracefmt.exe"
echo Using %MZRT_TRACEFMT_EXE% to format traces
:EndSetToolsPath

@rem
@rem Format binary log file to text file
@rem
if /I "%1" == "-format" shift&goto FormatFile
if /I "%1" == "/format" shift&goto FormatFile
goto EndFormatFile
:FormatFile
if defined TRACE_FORMAT_SEARCH_PATH goto DoFormatFile
echo ERROR: Argument '-format' specified without running 'MQSTrace -path' first.
echo Usage example: MQSTrace -path x:\symbols.pri\TraceFormat
echo                MQSTrace -format ('mqsadaptertrace.bin' to text file 'mqsadaptertrace.txt')
goto :eof
:DoFormatFile
set mqBinaryLog=mqsadaptertrace.bin
if /I not "%1" == "" set mqBinaryLog=%1&shift
echo Formatting binary log file '%mqBinaryLog%' to 'mqsadaptertrace.txt'.
call %MZRT_TRACEFMT_EXE% %mqBinaryLog% -o mqsadaptertrace.txt
set mqBinaryLog=
goto :eof
:EndFormatFile


@rem
@rem Process the tracing change
@rem 
if /I "%1" == "-change" shift&goto ChangeTrace
if /I "%1" == "/change" shift&goto ChangeTrace
goto EndChangeTrace

:ChangeTrace
@rem
@rem Process the module
@rem 
set ModuleGuid=

if /I "%1" == "MQSAgent" set ModuleGuid=2F7FEF13,7A25,44B0,90F1,840E94FC5A9F
if /I "%1" == "MGDCOMPS" set ModuleGuid=689E4209,67A2,409b,8303,0905CE67A931

shift

if /I "%ModuleGuid%" == "" goto Usage

@rem
@rem Process the level (-none / -low / -medium / -high / -all / -flag
@rem 
set TraceLevel=
if /I "%1" == "-none" set TraceLevel=0x0
if /I "%1" == "-low" set TraceLevel=0x1
if /I "%1" == "-medium" set TraceLevel=0x3
if /I "%1" == "-high" set TraceLevel=0x7
if /I "%1" == "-all" set TraceLevel=0xFFFFFFFF
if /I "%1" == "-flag" shift & set TraceLevel=%1
 
shift
if /I "%TraceLevel%" == "" goto Usage

@rem
@rem Query if mqsadaptertrace logger is running. If not, echo and exit
@rem 
echo Querying if mqsadaptertrace logger is currently running...
call %MZRT_TRACELOG_EXE% -q mqsadaptertrace
if ERRORLEVEL 1 goto LoggerNotRunning
echo mqsadaptertrace logger is currently running, changing trace level...
goto EndQueryLogger


:LoggerNotRunning
echo.
echo.
echo mqsadaptertrace logger is not currently running
echo Please invoke MQSTrace -start to start tracing 
goto :eof


:EndQueryLogger
@rem
@rem At this point if we have any argument it's an error
@rem 
if /I not "%1" == "" goto Usage


@rem
@rem Make the change
@rem 
call %MZRT_TRACELOG_EXE% -enable mqsadaptertrace -flags %TraceLevel% -guid #%ModuleGuid%
goto :eof
:EndChangeTrace


@rem
@rem Consume the -rt argument
@rem
set mqRealTime=
if /I "%1" == "-rt" shift&goto ConsumeRealTimeArgument
if /I "%1" == "/rt" shift&goto ConsumeRealTimeArgument
goto EndConsumeRealTimeArgument
:ConsumeRealTimeArgument
if defined TRACE_FORMAT_SEARCH_PATH goto DoConsumeRealTimeArgument
echo ERROR: Argument '-rt' specified without running 'MQSTrace -path' first.
echo Usage example: MQSTrace -path x:\symbols.pri\TraceFormat
echo                MQSTrace -rt (start RealTime logging/formatting at Error level)
goto :eof
:DoConsumeRealTimeArgument
echo Running mqsadapter trace in Real Time mode...
set mqRealTime=-rt -ft 1
:EndConsumeRealTimeArgument

@rem
@rem Handle the -stop argument
@rem 
if /I "%1" == "-stop" shift&goto HandleStopArgument
if /I "%1" == "/stop" shift&goto HandleStopArgument
goto EndHandleStopArgument
:HandleStopArgument
echo Stopping mqsadapter trace...
call %MZRT_TRACELOG_EXE% -stop mqsadaptertrace
goto :eof
:EndHandleStopArgument

@rem
@rem Consume the "-start" argument if it exists. Default is to start.
@rem 
echo Starting mqsadapter trace logging to 'mqsadaptertrace.bin'...
if /I "%1" == "-start" shift
if /I "%1" == "/start" shift

@rem
@rem Process the file size argument if it exists. Default is error sequential no limit.
@rem 

set mqLogFileType=
set mqLogFileSize=

if /I "%1" == "-cir" shift&goto ConsumeCircularArgument
if /I "%1" == "/cir" shift&goto ConsumeCircularArgument
goto EndConsumeCircularArgument
:ConsumeCircularArgument
set mqLogFileType=-cir
set mqLogFileSize=%1
shift
goto EndConsumeFileSizeArgument
:EndConsumeCircularArgument

if /I "%1" == "-seq" shift&goto ConsumeSequentialArgument
if /I "%1" == "/seq" shift&goto ConsumeSequentialArgument
goto EndConsumeSequentialArgument
:ConsumeSequentialArgument
set mqLogFileType=-seq
set mqLogFileSize=%1
shift
goto EndConsumeFileSizeArgument
:EndConsumeSequentialArgument

:EndConsumeFileSizeArgument


@rem
@rem Process the noise level argument if it exists. Default is error level.
@rem 

@
@rem Level for the peripherial components (not needed usually)
@
set OtherFlags=0x3
set SuperFlags=0x0

if /I "%1" == "-high" shift&goto ConsumeInfoArgument
if /I "%1" == "/high" shift&goto ConsumeInfoArgument
goto EndConsumeInfoArgument
:ConsumeInfoArgument
echo mqsadapter trace noise level is INFORMATION...
set mqFlags=0x7
set btFlags=0xBF
set msgFlags=0x7
set dbAccessorFlags=0x3
set mgdFlags=0xF
set ssoFlags=0x3
goto EndConsumeNoiseLevelArgument
:EndConsumeInfoArgument

if /I "%1" == "-all" shift&goto ConsumeSuperArgument
if /I "%1" == "/all" shift&goto ConsumeSuperArgument
goto EndConsumeSuperArgument
:ConsumeSuperArgument
echo mqsadapter trace noise level is SUPER...
set mqFlags=0x7
set btFlags=0x7FFFFFFF
set SuperFlags=0x7
set msgFlags=0x7FFFFFFF
set dbAccessorFlags=0x7FFFFFFF
set mgdFlags=0x7FFFFFFF
set ssoFlags=0x7
goto EndConsumeNoiseLevelArgument
:EndConsumeSuperArgument

if /I "%1" == "-medium" shift&goto ConsumeWarningArgument
if /I "%1" == "/medium" shift&goto ConsumeWarningArgument
goto EndConsumeWarningArgument
:ConsumeWarningArgument
echo mqsadapter trace noise level is WARNING...
set mqFlags=0x3
set btFlags=0xB
set msgFlags=0x3
set dbAccessorFlags=0x3
set mgdFlags=0xC
set ssoFlags=0x3
goto EndConsumeNoiseLevelArgument
:EndConsumeWarningArgument

if /I "%1" == "-flag" shift&goto ConsumeFlagArgument
if /I "%1" == "/flag" shift&goto ConsumeFlagArgument
goto EndConsumeFlagArgument
:ConsumeFlagArgument
shift
echo mqsadapter trace noise level is %1...
set mqFlags=%1
set btFlags=%1
set msgFlags=%1
set dbAccessorFlags=%1
set mgdFlags=%1
set ssoFlags=%1
:EndConsumeFlagArgument

if /I "%1" == "-low" shift&goto ConsumeErrorArgument
if /I "%1" == "/low" shift&goto ConsumeErrorArgument
goto EndConsumeErrorArgument
:ConsumeErrorArgument
echo mqsadapter trace noise level is WARNING...
set mqFlags=0x1
set btFlags=0x9
set msgFlags=0x1
set dbAccessorFlags=0x3
set mdgFlags=0xC
set ssoFlags=0x1
goto EndConsumeNoiseLevelArgument
:EndConsumeErrorArgument

echo mqsadapter trace noise level is ERROR...
set mqFlags=0x1
set btFlags=0x9
set msgFlags=0x1
set dbAccessorFlags=0x1
set mgdFlags=0x8
set ssoFlags=0x1
goto EndConsumeNoiseLevelArgument

:EndConsumeNoiseLevelArgument

@rem
@rem At this point if we have any argument it's an error
@rem 
if /I not "%1" == "" goto Usage

@rem
@rem Query if mqsadaptertrace logger is running. If so only update the flags and append to logfile.
@rem 
echo Querying if mqsadaptertrace logger is currently running...
call %MZRT_TRACELOG_EXE% -q mqsadaptertrace
if ERRORLEVEL 1 goto LoggerNotRunning
echo mqsadaptertrace logger is currently running, appending new trace output...
set mqStartLogger=-enable
set mqOpenLogfile=-append
goto EndQueryLogger
:LoggerNotRunning
echo mqsadaptertrace logger is not currently running, starting new logger...
set mqStartLogger=-start
set mqOpenLogfile=-f
:EndQueryLogger

@rem
@rem Start a new mqsadaptertrace logger or update the existing one
@rem 
call %MZRT_TRACELOG_EXE%  %mqLogFileType% %mqLogFileSize% %mqStartLogger% mqsadaptertrace %mqRealTime% -flags %btFlags% %mqOpenLogfile% mqsadaptertrace.bin -guid #2F7FEF13-7A25-44B0-90F1-840E94FC5A9F >nul & @rem MQSAgent
call %MZRT_TRACELOG_EXE% -enable mqsadaptertrace -flags %mgdFlags%    -guid #689E4209,67A2,409b,8303,0905CE67A931 >nul & @rem    MGDCOMPS



set mqFlags=
set OtherFlags=
set SuperFlags=
set set btFlags=
set mqStartLogger=
set mqOpenLogfile=

@rem
@rem In real time mode, start formatting
@rem 
if /I "%mqRealTime%" == "" goto EndRealTimeFormat
echo Starting mqsadaptertrace real time formatting...
call %MZRT_TRACEFMT_EXE% -display -rt mqsadaptertrace -o mqsadaptertrace.txt
:EndRealTimeFormat
set mqRealTime=
goto :eof

:Usage
echo.
echo Usage: 
echo.
echo	MQSTrace [^<Action^>] [^<FileSize^>] [^<Level^>]
echo		(^<Action^> = -start , -stop; ^<FileSize^> = -cir ^<MB^>, -seq ^<MB^>; 
echo		 ^<level^> = -low , -medium, -high, -all, -flag 0xfff)
echo	MQSTrace -path ^<TraceFormat folder^>
echo		(Set env var for TraceFormat folder, needed for rt, format)
echo	MQSTrace -tools ^<Trace Tools folder^>
echo		(Set env var for Trace Tools folder, default will search the current path)
echo	MQSTrace -rt [^<Action^>] [^<Level^>]
echo		(Start trace logger and formatter in Real Time mode, additionally to 
echo		 mqsadaptertrace.bin)
echo	MQSTrace -format [^<Binary log file^>]
echo		(Format binary log file to text file 'mqsadaptertrace.txt')
echo	MQSTrace -change ^<Module^> ^<Level^>
echo		(Change the trace level for each module)
echo.
echo ^<Module^>: The module for which to change the debug level, one of:
echo           MQSAgent, MQSCoreAdapter
echo.
echo Examples: 
echo 	MQSTrace (start/update logging to 'mqsadaptertrace.bin' at Error level)
echo 	MQSTrace -path x:\Symbols.pri\TraceFormat
echo 	MQSTrace -tools "C:\Program Files\Common Files\Biztalk Adapter Trace Utility"
echo 	MQSTrace -rt -high (start real time logging at High level)
echo 	MQSTrace -change MQSAgent -high
echo 	MQSTrace -format (format 'mqsadaptertrace.bin' to 'mqsadaptertrace.txt')
echo 	MQSTrace -stop (stop logging)
echo.

