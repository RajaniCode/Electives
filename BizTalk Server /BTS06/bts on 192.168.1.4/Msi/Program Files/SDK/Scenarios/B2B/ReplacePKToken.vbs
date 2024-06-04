' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.B2B
'  
' Scripts to replace public key tokens in the source files to newer token
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
Const CurrentPKTokenToReplace = "xxxxxxxxxxxxxxxx"

if WScript.Arguments.Length = 0 Then
	Wscript.Echo "Usage: ReplacePKToken.vbs <Public Key token file>"
end if

Dim newPKToken
newPKToken = RetrievePublicKeyToken(WScript.Arguments.Item(0))

' Replace in the binding files...

ReplacePKTokenInFile ".\Bindings\BindingOrchestration.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\BindingOrderSystem.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\OtherPorts.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\PartyPorts.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken