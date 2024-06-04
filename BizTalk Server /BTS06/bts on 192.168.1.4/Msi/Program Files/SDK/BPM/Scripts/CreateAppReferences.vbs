' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.SouthridgeVideo
'  
'  Scripts to create MSMQ queues on the local machine for the BPM scenario
' 
'  Copyright (c) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
'

Option Explicit

AddReference "BTSScn.BPM.MessagingApp", "BTSScn.BPM.MessagingApp.Test"
AddReference "BTSScn.BPM.CableOrderApp", "BTSScn.BPM.CableOrderApp.Test"
AddReference "BTSScn.BPM.OrderBrokerApp", "BTSScn.BPM.OrderBrokerApp.Test"

AddReference "BTSScn.BPM.CableOrderApp", "BTSScn.BPM.MessagingApp"
AddReference "BTSScn.BPM.OrderBrokerApp", "BTSScn.BPM.MessagingApp"

Sub AddReference(Application, ReferencedApplication)
'    On Error Resume Next
    Dim objCatalog, objApplications
    Dim objApp, objAppRef
    Dim objFoundApp, objFoundAppRef
    set objCatalog = WScript.CreateObject("BtsCatalogExplorer")
    objCatalog.ConnectionString = "Server=.;Database=BizTalkMgmtDb;Integrated Security=SSPI"
    set objApplications = CreateObject("System.Collections.ArrayList")
    objApplications.AddRange objCatalog.GetCollection(14)
    
    'Find the application
    For Each objApp in objApplications
        if objApp.Name = Application then
            set objFoundApp = objApp
        end if
    Next
    If Err <> 0 Then
        wscript.echo "Could not get application: " + Application
        PrintWMIError Err.Description, Err.number
    End If    
    
    'Find the referenced application
    For Each objAppRef in objApplications
        if objAppRef.Name = ReferencedApplication then
            set objFoundAppRef = objAppRef
        end if
    Next

    If Err <> 0 Then
        wscript.echo "Could not get application: " + ReferencedApplication
        PrintWMIError Err.Description, Err.number
    End If    
    
    objFoundApp.AddReference(objFoundAppRef)
    If Err <> 0 Then
        wscript.echo "Could not add reference to application " + Application + " for referenced application " + ReferencedApplication
        PrintWMIError Err.Description, Err.number
    Else
        wscript.echo "Added reference to application " + Application + " for referenced application " + ReferencedApplication
    End If    
    
    objCatalog.SaveChanges()
    
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
