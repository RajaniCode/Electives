' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.WoodgroveBank
'  
' Scripts to replace public key tokens in the source files to newer token
' when a solution needs to use a differnet key from the one that it was compiled with.
' 
'  Copyright (C) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
'

Option Explicit

' If the key is changed, replace the value of this symbol with the new PK token that needs to be changed
Const CurrentPKTokenToReplace = "a1054514fc67bded"

if WScript.Arguments.Length = 0 Then
	Wscript.Echo "Usage: ReplacePKToken.vbs <Public Key token file>"
end if

Dim newPKToken
newPKToken = RetrievePublicKeyToken(WScript.Arguments.Item(0))

' Replace in the orchestration proxy code

ReplacePKTokenInFile ".\OrchProxy\Inline\app_code\customerserviceport.asmx.cs", EncodingUnicode, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\OrchProxy\Adapter\app_code\customerserviceport.asmx.cs", EncodingUnicode, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\OrchProxy\Stub\app_code\customerserviceport.asmx.cs", EncodingUnicode, CurrentPKTokenToReplace, newPKToken 

' Replace in the binding files...

ReplacePKTokenInFile ".\Bindings\AdapterSOAOrchBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\InlineSOAOrchBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Bindings\StubSOAOrchBindings.xml", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

' Replace it in the wsdl files - the public key token is there in the documentation field so these don't have to be replaced...
' Neverthless, to keep the consistency...

ReplacePKTokenInFile ".\SimpleClient\AdapterCustomerServicePort.wsdl", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\SimpleClient\InlineCustomerServicePort.wsdl", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

' Replace it in the undeployment scripts...

ReplacePKTokenInFile ".\Scripts\UndeployAll.cmd", EncodingASCII, CurrentPKTokenToReplace, newPKToken 
ReplacePKTokenInFile ".\Scripts\UndeployStub.cmd", EncodingASCII, CurrentPKTokenToReplace, newPKToken 


' Replace it in the Set SSO Config cmd file, where the key is in the schema type names for the payment tracker
ReplacePKTokenInFile ".\Scripts\SetConfigValuesInSSO.cmd", EncodingASCII, CurrentPKTokenToReplace, newPKToken 

