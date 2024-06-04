'--------------------------------------------------------------------------
' File: SetInstallPathEnv.vbs
'
' Summary: This file is used by several samples to retrieve the Path to Biztalk.
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

Option Explicit

Function GetBizTalkInstallPath ()

	Dim REG_BIZTalk, BizTalkPath 
	Dim Shell: Set Shell = CreateObject("WScript.Shell")
	REG_BIZTalk = "HKLM\SOFTWARE\Microsoft\BizTalk Server\3.0\"
	On Error Resume Next
	btsPath = Shell.RegRead(REG_BIZTalk & "InstallPath" )

	If Err.Number Then
		GetBizTalkInstallPath = ""
	Else
		Dim lenPath
		lenPath = Len(btsPath)
		Dim lastSlash
		lastSlash = Right(btsPath, 1)
		if lastSlash = "\" Then
			btsPath = Left(btsPath, lenPath - 1)
		End If
		GetBizTalkInstallPath = btsPath
	End If 
End Function

Const Quote = """" 

Sub GenerateTempCMDFileWithBizTalkInstallPath(tmpFileName)

	Dim btsPath
	btsPath = GetBizTalkInstallPath()

	' assemble the set command
	btsPath = "set BizTalkInstallPath=" &  Quote  & btsPath & Quote

	' generate the batch file containing the set command... needs to be ASCII...
	WriteContentToFile tmpFileName, btsPath, EncodingASCII
End Sub


Dim btsPath

if WScript.Arguments.Length = 0 Then
	Wscript.Echo "Usage: cscript FindBTSInstall.wsf <temp file name>"
end if

GenerateTempCMDFileWithBizTalkInstallPath Wscript.Arguments.Item(0)

