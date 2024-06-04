<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->
<%

Response.Charset = "UTF-8"
'-------------------------------------------------------------------------------------------
' PayPal Express Checkout Example Step 3
' ======================================================================
' Complete the final payment for PayPal.  This
' page would normally be run to complete the
' payment with PayPal, and display the result
' back to the buyer
'-------------------------------------------------------------------------------------------
	On Error Resume Next
	Dim token
	Dim payerID
	Dim paymentAmount
	Dim currCodeType
	Dim paymentType
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT
'-------------------------------------------------------------------------------------------
' Gather the information to make the final call to
' finalize the PayPal payment.  The variable nvpstr
' holds the name value pairs
'-------------------------------------------------------------------------------------------

	token			= SESSION("token")
	currCodeType	= SESSION("currencyCodeType")
	'paymentAmount	= SESSION("paymentAmount")
	paymentAmount	= Request.QueryString("totalAmt")
	paymentType		= SESSION("PaymentType")
	payerID		= SESSION("PayerID")
      gv_APIUserName	      = API_USERNAME
	gv_APIPassword	      = API_PASSWORD
	gv_APISignature         = API_SIGNATURE
	gv_Version		      = API_VERSION
	gv_SUBJECT              = SUBJECT


	nvpstr			="&" &Server.URLEncode("TOKEN") & "=" &Server.URLEncode(token)   & _
	                        "&" &Server.URLEncode("PAYERID")&"=" &Server.URLEncode(payerID)  & _
                              "&" &Server.URLEncode("AMT") &"=" &Server.URLEncode(paymentAmount) & _
                              "&" &Server.URLEncode("CURRENCYCODE")&"=" &Server.URLEncode(currCodeType) & _
                              "&" &Server.URLEncode("PAYMENTACTION")&"=" & Server.URLEncode(paymentType) 
 
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


'-------------------------------------------------------------------------------------------
' Make the call to PayPal to finalize payment
' If an error occured, show the resulting errors
'-------------------------------------------------------------------------------------------
	Set resArray=hash_call("DoExpressCheckoutPayment",nvpstr)

	ack = UCase(resArray("ACK"))
'-------------------------------------------------------------------------------------------
' Display the API request and API response back to the browser using APIError.asp.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'-------------------------------------------------------------------------------------------
	If ack=UCase("Success") Then
		message			= "Thank you for your payment!"
	Else
		 Set SESSION("nvpErrorResArray") = resArray
		 Response.Redirect "APIError.asp"
	End If



'--------------------------------------------------------------------------------------------
' If there is no Errors Construct the HTML page with a table of variables Loop through the associative array
' for both the request and response and display the results.
'--------------------------------------------------------------------------------------------
%>

<html>
	<html>
		<head>
			<title>PayPal ASP SDK - DoExpressCheckoutPayment API</title>
			<link href="sdk.css" rel="stylesheet" type="text/css" />
		</head>
		<body alink="#0000FF" vlink="#0000FF">
			<center>
				<font size="2" color="black" face="Verdana"><b>DoExpressCheckoutPayment</b></font>
				<br><br>
				<b><%=message%></b><br>
				<br>
				<table class="api">
					<%
                                 DisplayAllResponse(resArray)
                              %>
				</table>
			</center>
			<%
    If Err.Number <> 0 Then
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"DoExpressCheckoutPayment.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
			<br>
			<a class="home" href="default.htm"><font color="blue"><B>Home<B><font></a>
		</body>
	</html>
