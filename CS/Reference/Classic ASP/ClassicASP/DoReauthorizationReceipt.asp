<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->
<%

Response.Charset = "UTF-8"


	Dim authorizationID
	Dim amount
	Dim currencyCode
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT



	authorizationID		= Request.QueryString ("authorizationID")
	amount			= Request.QueryString ("amount")
	currencyCode		= Request.QueryString ("currency")
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
	nvpstr	=	"&AuthorizationID=" &authorizationID & _
				"&AMT="&amount &_
				"&CURRENCYCODE="&currencyCode 

	nvpstr	=	URLEncode(nvpstr)

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
	Set resArray	= hash_call("DoReauthorization",nvpstr)
	ack =  UCase(resArray("ACK"))
'----------------------------------------------------------------------------------
' Display the API request and API response back to the browser.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'----------------------------------------------------------------------------------
	If ack="SUCCESS" Then
		Message = " ReAuthorization Details!"
	Else
		 Set SESSION("nvpErrorResArray") = resArray
		 Response.Redirect "APIError.asp"
	End If

%>
<html>
	<head>
		<title>PayPal ASP - DoReAuthorization API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
          <center>
			<font size="2" color="black" face="Verdana"><b>Do ReAuthorization Receipt</b></font>
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
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"DoReauthorizationReceipt.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<a class="home" id="CallsLink" href="Default.htm">Home</a>
	</body>
</html>
