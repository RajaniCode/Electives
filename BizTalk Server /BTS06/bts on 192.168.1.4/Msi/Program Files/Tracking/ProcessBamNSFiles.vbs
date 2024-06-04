'--------------------------------------------------------------------------
' File: ProcessBamNSFiles.vbs
'
' Summary: This file is used by by system administrators to get and update the NS ADF & Config
'           used by BAM Alerts
'
'--------------------------------------------------------------------------
' This file is part of the Microsoft BizTalk Server 2006 SDK
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft BizTalk
' Server 2006 release and/or on-line documentation. See these other
' materials for detailed information regarding Microsoft code samples.
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
' PURPOSE.
'--------------------------------------------------------------------------
'
' Usage: -Get|Update <ConfigFilePath> <ADFFilePath> <PIT Server> <PIT DB>"


Option Explicit

Const ADFPropName = "NSADF"
Const ConfigPropName = "NSConfig"
Const GlobalScopeVal="Global"
Const AlertScopeVal="Alert"
Const BAMNSAppNameProp="ApplicationDatabaseName"
Const NSDBSystemPropName="DBServer"
Const BAMNSInstPropName="InstanceDatabaseName"

' Check argument length
If WScript.Arguments.Length<>5 Then
 PrintHelp
' Exit
 WScript.Quit
End If

' if -Get then get NC Config Files
If StrComp( WScript.Arguments.Item(0),"-Get",1)=0 Then
 GetFiles

' else if -Update then run nscontrol and store files
elseIf StrComp(WScript.Arguments.Item(0),"-Update",1)=0 Then
 UpdateFiles 

' unkown command
else
 PrintHelp
 WScript.Quit
End If

If Err.number <> 0 Then
	WScript.Echo "[FAIL] Failure in script code: " & err.number & ": " & err.Description
End If

' Exit
 WScript.Quit


' prints usage
Sub PrintHelp()
 WScript.Echo "use -Get <ConfigFilePath> <ADFFilePath> <PIT Server> <PIT DB>"
 WScript.Echo "Or  -Update <ConfigFilePath> <ADFFilePath> <PIT Server> <PIT DB>"
End Sub

' Gets the NS files from the BAM db
Sub GetFiles()
 Dim configFile
 Dim adfFile
 Dim PITDbName 
 Dim PITSrv 
 Dim Constr

'Get Arguments
 configFile = WScript.Arguments.Item(1)
 adfFile=WScript.Arguments.Item(2)
 PITSrv=WScript.Arguments.Item(3)
 PITDbName = WScript.Arguments.Item(4)

' build connection string to PIT
  Constr=BuildConnectionString( PITDbName,PITSrv)
  'Get the config file and write it to disk
  WriteFile configFile,GetPropertyFromPIT(GlobalScopeVal,ConfigPropName, Constr)
  'Get the ADF file and write it to disk
  WriteFile adfFile,GetPropertyFromPIT(GlobalScopeVal,ADFPropName  , Constr)
End Sub

' calls nscontrol update on the new config & adf files then stores them in the PIT
Sub UpdateFiles()

 Dim configFile
 Dim adfFile
 Dim PITDbName 
 Dim PITSrv 
 Dim Constr
Dim appname
Dim nsdbSystem
Dim nsinstname

'Get Arguments
 configFile = WScript.Arguments.Item(1)
 adfFile=WScript.Arguments.Item(2)
 PITSrv=WScript.Arguments.Item(3)
 PITDbName= WScript.Arguments.Item(4)

' build PIT connection string
 Constr=BuildConnectionString( PITDbName,PITSrv)
 'Get the NS app name from PIT
 appname = GetPropertyFromPIT(AlertScopeVal,BAMNSAppNameProp, Constr)
 'Get the NS db System from PIT
 nsdbSystem = GetPropertyFromPIT(AlertScopeVal,NSDBSystemPropName, Constr)
 'Get the NS instance name from PIT
 nsinstname = GetPropertyFromPIT(AlertScopeVal,BAMNSInstPropName, Constr)
 ' Disable NS app
 ExecuteNSControlEnableDisable nsinstname, appname, nsdbSystem, False
 ' call nscontol update
 ExecuteNSControlUpdate  configFile, adfFile
 ' Enable NS app
 ExecuteNSControlEnableDisable nsinstname, appname, nsdbSystem, True
 ' build connection string
 Constr=BuildConnectionString( PITDbName,PITSrv)
Dim cnn 
set cnn = CreateObject("ADODB.Connection")
cnn.Open Constr
cnn.BeginTrans
'store files in PIT
 StorePropertyInPIT ConfigPropName,ReadFile(configFile),cnn
 StorePropertyInPIT ADFPropName ,ReadFile(adfFile),cnn
'commit the transaction
cnn.CommitTrans
'cleanup
    If Not cnn Is Nothing Then
        If Not cnn.State = 0Then
            cnn.Close
        End If
        Set cnn = Nothing
    End If

End Sub


Function BuildConnectionString(db,srv)

BuildConnectionString="Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Data Source="&srv&";Initial Catalog="&db

End Function
' gets a property from the PIT
Function GetPropertyFromPIT( propscope, propname  , pitConnStr)

 	Dim cnn                 
	Dim cmd                 
    	Dim rst                 
	Dim sCommandText                             

    	' Initialize
    	set cnn = CreateObject("ADODB.Connection")
    	Set cmd = CreateObject("ADODB.Command")
    	Set rst = CreateObject("ADODB.Recordset")
    
	sCommandText        = "bam_Metadata_GetProperty"



	cnn.Open pitConnStr
	cmd.ActiveConnection = cnn
	' populate command params and execute
    	With cmd
	        .CommandType =4
	        .CommandText = sCommandText
	        .ActiveConnection = cnn
		 .Parameters.Append(.CreateParameter("@propertyName",200, 1,300,propname ))
		 .Parameters.Append(.CreateParameter("@scope",200, 1,300,propscope ))
	        Set rst = .Execute
    	End With
	
        ' read the property value
	 With rst
		GetPropertyFromPIT = .Fields("PropertyValue").Value        
     End With

'cleanup    	   
If Not rst Is Nothing Then
        If Not rst.State = 0 Then
            rst.Close
        End If
        Set rst = Nothing
    End If
    Set cmd = Nothing
    If Not cnn Is Nothing Then
        If Not cnn.State = 0 Then
            cnn.Close
        End If
        Set cnn = Nothing
    End If

End Function

' Stores properties in the PIT
Sub StorePropertyInPIT( propname , propvalue , cnn)

	Dim cmd                 
	Dim sCommandText                             

    	' Initialize
    	Set cmd = CreateObject("ADODB.Command")
    
	sCommandText        = "bam_Metadata_UpsertProperty"



	cmd.ActiveConnection = cnn
    	With cmd
	        .CommandType =4
	        .CommandText = sCommandText
	        .ActiveConnection = cnn
		 .Parameters.Append(.CreateParameter("@propertyName",200, 1,300,propname))

		 .Parameters.Append(.CreateParameter("@propertyValue",203, 1,len(propvalue),propvalue))
	        .Execute
    	End With	

End Sub

' calls NS control disable/enable for the BAM NS application
Sub ExecuteNSControlEnableDisable(nsinstname, nsappname, nsdbsystem, bEnable)

Dim ncControlcommand 

if bEnable=True  Then
ncControlcommand = "cmd.exe  /C """&GetNSControlExePath()&"  enable -name "&nsinstname&" -application "&nsappname&" -server "&nsdbsystem&""
Else
ncControlcommand = "cmd.exe /C """&GetNSControlExePath()&"  disable -name "&nsinstname&" -application "&nsappname&" -server "&nsdbsystem&""
End If

WScript.Echo ncControlcommand 
'Execute
RunCmd ncControlcommand

End Sub
'Executes NS control Update
Sub ExecuteNSControlUpdate(configPath, adfpath)

Dim ncControlcommand 
Dim oShell
Dim curDir

'Get current dir
Set oShell = CreateObject("WScript.Shell")
curDir = oShell.CurrentDirectory
'build command
ncControlcommand =  "cmd.exe /C """&GetNSControlExePath()&" update -in "&QuoteWrap(configPath)&" ADFPath="&QuoteWrap(adfpath)&" BaseDirPath="&QuoteWrap(curDir)&" -force """
WScript.Echo ncControlcommand 
WScript.Echo "This may take a few minutes ..."
'Execute
RunCmd ncControlcommand
End Sub

' Runs a shell command
Sub RunCmd(CmdString)
    Dim wshshell
    Dim oExec 
    Dim output    

    Set wshshell = CreateObject("WScript.Shell")
    Set oExec = wshshell.Exec( CmdString)
    Set output = oExec.StdOut 
Do While oExec.Status = 0
     WScript.Sleep 100
     if	output.AtEndOfStream = false then
	 		WScript.Echo output.ReadAll
     else
	exit Do

     end if
     
Loop
 WScript.Echo   oExec.Stderr.ReadAll

If oExec.ExitCode <> 0 Then
     Wscript.Echo "command failed"
     WScript.Quit
End If

    Set wshshell = Nothing
End Sub

'encloses a string in double quotes
Function QuoteWrap (myString)
	If (left(mySTring, 1) <> Chr(34) ) And (Right(myString, 1) <> Chr(34)) Then
		QuoteWrap = Chr(34) & myString & Chr(34)
	Else
		QuoteWrap = myString
	End If
	
End Function
Function GetNSControlExePath()
     Const nsCtrExeName="nscontrol.exe"
    GetNSControlExePath = nsCtrExeName   
end Function
'reads a file and returns the content as a string
Function ReadFile(strFilePath)

        Const ForReading = 1
        Const TristateTrue = -1 'open as unicode
        Dim fsObj, tsObj
        Set fsObj = CreateObject("Scripting.FileSystemObject")
        Set tsObj = fsObj.OpenTextFile(strFilePath, ForReading,False,TristateTrue)
                
        ReadFile = tsObj.ReadAll
        tsObj.Close

        Set fsObj = Nothing
        Set tsObj = Nothing                        
End Function
'writes fileContent to strFilePath
Sub WriteFile(strFilePath, fileContent)

        Const ForWriting = 2
       Const TristateTrue = -1 'open as unicode
        Dim fsObj, tsObj
        Set fsObj = CreateObject("Scripting.FileSystemObject")
        Set tsObj = fsObj.OpenTextFile(Replace(strFilePath, Chr(34), ""),  ForWriting,True ,TristateTrue)
        tsObj.Write   (fileContent)
        tsObj.Close                
        Set fsObj = Nothing
        Set tsObj = Nothing
        
End Sub
