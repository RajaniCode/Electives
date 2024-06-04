Option Explicit 
'------------------------------------------------------------------------------------------------------------
Function IsValidComputerName(name, isComputerName)
 
    Dim InvalidChars
    Dim I, FlagInvalid
 
    InvalidChars = "`~!@#$%^&*()+=[]{}|;\<>? '"""
    isComputerName  = false
    FlagInvalid     = false

    if Len(name) > 63 or Len(name) = 0 then
        FlagInvalid = true
    else
	    if (Len(name) > 0) then
            for I = 1 to Len(name)
	            if InStr(InvalidChars, Mid(name, I, 1)) > 0 then
		            FlagInvalid = true
                    exit for
	            end if
	        next
    	    if FlagInvalid = false then
	        	isComputerName = true
	        else
		        isComputerName = false
            end if
        end if
    end if
      
End Function

'------------------------------------------------------------------------------------------------------------
Function IsValidDatabaseName(name, isDbName)
 
    Dim InvalidChars
    Dim I, FlagInvalid
 
    InvalidChars = "`~!@#$%^&*()+=[]{}|;\/<>? '"""
    isDbName     = false
    FlagInvalid  = false

    if Len(name) > 128 then
        FlagInvalid = true
    else
	    if (Len(name) > 0) then
            for I = 1 to Len(name)
	            if InStr(InvalidChars, Mid(name, I, 1)) > 0 then
		            FlagInvalid = true
                    exit for
	            end if
	        next
    	    if FlagInvalid = false then
	        	isDbName = true
	        else
		        isDbName = false
            end if
        end if
    end if
      
End Function


'------------------------------------------------------------------------------------------------------------
Function IsValidGuid(argValue, isGuid)
 
    Dim ValidChars
    Dim I, isValid
 
    ' Valid guid characters
    ValidChars   = "0123456789ABCDEFabcdef{}-" 
    isGuid       = false  
    isValid      = true
    
    ' with or without braces  
    if Len(argValue) > 38 or 36 > Len(argValue) then
        isValid = false
    else
        for I = 1 to Len(argValue)
            if InStr(ValidChars, Mid(argValue, I, 1)) > 0 then
	        else
                isValid = false
                exit for
            end if
        next

	    if isValid = false then
		    isGuid = false
	    else
		    isGuid = true
	    end if 
    end if

End Function


'------------------------------------------------------------------------------------------------------------
Function GetBTSRegKeyValues(computerName, mgmtDb, mgmtDbServer)

    Dim keyPath, valueName, oReg

    const HKEY_LOCAL_MACHINE = &H80000002

    Set oReg=GetObject( _
        "winmgmts:{impersonationLevel=impersonate}!\\" &_
        computerName & "\root\default:StdRegProv")

    keyPath = "SOFTWARE\Microsoft\BizTalk Server\3.0\Administration"
    valueName = "MgmtDBName"

    oReg.GetStringValue HKEY_LOCAL_MACHINE,keyPath,valueName,mgmtDb

    keyPath = "SOFTWARE\Microsoft\BizTalk Server\3.0\Administration"
    valueName = "MgmtDBServer"

    oReg.GetStringValue HKEY_LOCAL_MACHINE,keyPath,valueName,mgmtDbServer

End Function



'------------------------------------------------------------------------------------------------------------
Function OpenBizTalkSuspendedEventMessageFlow(instanceId, messageId, mgmtDbName, mgmtDbServer) 

    Dim isComputer, guidOneOk, guidTwoOk, IsDbName
    call IsValidComputerName(mgmtDbServer, isComputer)
    call IsValidGuid(instanceId, guidOneOk)
    call IsValidGuid(messageId, guidTwoOk)
    Call IsValidDatabaseName(mgmtDbName, IsDbName)
    if isComputer and guidOneOk and guidTwoOk and IsDbName then
        Dim tempStr
        tempStr = "cmd.exe /c start " & "btshat:" & Chr(34) & "viewname:MessageFlow " & "MgmtDb:" & mgmtDbName & " MgmtSvr:" & mgmtDbServer & " SvcInstId:" & instanceId & " msgId:" & messageId & Chr(34)
        objshell.Run tempStr
    end if 
End Function

'---------------------------------------------------------------------------------------------------------
Function OpenBizTalkSuspendedEventInstance(instanceId, messageId, mgmtDbName, mgmtDbServer)
    Dim isComputerValid, guidOneValid, guidTwoValid, IsDbNameValid
    call IsValidComputerName(mgmtDbServer, isComputerValid)
    call IsValidGuid(instanceId, guidOneValid)
    call IsValidGuid(messageId, guidTwoValid)
    call IsValidDatabaseName(mgmtDbName, IsDbNameValid)
    if isComputerValid and guidOneValid and guidTwoValid  and IsDbNameValid then
        Dim tempStr
        tempStr = "btsmmc.msc " & "btshat:" & "viewname:SvcInstQuery " & " MgmtDb:" & mgmtDbName & " MgmtSvr:" & mgmtDbServer & " SvcInstId:" & instanceId & " msgId:" & messageId
        objshell.Run tempStr
    end if
End Function

'----------------------------------------------------------------------------------------------------------
Function OpenBizTalkSuspendedEventInstanceByComputer(computerName, instanceId, messageId)
    Dim mgmtDbName, mgmtDbServer
    GetBTSRegKeyValues computerName, mgmtDbName, mgmtDbServer
    OpenBizTalkSuspendedEventInstance instanceId, messageId, mgmtDbName, mgmtDbServer 
End Function

'------------------------------------------------------------------------------------------------------------
Function OpenBizTalkSuspendedEventMessageFlowByComputer(computerName, instanceId, messageId) 
    Dim mgmtDbName, mgmtDbServer
    GetBTSRegKeyValues computerName, mgmtDbName, mgmtDbServer
    OpenBizTalkSuspendedEventMessageFlow instanceId, messageId, mgmtDbName, mgmtDbServer
End Function

'------------------------------------------------------------------------------------------------------------
Function HandleBAMTechnicalAssistanceEvent(queryType, BAMEventDescription) 

    Dim SearchString, SearchChar1N, SearchChar2N, SearchChar3N, MyPos
    Dim instanceId, messageId, mgmtDbName, mgmtDbServer
    Dim MyArrayBtsInfo, ArrayLen, MyServiceInfo, MyMsgInfo, MyMgmtDbServerInfo, MyMgmtDbInfo

    SearchString = BAMEventDescription

    'SearchString ="Title Description\n[BizTalk Service Instance ID: 1FA3D93F-1F93-4324-B2D4-D136E590EBBE]\n[Message ID: 2FA3D93F-1F93-4324-B2D4-D136E590EBBE]\n[Management Database Server: TestServer]\n[Management Database Name: BTSdb1]"   ' String to search in.

    SearchChar3N = "]"   
    SearchChar2N = "["   
    SearchChar1N = ": "  

    MyArrayBtsInfo = Split(SearchString, SearchChar2N, -1, 0)

    ArrayLen = UBound(MyArrayBtsInfo, 1)

    MyServiceInfo = Split(MyArrayBTSInfo(ArrayLen -3), SearchChar1N, -1, 0)
    instanceId = Trim(Replace(MyServiceInfo(1), SearchChar3N, ""))

    MyMsgInfo = Split(MyArrayBTSInfo(ArrayLen -2), SearchChar1N, -1, 0)
    messageId = Trim(Replace(MyMsgInfo(1), SearchChar3N, ""))

    MyMgmtDbServerInfo = Split(MyArrayBTSInfo(ArrayLen -1), SearchChar1N, -1, 0)
    mgmtDbServer = Trim(Replace(MyMgmtDbServerInfo(1), SearchChar3N, ""))

    MyMgmtDbInfo = Split(MyArrayBTSInfo(ArrayLen), SearchChar1N, -1, 0)
    mgmtDbName = Trim(Replace(MyMgmtDbInfo(1), SearchChar3N, ""))

    if queryType = "SvcInstQuery" Then
       OpenBizTalkSuspendedEventInstance instanceId, messageId, mgmtDbName, mgmtDbServer
    end if

    if queryType = "MessageFlow" Then
        OpenBizTalkSuspendedEventMessageFlow instanceId, messageId, mgmtDbName, mgmtDbServer 
    end if

End Function

'---------------------------------------------------------------------------------------------------------------

Dim objShell
Set objShell = CreateObject("WScript.Shell")

'Argument 0 is Query Type
'         1 is Event Id:Event Source
'         2 is Source Computer Name
'         3 is ServiceInstanceId
'         4 is MessageInstanceId
'---------------------------------------------------------------------------------------------------------------

Dim bizTalkEventDetailsArray, eventNumber, eventSource, I
Dim eventDetailString, temp, BizTalkCoreSource, BizTalkBAMSource
Dim objArgs, MyPos

'SvcInstQuery $CustomField5$ $Computer Name$ $CustomField2$ $CustomField1$ "$Description$"
Set objArgs = WScript.Arguments

bizTalkEventDetailsArray = Split(Trim(WScript.Arguments(1)), ":", -1, 0)
eventNumber = Trim(bizTalkEventDetailsArray(0))
eventSource = Trim(bizTalkEventDetailsArray(1))

BizTalkCoreSource = "BizTalk"
BizTalkBAMSource  = "BAM"

' if Event Source is BizTalk Server 2006  
MyPos = Instr(1, eventSource, BizTalkCoreSource, 1) 
if MyPos <> 0 Then
        if Trim(WScript.Arguments(0)) = "SvcInstQuery" Then
            OpenBizTalkSuspendedEventInstanceByComputer Trim(WScript.Arguments(2)), Trim(WScript.Arguments(3)), Trim(WScript.Arguments(4))
        end if 

        if Trim(WScript.Arguments(0)) = "MessageFlow" Then
            OpenBizTalkSuspendedEventMessageFlowByComputer Trim(WScript.Arguments(2)), Trim(WScript.Arguments(3)), Trim(WScript.Arguments(4))
        end if 
end If


'SvcInstQuery $CustomField5$ "$Description$"

'Argument 0 is Query Type
'         1 is EventId:Event Source
'         2  is Source Computer Name
'         3-N is Event Description
'---------------------------------------------------------------------------------------------------------------

' if Event Source is BAM and event ID = 1000 
MyPos = Instr(1, eventSource, BizTalkBAMSource, 1) 
if MyPos <> 0 Then
      
    if eventNumber = 1000 Then
        'Extracting event description
        For I =  3 to objArgs.Count - 1
            eventDetailString = eventDetailString + objArgs(I)
        Next
        HandleBAMTechnicalAssistanceEvent Trim(WScript.Arguments(0)), Trim(eventDetailString)
    end if
end If


