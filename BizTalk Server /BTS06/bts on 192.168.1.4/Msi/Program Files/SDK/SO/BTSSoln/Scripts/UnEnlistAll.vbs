' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.WoodgroveBank
'  
'  Command file to unenlist all the orchestrations
' 
'  Copyright (C) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
' 

Option Explicit

UnEnlistAll

Sub UnEnlistAll()

	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter.CustomerServiceReceiveSend", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter"
	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter.CustomerServiceNativeRequestResponse", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter"
	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter.CustomerService", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Adapter"

	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline.CustomerServiceReceiveSend", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline"
	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline.CustomerServiceNativeRequestResponse", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline"
	UnEnlist "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline.CustomerService", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Inline"

End Sub

Sub UnEnlist(orchestration, assembly)

	Const HostName = "localhost"

	Dim Query, InstSet, Inst

	On Error Resume Next

	Query = "SELECT * FROM MSBTS_Orchestration WHERE Name =""" & orchestration & """ AND AssemblyName = """ & assembly & """"
	Set InstSet = GetObject("Winmgmts:!root\MicrosoftBizTalkServer").ExecQuery(Query)

	'Check for error condition before continuing.
	If Err <> 0	Then
		PrintWMIError Err.Description, Err.Number
	End If

	'If orchestration found, un-enlist the orchestration, otherwise print error and end.
	If InstSet.Count > 0 then
		For Each Inst in InstSet

			Inst.Stop
			If Err <> 0	Then
				PrintWMIError Err.Description, Err.Number
			End If

			Inst.UnEnlist
			If Err <> 0	Then
				PrintWMIError Err.Description, Err.Number
			Else
			 	wscript.echo "Orchestration: " + orchestration + " was successfully unenlisted from assembly " + assembly
			End If
		Next
	End If
End Sub

Sub	PrintWMIError(strErrDesc, ErrNum)
	On Error Resume	Next
	Dim	objWMIError	: Set objWMIError =	CreateObject("WbemScripting.SwbemLastError")

	If ( TypeName(objWMIError) = "Empty" ) Then
		wscript.echo strErrDesc & " (HRESULT: "	& Hex(ErrNum) & ")."
	Else
		wscript.echo objWMIError.Description & "(HRESULT: "	& Hex(ErrNum) & ")."
		Set objWMIError	= nothing
	End	If
	
End Sub 
