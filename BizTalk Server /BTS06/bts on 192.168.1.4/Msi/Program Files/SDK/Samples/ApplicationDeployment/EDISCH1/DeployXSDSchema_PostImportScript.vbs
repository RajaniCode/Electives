'--------------------------------------------------------------------------
' File: DeployXSDSchema_PostImportScript.vbs
'
' Summary: This post processing script file is used to install EDI schemas
'          after application import.
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
'
' This script is a post processing script to be used during application import
' to install EDI schemas on the target machine.
'
' Modify as necessary and add this script as a post processing script to a
' BizTalk application with appropriate arguments for installation of
' the given EDI schema post import.
'
' Sample BTSTask command to add this script:
' BTSTask AddResource -type:PostProcessingScript 
'                     -app:Application2
'                     -sou:C:\MyScripts\DeployXSDSchema_PostImportScript.vbs
'                     -dest:BackUp\DeployXSDSchema_PostImportScript.vbs
'
' This script assumes that on the target machine BizTalk Server 2006 is
' installed with the EDI component. Therefore, the tool that installs EDI
' schemas "xsd2edi.exe" is available in the BizTalk Server 2006 
' installation directory. In addition, the script assumes that the schema
' file to be installed is one of the default schemas provided along with
' BizTalk Server 2006 which are present in the sub-directory 
' EDI\Adapter\EDI Schemas\ within the BizTalk Server 2006 installation folder.
'--------------------------------------------------------------------------

set WshShell = WScript.CreateObject("WScript.Shell")

'###########################################################################
'        Edit to specify the names of the schemas to be deployed, and
'	 update the length of the array.
'###########################################################################
Dim schemasToDeploy(1)
schemasToDeploy(0)="EDIFACT\d95b\PARTINSchema.xsd"
schemasToDeploy(1)="EDIFACT\d95b\ORDERSSchema.xsd"

'###########################################################################
'        Open Log files
'###########################################################################
Const ForAppending = 8
Set objFSO = CreateObject("Scripting.FileSystemObject")
Set objLogFile = objFSO.OpenTextFile(WshShell.expandenvironmentstrings("%temp%") & "\ScriptLog.txt", ForAppending, True)
objLogFile.Writeline Now & " Running DeployXSDSchema "

if (Not(WshShell.expandenvironmentstrings("%BTAD_InstallMode%") = "Import" AND WshShell.expandenvironmentstrings("%BTAD_HostClass%") = "ConfigurationDb")) Then
  objLogFile.Writeline Now & " Running DeployXSDSchema " & WshShell.expandenvironmentstrings("%BTAD_InstallMode%")
  objLogFile.Writeline Now & " Running DeployXSDSchema " & WshShell.expandenvironmentstrings("%BTAD_HostClass%")
  objLogFile.Writeline Now & " This script executes only during an import operation. Exiting ... "
  WScript.Quit(0)
End If


'###########################################################################
'        Iterate through each of the schema files and deploy it
'###########################################################################
For Each file in SchemasToDeploy	
  Dim REG_BIZTalk, BizTalkPath 
  Dim Shell: Set Shell = CreateObject("WScript.Shell")
  'BizTalk Server installation path can be read from this registry entry
  REG_BIZTalk = "HKLM\SOFTWARE\Microsoft\BizTalk Server\3.0\"
  BizTalkPath = Shell.RegRead(REG_BIZTalk & "InstallPath" )

  If Err.Number Then
    WScript.Echo "Error Biztalk Registry Entry Not Found"  & Err.Number
    'Non zero return value will indicate an error to the MSI, and cause it
    'it to quit.
    WScript.Quit(1)
  Else
    Dim XSD2EDI, File, Execute
    XSD2EDI = """" & BizTalkPath & "EDI\Subsystem\xsd2edi.exe"""
    File = """" & BizTalkPath & "EDI\Adapter\EDI Schemas\" & file & """"
    objLogFile.Writeline Now & " Executing " & XSD2EDI & " " & File
    Execute = XSD2EDI & " " & File
    'Install EDI Schema	
    Set oExec = WshShell.Exec(Execute)
    WScript.Sleep 100

    If Not oExec.StdOut.AtEndOfStream Then
      objLogFile.Writeline oExec.StdOut.ReadAll
    End If


    'Wait for it to finish execution
    'This is useful as if multiple edi schemas to be installed as the database
    'is locked during each installation
    Do While oExec.Status = 0
      WScript.Sleep 200
    Loop
  End If 
Next

objLogFile.Close