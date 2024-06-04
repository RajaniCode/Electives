﻿<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->
<%

Response.Charset = "UTF-8"
'----------------------------------------------------------------------------------
' TransactionDetails.asp
' ======================
' Sends a GetTransactionDetails NVP API request to PayPal.

' The code retrieves the transaction ID and constructs the
' NVP API request string to send to the PayPal server. The
' request to PayPal uses an API Signature.

' After receiving the response from the PayPal server, the
' code displays the request and response in the browser. If
' the response was a success, it displays the response
' parameters. If the response was an error, it displays the
' errors received.

' Called by GetTransactionDetails.html.

' Calls CallerService.asp and APIError.asp.
'----------------------------------------------------------------------------------
	On Error Resume Next
	Dim transactionID
	Dim nvpstr
	Dim resArray
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT


	transactionID	      = Request.QueryString("transactionID")
      gv_APIUserName	      = API_USERNAME
	gv_APIPassword	      = API_PASSWORD
	gv_APISignature         = API_SIGNATURE
	gv_Version		      = API_VERSION
	gv_SUBJECT              = SUBJECT
'----------------------------------------------------------------------------------
' Construct the request string that will be sent to PayPal.
' The variable nvpStr contains all the variables and is a
' name value pair string with & as a delimiter
'----------------------------------------------------------------------------------
	 nvpstr="&TRANSACTIONID="&transactionID 

	 nvpstr=URLEncode(nvpstr)

     If IsEmpty(gv_SUBJECT) Then
      
     nvpStr =nvpstr&"&USER=" & gv_APIUserName &_
                              "&PWD=" &gv_APIPassword &_
                              "&SIGNATURE=" & gv_APISignature &_
                              "&VERSION=" & gv_Version

     ElseIf IsEmpty(gv_APIUserName )and IsEmpty(gv_APIPassword) and IsEmpty(gv_APISignature) Then

     nvpStr =nvpstr&"&SUBJECT=" & gv_SUBJECT &_
                              "&VERSION=" & gv_Version

     Else
     
     nvpStr =nvpstr&"&USER=" & gv_APIUserName &_
                              "&PWD=" &gv_APIPassword &_
                              "&SIGNATURE=" & gv_APISignature &_
                              "&VERSION=" & gv_Version &_
                              "&SUBJECT=" & gv_SUBJECT 
     End If

'----------------------------------------------------------------------------------
' Make the API call to PayPal, using API signature.
' The API response is stored in an associative array called resArray
'----------------------------------------------------------------------------------
	Set resArray=hash_call("gettransactionDetails",nvpstr)
	ack = UCase(resArray("ACK"))
'----------------------------------------------------------------------------------
' Display the API request and API response back to the browser.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'----------------------------------------------------------------------------------
	If ack="SUCCESS" Then
		message="Transaction Details"
	Else
		 Set SESSION("nvpErrorResArray") = resArray
		 Response.Redirect "APIError.asp"
	End If

dim dovoidurl
dim docaptureurl
dim dorefundurl
dim amount

amount = resArray("AMT")
dovoidurl="DoVoid.asp?transactionID="&transactionID
docaptureurl="DoCapture.asp?transactionID="&transactionID &"&amount=" &amount
dorefundurl="RefundTransaction.asp?transactionID="&transactionID &"&amount=" &amount

'--------------------------------------------------------------------------------------------
' If there is no Errors Construct the HTML page with a table of variables Loop through the associative array
' for both the request and response and display the results.
'--------------------------------------------------------------------------------------------
%>

<html>
	<head>
		<title>Transaction details</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
	</head>
	<body alink="#0000FF" vlink="#0000FF">
		<center>
		<font size="2" color="black" face="Verdana"><b><%=message%></b></font>
<br>
			<table width="400" class="api">
			<%
                  DisplayAllResponse(resArray)
                  %>
			</table>


		</center>
	<a id="DoVoidLink" href='<%=dovoidurl%>'>Void</a> <a id="DoCaptureLink" href='<%=docaptureurl%>'>
	Capture</a> <a id="RefundTransactionLink"href='<%=dorefundurl%>'>Refund</a> <a href="javascript:history.back()">
	Back</a>

		<%
    If Err.Number <> 0 Then
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"TransactionDetails.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<br>
		<a class="home" id="CallsLink" href="Default.htm">Home</a>
	</body>
</html>
