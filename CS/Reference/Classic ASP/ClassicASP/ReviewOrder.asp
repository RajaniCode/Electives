<%@ CodePage=65001 %>
<!-- #include file ="CallerService.asp" -->

Response.Charset = "UTF-8"

<%
'----------------------------------------------------------------------
' PayPal Express Checkout Example
' ==============================
' Collect a transaction parameters from a webform and
' process a transaction using a PayPal account.

' This script would normally be called after a user clicks on
' a button during the checkout process to checkout
' using PayPal's Express Checkout
'----------------------------------------------------------------------


'----------------------------------------------------------------------
' Define the PayPal URL.  This is the URL that the buyer is
' first sent to to authorize payment with their paypal account
' change the URL depending if you are testing on the sandbox
' or going to the live PayPal site
' For the sandbox, the URL is
' https://www.sandbox.paypal.com/webscr&cmd=_express-checkout&token=
' For the live site, the URL is
' https://www.paypal.com/webscr&cmd=_express-checkout&token=
'------------------------------------------------------------------------
	On Error Resume Next
	PAYPAL_URL	= PAYPAL_EC_URL
'-----------------------------------------------------------------------------
' An express checkout transaction starts with a token, that
' identifies to PayPal your transaction
' In this example, when the script sees a token, the script
' knows that the buyer has already authorized payment through
' paypal.  If no token was found, the action is to send the buyer
' to PayPal to first authorize payment
'--------------------------------------------------------------------------
      Dim gv_APIUserName
	Dim gv_APIPassword
	Dim gv_APISignature
	Dim gv_Version
      Dim gv_SUBJECT

      gv_APIUserName	      = API_USERNAME
	gv_APIPassword	      = API_PASSWORD
	gv_APISignature         = API_SIGNATURE
	gv_Version		      = API_VERSION
	gv_SUBJECT              = SUBJECT
      


	If  Request.QueryString("token")="" Then
'---------------------------------------------------------------------------
' The servername and serverport tells PayPal where the buyer
' should be directed back to after authorizing payment.
' In this case, its the local webserver that is running this script
' Using the servername and serverport, the return URL is the first
' portion of the URL that buyers will return to after authorizing payment
'----------------------------------------------------------------------------
'---------------------------------------------------------------------------
' Parameters that is obtained from SetExpresscheckout page
' this is used to form the NVP string to be send to paypal site
'----------------------------------------------------------------------------
		
		url = GetURL()
		currencyCodeType=Request.Form("currencyCodeType")
		paymentType=Request.Form("paymentType")
		NAME=Request.Form("NAME")
        SHIPTOSTREET=Request.Form("SHIPTOSTREET")
        SHIPTOCITY=Request.Form("SHIPTOCITY")
        SHIPTOSTATE=Request.Form("SHIPTOSTATE")
        SHIPTOCOUNTRYCODE=Request.Form("SHIPTOCOUNTRYCODE")
        SHIPTOZIP=Request.Form("SHIPTOZIP")
        
        L_NAME0=Request.Form("L_NAME0")
        L_NUMBER0="1000"
        L_DESC0="Size: 8.8-oz"
        L_AMT0=Request.Form("L_AMT0")
        L_QTY0=Request.Form("L_QTY0")
        
        L_NAME1=Request.Form("L_NAME1")
        L_NUMBER1="10001"
        L_DESC1="Size: Two 24-piece boxes"
        L_AMT1=Request.Form("L_AMT1")
        L_QTY1=Request.Form("L_QTY1")
        
        L_ITEMWEIGHTVALUE1="0.5"
        L_ITEMWEIGHTUNIT1="lbs"
        TAXAMT="2.00"
        SHIPDISCAMT="-3.00"
        SHIPPINGAMT="8.00"
        CALLBACK="https://d-sjn-00513807/callback.pl"
        INSURANCEOPTIONOFFERED="true"
        INSURANCEAMT="1.00"
        L_SHIPPINGOPTIONISDEFAULT0="false"
        L_SHIPPINGOPTIONNAME0="Ground"
        L_SHIPPINGOPTIONLABEL0="UPS Ground 7 Days"
        L_SHIPPINGOPTIONAMOUNT0="3.00"
        L_SHIPPINGOPTIONISDEFAULT1="true"
        L_SHIPPINGOPTIONNAME1="UPS Air"
        L_SHIPPINGOPTIONlABEL1="UPS Next Day Air"
        L_SHIPPINGOPTIONAMOUNT1="8.00"
        CALLBACKTIMEOUT="4"
        ADDRESSOVERRIDE="1"

        dim ft,amt,maxamt
        ft =(L_QTY0 * L_AMT0)+(L_QTY1 * L_AMT1)
        amt=Round(ft+ 5.00 + 2.00 + 1.00, 2)
        maxamt=Round(amt + 25.00, 2)
'---------------------------------------------------------------------------
' The returnURL is the location where buyers return when a
' payment has been succesfully authorized.
' The cancelURL is the location buyers are sent to when they hit the
' cancel button during authorization of payment during the PayPal flow
'---------------------------------------------------------------------------

returnURL	= url & "ReviewOrder.asp?currencyCodeType=" &  currencyCodeType & _
					"&paymentAmount=" & amt & _
					"&paymentType=" &paymentType 
		cancelURL	= url & "SetExpressCheckout.asp?paymentType="&paymentType

'---------------------------------------------------------------------------
' Construct the parameter string that describes the PayPal payment
' the varialbes were set in the web form, and the resulting string
' is stored in nvpstr
'---------------------------------------------------------------------------

					
										
	 nvpstr		     ="&" &Server.URLEncode("ADDRESSOVERRIDE")&"=" & Server.URLEncode(ADDRESSOVERRIDE) & _
					"&" &Server.URLEncode("SHIPTONAME")&"=" & Server.URLEncode(NAME) & _
					"&" &Server.URLEncode("SHIPTOSTREET")&"=" & Server.URLEncode(SHIPTOSTREET) & _
					"&" &Server.URLEncode("SHIPTOCITY")&"=" & Server.URLEncode(SHIPTOCITY) & _
					"&" &Server.URLEncode("SHIPTOSTATE")&"=" & Server.URLEncode(SHIPTOSTATE) & _
					"&" &Server.URLEncode("SHIPTOCOUNTRYCODE")&"=" & Server.URLEncode(SHIPTOCOUNTRYCODE) & _
					"&" &Server.URLEncode("SHIPTOZIP")&"=" & Server.URLEncode(SHIPTOZIP) & _
					"&" &Server.URLEncode("L_NAME0")&"=" & Server.URLEncode(L_NAME0) & _
					"&" &Server.URLEncode("L_NAME1")&"=" & Server.URLEncode(L_NAME1) & _
					"&" &Server.URLEncode("L_AMT0")&"=" & Server.URLEncode(L_AMT0) & _
					"&" &Server.URLEncode("L_AMT1")&"=" & Server.URLEncode(L_AMT1) & _
					"&" &Server.URLEncode("L_QTY0")&"=" & Server.URLEncode(L_QTY0) & _
					"&" &Server.URLEncode("L_QTY1")&"=" & Server.URLEncode(L_QTY1) & _
					"&" &Server.URLEncode("MAXAMT")&"=" & Server.URLEncode(maxamt) & _
					"&" &Server.URLEncode("AMT")&"=" & Server.URLEncode(amt) & _
					"&" &Server.URLEncode("ITEMAMT")&"=" & Server.URLEncode(ft) & _
					"&" &Server.URLEncode("CALLBACKTIMEOUT")&"=" & Server.URLEncode(CALLBACKTIMEOUT) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONAMOUNT1")&"=" & Server.URLEncode(L_SHIPPINGOPTIONAMOUNT1) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONlABEL1")&"=" & Server.URLEncode(L_SHIPPINGOPTIONlABEL1) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONNAME1")&"=" & Server.URLEncode(L_SHIPPINGOPTIONNAME1) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONISDEFAULT1")&"=" & Server.URLEncode(L_SHIPPINGOPTIONISDEFAULT1) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONAMOUNT0")&"=" & Server.URLEncode(L_SHIPPINGOPTIONAMOUNT0) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONLABEL0")&"=" & Server.URLEncode(L_SHIPPINGOPTIONLABEL0) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONNAME0")&"=" & Server.URLEncode(L_SHIPPINGOPTIONNAME0) & _
					"&" &Server.URLEncode("L_SHIPPINGOPTIONISDEFAULT0")&"=" & Server.URLEncode(L_SHIPPINGOPTIONISDEFAULT0) & _
					"&" &Server.URLEncode("INSURANCEAMT")&"=" & Server.URLEncode(INSURANCEAMT) & _
					"&" &Server.URLEncode("INSURANCEOPTIONOFFERED")&"=" & Server.URLEncode(INSURANCEOPTIONOFFERED) & _
					"&" &Server.URLEncode("CALLBACK")&"=" & Server.URLEncode(CALLBACK) & _
					"&" &Server.URLEncode("SHIPPINGAMT")&"=" & Server.URLEncode(SHIPPINGAMT) & _
					"&" &Server.URLEncode("SHIPDISCAMT")&"=" & Server.URLEncode(SHIPDISCAMT) & _
					"&" &Server.URLEncode("TAXAMT")&"=" & Server.URLEncode(TAXAMT) & _
					"&" &Server.URLEncode("L_NUMBER0")&"=" & Server.URLEncode(L_NUMBER0) & _
					"&" &Server.URLEncode("L_DESC0")&"=" & Server.URLEncode(L_DESC0) & _
					"&" &Server.URLEncode("L_NUMBER1")&"=" & Server.URLEncode(L_NUMBER1) & _
					"&" &Server.URLEncode("L_DESC1")&"=" & Server.URLEncode(L_DESC1) & _
					"&" &Server.URLEncode("L_ITEMWEIGHTVALUE1")&"=" & Server.URLEncode(L_ITEMWEIGHTVALUE1) & _
					"&" &Server.URLEncode("L_ITEMWEIGHTUNIT1")&"=" & Server.URLEncode(L_ITEMWEIGHTUNIT1) & _
					"&" &server.URLEncode("RETURNURL")&"=" & Server.URLEncode(returnURL) & _
					"&" &Server.URLEncode("CANCELURL")&"=" &Server.URLEncode(cancelURL) & _ 
					"&" &server.UrlEncode("CURRENCYCODE")&"=" & Server.URLEncode(currencyCodeType) & _
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

                               
'--------------------------------------------------------------------------- 
' Make the call to PayPal to set the Express Checkout token
' If the API call succeded, then redirect the buyer to PayPal
' to begin to authorize payment.  If an error occured, show the
' resulting errors
'---------------------------------------------------------------------------
		Set resArray=hash_call("SetExpressCheckout",nvpstr)
		Set SESSION("nvpResArray")=resArray
		ack = UCase(resArray("ACK"))
		response.Write(ack)

		If ack="SUCCESS" Then
				' Redirect to paypal.com here
				token = resArray("TOKEN")
				payPalURL = PAYPAL_URL & "?cmd=_express-checkout&token=" & token
				ReDirectURL(payPalURL)
		Else  
				message="<font color=red>PayPal API has returned an error!</font>"	          
				SESSION("msg")=message
				Set SESSION("nvpErrorResArray") = resArray
		        Response.Redirect "APIError.asp"
		End If

	Else 

'---------------------------------------------------------------------------
' At this point, the buyer has completed in authorizing payment
' at PayPal.  The script will now call PayPal with the details
' of the authorization, incuding any shipping information of the
' buyer.  Remember, the authorization is not a completed transaction
' at this state - the buyer still needs an additional step to finalize
' the transaction
'---------------------------------------------------------------------------
		SESSION("token") = Request.Querystring("TOKEN")
		SESSION("currencyCodeType") = Request.Querystring("currencyCodeType")
		SESSION("paymentAmount") = Request.Querystring("paymentAmount")
		SESSION("PaymentType")= Request.Querystring("PaymentType")
		SESSION("PayerID")= Request.Querystring("PayerID")
            SESSION("ITEMAMT")= Request.Querystring("ITEMAMT")

 '---------------------------------------------------------------------------
 'Build a second API request to PayPal, using the token as the
    'ID to get the details on the payment authorization
'---------------------------------------------------------------------------
		nvpstr="&TOKEN="&Request.Querystring("TOKEN")& _
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

	      
'---------------------------------------------------------------------------
' Make the API call and store the results in an array.  If the
    'call was a success, show the authorization details, and provide
   ' an action to complete the payment.  If failed, show the error
'---------------------------------------------------------------------------
		Set resArray=hash_call("GetExpressCheckoutDetails",nvpstr)
		ack = UCase(resArray("ACK"))
		Set SESSION("nvpResArray")=resArray
		

		
	If UCase(ack)="SUCCESS" Then
		Response.Redirect "GetExpressCheckoutDetails.asp"
	Else  
		SESSION("msg")="<font color=red>Review Order.PayPal API has returned an error!</font>"
		Set SESSION("nvpErrorResArray") = resArray
		Response.Redirect "APIError.asp"

	
	End If	
	
End If
    If Err.Number <> 0 Then 
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"RevievOrder.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If

%>