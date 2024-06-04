<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->

<%

Response.Charset = "UTF-8"



	Response.Buffer = True
'-----------------------------------------------------------------------------
' DoDirectPaymentReceipt.asp

' Submits a credit card transaction to PayPal using a
' DoDirectPayment request.

' The code collects transaction parameters from the form
' displayed by DoDirectPayment.asp then constructs and sends
' the DoDirectPayment request string to the PayPal server.
' The paymentType variable becomes the PAYMENTACTION parameter
' of the request string.

' After the PayPal server returns the response, the code
' displays the API request and response in the browser.
' If the response from PayPal was a success, it displays the
' response parameters. If the response was an error, it
' displays the errors.

' Called by DoDirectPayment.asp.

' Calls CallerService.asp and APIError.asp.

'-----------------------------------------------------------------------------
	Dim firstName
	Dim lastName
	Dim creditCardType
	Dim creditCardNumber
	Dim expDateMonth
	Dim expDateYear
	Dim padDate
	Dim cvv2Number
	Dim address1
	Dim address2
	Dim city
	Dim state
	Dim zip
	Dim amount
	Dim currencyCode
	Dim paymentType
	Dim nvpstr
	Dim resArray
	Dim ack
	Dim message
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT
      


	firstName			= Request.Form("firstName")
	lastName			= Request.Form("lastName")
	creditCardType		= Request.Form("creditCardType")
	creditCardNumber	      = Request.Form("creditCardNumber")
	expDateMonth		= Request.Form("expDateMonth")
	expDateYear			= Request.Form("expDateYear")
	padDate			= expDateMonth&expDateYear
	cvv2Number			= Request.Form("cvv2Number")
	address1			= Request.Form("address1")
	address2			= Request.Form("address2")
	city				= Request.Form("city")
	state				= Request.Form("state")
	zip				= Request.Form("zip")
	amount			= Request.Form("amount")
	'currencyCode		=Request.Form("currency")
	currencyCode		= "USD"
	paymentType			=Request.Form("paymentType")
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
	nvpstr	=	"&PAYMENTACTION=" &paymentType & _
				"&AMT="&amount &_
				"&CREDITCARDTYPE="&creditCardType &_
				"&ACCT="&creditCardNumber & _
				"&EXPDATE=" & padDate &_
				"&CVV2=" & cvv2Number &_
				"&FIRSTNAME=" & firstName &_
				"&LASTNAME=" & lastName &_
				"&STREET=" & address1 &_
				"&CITY=" & city &_
				"&STATE=" & state &_
				"&ZIP=" &zip &_
				"&COUNTRYCODE=US" &_
				"&CURRENCYCODE=" & currencyCode
                       
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
	Set resArray	= hash_call("doDirectPayment",nvpstr)
	ack = UCase(resArray("ACK"))
'----------------------------------------------------------------------------------
' Display the API request and API response back to the browser.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'----------------------------------------------------------------------------------
	If ack="SUCCESS" Then
		message="Thank you for your payment!"

      ElseIf ack="SUCCESSWITHWARNING" Then
           message="Thank you for your payment!"
	Else
		 Set SESSION("nvpErrorResArray") = resArray
		 Response.Redirect "APIError.asp"
	End If

%>
<html>
	<head>
		<title>PayPal ASP SDK - DoDirectPayment API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
	</head>
	<body alink="#0000FF" vlink="#0000FF">
		<center>
			<font size="2" color="black" face="Verdana"><b>Do Direct Payment</b></font>
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
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"DoDirectPaymentReceipt.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<br>
		<a class="home" id="CallsLink" href="default.htm"><font color="blue"><B>Home<B><font></a>
	</body>
</html>
