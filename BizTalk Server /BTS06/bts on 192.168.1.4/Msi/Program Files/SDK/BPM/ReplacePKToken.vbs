' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.SouthridgeVideo
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
Const CurrentPKTokenToReplace = "XXXXXXXXXXXXXXXX"

if WScript.Arguments.Length = 0 Then
	Wscript.Echo "Usage: ReplacePKToken.vbs <Public Key token file>"
end if

Dim newPKToken
newPKToken = RetrievePublicKeyToken(WScript.Arguments.Item(0))

' Replace in the binding files...

ReplacePKTokenInFile ".\Bindings\CableOrderAppBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\MessagingAppBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\OrderBrokerAppBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\CableOrderAppBindings-test.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\MessagingAppBindings-test.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\OrderBrokerAppBindings-test.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

'Replace in the WSDL files...
ReplacePKTokenInFile ".\CSRWebApp\App_WebReferences\SouthridgeVideo_OrderBroker\OrderBrokerOrch_OrderPort.wsdl", EncodingASCII, CurrentPKTokenToReplace, newPKToken

'Replace in the web service proxy files...
ReplacePKTokenInFile "OrderBroker_Proxy\App_Code\OrderBrokerOrch_OrderPort.asmx.cs", EncodingUnicode, CurrentPKTokenToReplace, newPKToken