<%@ CodePage=65001 %>

<% 

Response.Charset = "UTF-8" %>
<!-- #include file ="DisplayAllResponse.asp" -->
<%
'----------------------------------------------------------------------
'PayPal Express Checkout Example Step 2
'================================================
'Display the resulting authorization details from
'PayPal on a PayPal payment, and complete the
'payment authorization.  This script would be called
'when the buyer returns from PayPal and has authorized
'the payment
'----------------------------------------------------------------------
	On Error Resume Next
	Dim resArray
	Dim reqArray
	Dim message
	Dim totalAmt


	Set resArray	= SESSION("nvpResArray")
	
'----------------------------------------------------------------------
'Collect the necessary information to complete the
'authorization for the PayPal payment
'----------------------------------------------------------------------
	token			= SESSION("token")
	currCodeType	= SESSION("currencyCodeType")
	paymentAmount	= SESSION("paymentAmount")
	paymentType		= SESSION("PaymentType")
	payer_id		= SESSION("PayerID")
    itemAmt         = resArray.Item("ITEMAMT")
    taxAmt          = resArray.Item("TAXAMT")
    shippingAmt     = resArray.Item("SHIPPINGAMT")
    insuranceAmt    = resArray.Item("INSURANCEAMT")
    shipDiscAmt     = resArray.Item("SHIPDISCAMT")
    SHIPPINGCALCULATIONMODE = resArray.Item("SHIPPINGCALCULATIONMODE")
    'Calculating Order Total
    totalAmt        = CDbl(itemAmt)+CDbl(taxAmt)+CDbl(shippingAmt)+CDbl(insuranceAmt)+CDbl(shipDiscAmt)


'----------------------------------------------------------------------
 'Set the final URL to complete the authorization.  The
 'link will be displayed at the bottom the the browser for this
 'example.  The link would normally be displayed at the end of your checkout
 'and would finalize payment when clicked. 
 '----------------------------------------------------------------------
	final_url		="DoExpressCheckoutPayment.asp?token=" & token &_
					"&payerID="& payer_id &_
					"&paymentAmount="& totalAmt &_
					"&currCodeType="& currCodeType &_
					"&SHIPPINGCALCULATIONMODE="& SHIPPINGCALCULATIONMODE &_
					"&SHIPPINGOPTIONAMOUNT="& SHIPPINGOPTIONAMOUNT &_
					"&SHIPPINGOPTIONNAME ="& SHIPPINGOPTIONNAME  &_
					"&paymentType=" &paymentType

	message			= "Get Express checkout Details!"
'----------------------------------------------------------------------
'Display the API request and API response back to the browser using Diaplay.asp.
'If the response from PayPal was a success, display the response parameters
'If the response was an error, display the errors received
'----------------------------------------------------------------------

%>
<html>
	<head>
		<title>PayPal ASP - ExpressCheckout API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
		<!-- #include file ="CallerService.asp" -->
	</head>
	<body>
		<center>
			<form action='<%=final_url%>'>
				<table class="api">
				<tr>
                            <td colspan="2" align = center>
                                <input type="hidden" name="totalAmt" value="<%=totalAmt%>">
                                <font size=larger color=black face=Verdana><b>GetExpressCheckoutDetails </br></br> </b> </font>
                            </td>
                        </tr>
				<tr>
                        <%
                        DisplayAllResponse(resArray)
                        %>
                        </tr>
				<tr>
						<td colspan="2" class="header">
						<center>
							<input type="submit" value="Pay" />
						</center>
						</td>
				</tr>
				</table>
			</form>
		</center>
		<%
    If Err.Number <> 0 Then
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"GetExpressCheckoutDetails.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
	</body>
</html>
