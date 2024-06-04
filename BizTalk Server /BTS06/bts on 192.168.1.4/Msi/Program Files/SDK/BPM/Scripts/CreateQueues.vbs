' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.SouthridgeVideo
'  
'  Script to create MSMQ queues on the local machine for the BPM scenario
' 
'  Copyright (c) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
'

Option Explicit
CreateQueue ".\private$\ToFacilitiesQ", "BPM Scenario ToFacilitiesQ", True
CreateQueue ".\private$\FromFixedOrdersQ", "BPM Scenario FromFixedOrdersQ", True
CreateQueue ".\private$\FromFacilitiesQ", "BPM Scenario FromFacilitiesQ", True
CreateQueue ".\private$\ToServicingSystemQ", "BPM Scenario ToServicingSystemQ", True
CreateQueue ".\private$\ToCSRSystemQ", "BPM Scenario ToCSRSystemQ", False
CreateQueue ".\private$\ToVendorSystemQ", "BPM Scenario ToVendorSystemQ", False

Sub CreateQueue(PathName, Label, IsTransactional)
    On Error Resume Next
    Dim qinfo
    set qinfo = CreateObject ("MSMQ.MSMQQueueInfo")

    qinfo.PathName = PathName
    qinfo.Label = Label
    qinfo.Create IsTransactional, True
    If Err <> 0 Then
        wscript.echo "Failed to create " + qinfo.PathName + " because: "
        PrintWMIError Err.Description, Err.number
        Err.Clear
    Else
        wscript.echo "Queue: " + qinfo.PathName + " was successfully created"
    End If
    
   qinfo.Update
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
