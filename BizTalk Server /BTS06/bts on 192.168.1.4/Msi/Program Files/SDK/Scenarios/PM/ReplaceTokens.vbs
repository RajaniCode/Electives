' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.WingtipToys
'  
' Scripts to replace public key  and other tokens in the source files to newer tokens
' when a solution needs to use a differnet key from the one that it was compiled with.
' 
'  Copyright (c) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
'

Option Explicit

' If the key is changed, replace the value of this symbol with the new PK token that needs to be changed
Const CurrentPKTokenToReplace = "7c613da897e0d8e7"

' The token in the binding file that needs to be replaced with the base directory of the receive locations
' and send ports.
Const BaseFolderToken = "__PM_FILEDROP_LOC__"

if WScript.Arguments.Length < 2 Then
	Wscript.Echo "Usage: ReplaceTokens.vbs <Public Key token file> <New Base Directory for Receive Locations And Send Ports>"
end if

Dim newPKToken
newPKToken = RetrievePublicKeyToken(WScript.Arguments.Item(0))

Dim newFileDropBaseDirectory 
newFileDropBaseDirectory = WScript.Arguments.Item(1)

' Replace in the binding files...

ReplacePKTokenInFile ".\Bindings\PMBinding.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

' Replace the PK token in the Undeploy.bat file, where the assembly reference is used to remove the assembly from BizTalk

ReplacePKTokenInFile ".\Scripts\Undeploy.bat", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

' Replace the base directory token with the real directory names in the binding file...

ReplacePKTokenInFile ".\Bindings\PMBinding.xml", EncodingASCII, BaseFolderToken, newFileDropBaseDirectory 
