<!-- #include file ="CallerService.asp" -->
<!-- #include file ="DisplayAllResponse.asp" -->
<%

	Response.Buffer = True
'-----------------------------------------------------------------------------
' ManageRecurringPaymentsProfileStatusReceipt.asp

' Submits a credit card transaction to PayPal using a
' ManageRecurringPaymentsProfileStatus request.

' The code collects transaction parameters from the form
' displayed by ManageRecurringPaymentsProfileStatus.asp then constructs and sends
' the ManageRecurringPaymentsProfileStatus request string to the PayPal server.


' After the PayPal server returns the response, the code
' displays the API request and response in the browser.
' If the response from PayPal was a success, it displays the
' response parameters. If the response was an error, it
' displays the errors.

' Called by ManageRecurringPaymentsProfileStatus.asp.

' Calls CallerService.asp and APIError.asp.

'-----------------------------------------------------------------------------
	Dim profileid
	Dim action
	Dim nvpstr
	Dim resArray
	Dim ack
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT

	
      profileid			    = Request.Form("profileID")
	action			    = Request.Form("Action")
      gv_APIUserName	          = API_USERNAME
	gv_APIPassword	          = API_PASSWORD
	gv_APISignature             = API_SIGNATURE
	gv_Version		          = API_VERSION
	gv_SUBJECT                  = SUBJECT
	
	
'-----------------------------------------------------------------------------
' Construct the request string that will be sent to PayPal.
' The variable $nvpstr contains all the variables and is a
' name value pair string with &as a delimiter
'-----------------------------------------------------------------------------
	nvpstr	=	"&ACTION="&action &_
				"&PROFILEID="&profileid 
				
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
	Set resArray	= hash_call("ManageRecurringPaymentsProfileStatus",nvpstr)
	ack = UCase(resArray("ACK"))
'----------------------------------------------------------------------------------
' Display the API request and API response back to the browser.
' If the response from PayPal was a success, display the response parameters
' If the response was an error, display the errors received
'----------------------------------------------------------------------------------
	If ack="SUCCESS" Then
		 message="Thank you for your payment!"
	Else
		 Set SESSION("nvpErrorResArray") = resArray
		 Response.Redirect "APIError.asp?RecurringPage=RecurringPayments.asp"
	End If
	
	dim getrecurringpaymentsprofileurl
    dim profilid
    profileid=resArray("PROFILEID")
    getrecurringpaymentsprofileurl="GetRecurringPaymentsProfileDetails.asp?profileID="&profileid


%>
<html>
	<head>
		<title>PayPal ASP SDK - CreateRecurringPaymentsProfile API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
	</head>
	<body alink="#0000FF" vlink="#0000FF">
		<center>
			<font size="2" color="black" face="Verdana"><b>Manage Recurring Payments Profile Status</b></font>
			<br>
			</br>
                  <table width="400" class="api">
                  <%
                  DisplayAllResponse(resArray)
                  %>
                  </table>
			
		</center>
		<%
    If Err.Number <> 0 Then
    
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"ManageRecurringPaymentsProfileStatusReceipt.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<br>
		<CENTER>
			<a id="GetRecurringPaymentsProfileDetails" href='<%=getrecurringpaymentsprofileurl%>'>
				GetRecurringPaymentsProfileDetails</a>
		</CENTER>
		<a class="home" id="CallsLink" href="RecurringPayments.asp"><font color="blue"><B>Recurring 
					Payments Home<B><font></a>
	</body>
</html>
