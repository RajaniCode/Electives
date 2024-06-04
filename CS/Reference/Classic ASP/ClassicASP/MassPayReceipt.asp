﻿<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->
<%

Response.Charset = "UTF-8"

	Dim emailSubject
	Dim receiverType

	Dim receiveremail1
	Dim amount1
	Dim uniqueID1
	Dim note1

	Dim receiveremail2
	Dim amount2
	Dim uniqueID2
	Dim note2

	Dim receiveremail3
	Dim amount3
	Dim uniqueID3
	Dim note3

	Dim message
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT

	emailSubject		= Request.QueryString ("emailSubject")
	receiverType		= Request.QueryString ("receiverType")

	receiveremail1		= Request.QueryString ("receiveremail1")
	amount1			= Request.QueryString ("amount1")
	uniqueID1			= Request.QueryString ("uniqueID1")
	note1				= Request.QueryString ("note1")

	receiveremail2		= Request.QueryString ("receiveremail2")
	amount2			= Request.QueryString ("amount2")
	uniqueID2			= Request.QueryString ("uniqueID2")
	note2				= Request.QueryString ("note2")

	receiveremail3		= Request.QueryString ("receiveremail3")
	amount3			= Request.QueryString ("amount3")
	uniqueID3			= Request.QueryString ("uniqueID3")
	note3				= Request.QueryString ("note3")
      gv_APIUserName	      = API_USERNAME
	gv_APIPassword	      = API_PASSWORD
	gv_APISignature         = API_SIGNATURE
	gv_Version		      = API_VERSION
	gv_SUBJECT              = SUBJECT
      


'-----------------------------------------------------------------------------
' Construct the request string that will be sent to PayPal.
' The variable $nvpstr contains all the variables and is a
' name value pair string with &as a delimiter
'-----------------------------------------------------------------------------



	nvpstr	=	"&EMAILSUBJECT=" &emailSubject & _
				"&RECEIVERTYPE="&receiverType &_

				"&L_EMAIL0="&receiveremail1 &_
				"&L_Amt0="&amount1 & _
				"&L_UNIQUEID0=" &uniqueID1 &_
				"&L_NOTE0=" &note1 &_

				"&L_EMAIL1="&receiveremail2 &_
				"&L_Amt1="&amount2 & _
				"&L_UNIQUEID1=" &uniqueID2 &_
				"&L_NOTE1=" &note2 &_

				"&L_EMAIL2="&receiveremail3 &_
				"&L_Amt2="&amount3 & _
				"&L_UNIQUEID2=" &uniqueID3&_
				"&L_NOTE=" &note3 

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

'-----------------------------------------------------------------------------
' Make the API call to PayPal,using API signature.
' The API response is stored in an associative array called gv_resArray
'-----------------------------------------------------------------------------
	Set resArray	= hash_call("MassPay",nvpstr)
	ack = UCase(resArray("ACK"))
'----------------------------------------------------------------------------------
' Display the API request and API response back to the browser.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'----------------------------------------------------------------------------------
	If ack="SUCCESS" Then
		message= " MassPay has been completed successfully! "
	Else
	      Set SESSION("nvpErrorResArray") = resArray
	      Response.Redirect "APIError.asp"
	End If

%>

<html>
<head>
		<title>PayPal ASP SDK - MassPay API </title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
</head>
<body alink="#0000FF" vlink="#0000FF">
  <center>
			<font size="2" color="black" face="Verdana"><b>MassPay Receipt</b></font>
			<br>
			<br>
			<b>
				<%=message%>
			</b>
			<br>
			<br>
			<table width="400" class="api">
			<%
                  DisplayAllResponse(resArray)
                  %>
			</table>

	</center>
    <%
    If Err.Number <> 0 Then
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"MassPayReceipt.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
<br>
<a class="home"  id="CallsLink" href="default.htm">Home</a>
</body>
</html>


