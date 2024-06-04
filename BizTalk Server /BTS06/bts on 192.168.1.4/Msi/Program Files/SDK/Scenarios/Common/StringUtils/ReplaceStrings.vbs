' ---------------------------------------------------------------------------------
'  Microsoft.Samples.BizTalk.*
'  
' Scripts to replace arbitrary strings in files.  These scripts are used to replace
' the public key tokens in the files, when a solution needs to use a differnet key 
' from the one that it was compiled with.
' 
'  Copyright (c) Microsoft Corporation. All rights reserved.  
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
'  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
' ---------------------------------------------------------------------------------
' 
Option Explicit

' Constants for file access 
Const ForReading = 1, ForWriting = 2

' Constants for encoding to use when reading from files.

Const EncodingUnicode = 2
Const EncodingUTF8 = 1
Const EncodingASCII = 0

Const adSaveCreateOverwrite = 2

Function ReplaceString (sourceString, pattern, stringToReplaceWith)
	Dim regEx					' Create variables.
	Set regEx = New RegExp		' Create regular expression.
	regEx.Pattern = pattern		' Set pattern.
	regEx.IgnoreCase = False		' Make case insensitive.
	regEx.Global = True			' Set global applicability.

	if regEx.Test(sourceString) then
		ReplaceString = regEx.Replace(sourceString, stringToReplaceWith)   ' Make replacement.
	else
		WScript.Echo "ReplaceString - No match was found."
		WScript.Echo pattern
		WScript.Echo stringToReplaceWith
		WScript.Echo ""
		ReplaceString = sourceString	' No change made
	end if
End Function


Function ReadFileContent(fileName, encoding)

'encoding: must be one of the encoding values above

	ReadFileContent = ""

	Dim stream 
   	Set stream = CreateObject("ADODB.Stream")
	stream.Open

	If (encoding = EncodingASCII) then
		stream.Charset = "Windows-1252"
	ElseIf (encoding = EncodingUTF8) then
			stream.Charset = "UTF-8"
	ElseIf (encoding = EncodingUniCode) then
			stream.Charset = "Unicode"
	Else
		Wscipt.echo "Invalid Encoding Value " + encoding
		return
	End If

	stream.LoadFromFile fileName
	ReadFileContent = stream.ReadText

	stream.Close
	set stream = nothing

End Function

Sub WriteContentToFile(fileName, content, encoding)

	Dim stream 
    Set stream = CreateObject("ADODB.Stream")
	stream.Open

	If (encoding = EncodingASCII) then
		stream.Charset = "Windows-1252"
	ElseIf (encoding = EncodingUTF8) then
			stream.Charset = "UTF-8"
	ElseIf (encoding = EncodingUniCode) then
			stream.Charset = "Unicode"
	Else
		Wscipt.echo "Invalid Encoding Value " + encoding
		return
	End If

	stream.WriteText content
	stream.SaveToFile fileName, adSaveCreateOverwrite

	stream.Close
	set stream = nothing

End Sub

Sub ReplacePKTokenInFile(fileName, encoding, currentToken, newToken)

	dim fileContent

	Wscript.Echo "Replacing " + fileName
	fileContent = ReadFileContent(fileName, encoding)
	fileContent = ReplaceString(fileContent, currentToken, newToken)

	WriteContentToFile fileName, fileContent, encoding
	
End Sub

Function RetrievePublicKeyToken (pkTokenFile)

	Dim pkToken

	pkToken = ReadFileContent (pkTokenFile, EncodingASCII)
	Dim tokens

	tokens = Split(pkToken, " ", -1, 0)

	' The public key token is the last token from the string...

	Dim lastTokenNumber 
	
	lastTokenNumber = UBound(tokens, 1)
	pkToken = Replace(tokens(lastTokenNumber), CHR(13)+CHR(10), "")

	RetrievePublicKeyToken = pkToken

End Function


