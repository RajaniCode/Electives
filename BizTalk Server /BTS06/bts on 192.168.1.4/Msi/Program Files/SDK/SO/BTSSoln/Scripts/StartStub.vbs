' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.WoodgroveBank
'  
'  Command file to enlist and start the stub version of the orchestrations
' 
'  Copyright (C) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
' 
Option Explicit

StartAll

Sub StartAll()

	Start "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed.CustomerService", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed"
	Start "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed.CustomerServiceNativeRequestResponse", "Microsoft.Samples.BizTalk.WoodgroveBank.Orchestrations.Stubbed"

End Sub

Sub Start(orchestration, assembly)

	Const HostName = "BizTalkServerApplication"

	Dim Query, InstSet, Inst

	On Error Resume Next

	Query = "SELECT * FROM MSBTS_Orchestration WHERE Name =""" & orchestration & """ AND AssemblyName = """ & assembly & """"
	Set InstSet = GetObject("Winmgmts:!root\MicrosoftBizTalkServer").ExecQuery(Query)

	'Check for error condition before continuing.
	If Err <> 0	Then
		PrintWMIError Err.Description, Err.Number
	End If

	'If orchestration found, enlist and start the orchestration, otherwise print error and end.
	If InstSet.Count > 0 then
		For Each Inst in InstSet

			Inst.Enlist(HostName)
			If Err <> 0	Then
				PrintWMIError Err.Description, Err.Number
			Else
			 	wscript.echo "Orchestration: " + orchestration + " was successfully enlisted"
			End If

			Inst.Start 2, 2
			If Err <> 0	Then
				PrintWMIError Err.Description, Err.Number
			Else
			 	wscript.echo "Orchestration: " + orchestration + " was successfully started from assembly " + assembly
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
