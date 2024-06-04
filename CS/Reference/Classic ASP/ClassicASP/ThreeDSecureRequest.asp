<%
'-------------------------------------------------------------------------------------------
' DoDirectPayment.asp
' ===================
' This is the main web page for the DoDirectPayment sample.
' This page allows the user to enter name, address, amount,
' and credit card information. It also accept input variable
' paymentType which becomes the value of the PAYMENTACTION
' parameter.

' When the user clicks the Submit button, DoDirectPaymentReceipt.asp
' is called.

' Called by default.htm.

' Calls DoDirectPaymentReceipt.asp.
'-------------------------------------------------------------------------------------------

On Error Resume Next
Dim paymentType
paymentType = Request.QueryString("paymentType") 

%>
<html>
	<head>
		<title>PayPal Classic ASP NVP SDK - DoDirectPayment API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css">
			<script src="CCGenerate.js">
			</script>
	</head>
	<body onload="generateCC()">
		<form id="frmDCC" name="frmDCC" action="ResponseThreeD.asp" method="POST">
			<input type=hidden name=paymentType value='<%=paymentType%>' >
			<center>
				<font size="2" color="black" face="Verdana"><b>3D Secure Payment</b></font>
				<table class="api">
					<tr>
					</tr>
					<tr>
						<td class="field">
							First Name:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="firstName" value="John"></td>
					</tr>
					<tr>
						<td class="field">
							Last Name:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="lastName" value="Doe"></td>
					</tr>
					<tr>
						<td class="field">
							Card Type:</td>
						<td>
							<select name="creditCardType" onchange="generateCC()">
								<option value="Visa" selected>Visa</option>
								<option value="MasterCard">MasterCard</option>
								<option value="Maestro">Maestro</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="field">
							Card Number:</td>
						<td>
							<input type="text" size="19" maxlength="19" name="creditCardNumber" value=""></td>
					</tr>
                              <tr>
						<td class="field">
							Start Date:</td>
						<td>
							<select name="startDateMonth">
								<option value="01">01</option>
								<option value="02">02</option>
								<option value="03">03</option>
								<option value="04">04</option>
								<option value="05">05</option>
								<option value="06">06</option>
								<option value="07">07</option>
								<option value="08">08</option>
								<option value="09">09</option>
								<option value="10">10</option>
								<option value="11">11</option>
								<option value="12">12</option>
							</select>
							<select name="startDateYear">
								<option value="2004">2004</option>
								<option value="2005">2005</option>
								<option value="2006">2006</option>
								<option value="2007">2007</option>
								<option value="2008">2008</option>
								<option value="2009"selected>2009</option>
								<option value="2010" >2010</option>
								<option value="2011">2011</option>
								<option value="2012">2012</option>
								<option value="2013">2013</option>
								<option value="2014">2014</option>
								<option value="2015">2015</option>
							</select>
						</td>
					</tr>

					<tr>
						<td class="field">
							Expiration Date:</td>
						<td>
							<select name="expDateMonth">
								<option value="01">01</option>
								<option value="02">02</option>
								<option value="03">03</option>
								<option value="04">04</option>
								<option value="05">05</option>
								<option value="06">06</option>
								<option value="07">07</option>
								<option value="08">08</option>
								<option value="09">09</option>
								<option value="10">10</option>
								<option value="11">11</option>
								<option value="12">12</option>
							</select>
							<select name="expDateYear">
								<option value="2004">2004</option>
								<option value="2005">2005</option>
								<option value="2006">2006</option>
								<option value="2007">2007</option>
								<option value="2008">2008</option>
								<option value="2009">2009</option>
								<option value="2010">2010</option>
								<option value="2011" selected>2011</option>
								<option value="2012">2012</option>
								<option value="2013">2013</option>
								<option value="2014">2014</option>
								<option value="2015">2015</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="field">
							Card Verification Number:</td>
						<td>
							<input type="text" size="3" maxlength="4" name="cvv2Number" value="962"></td>
					</tr>
					<tr>
						<td align="right"><br>
							<b>Billing Address:</b></td>
						</td>
					</tr>
					<tr>
						<td class="field">
							Address 1:
						</td>
						<td>
							<input type="text" size="25" maxlength="100" name="address1" value="123 Fake St"></td>
					</tr>
					<tr>
						<td class="field">
							Address 2:
						</td>
						<td>
							<input type="text" size="25" maxlength="100" name="address2">(optional)</td>
					</tr>
					<tr>
						<td class="field">
							City:
						</td>
						<td>
							<input type="text" size="25" maxlength="40" name="city" value="London"></td>
					</tr>
					<tr>
						<td class="field">
							State:
						</td>
                                    <td>
							<input type="text" size="25" maxlength="40" name="state" value="London">
                                    </td>

						
					</tr>
					<tr>
						<td class="field">
							ZIP Code:
						</td>
						<td>
							<input type="text" size="10" maxlength="10" name="zip" value="WC2H7LA">(5 or 9 
							digits)
						</td>
					</tr>
					<tr>
						<td class="field">
							Country:
						</td>
						<td>
							United Kingdom
						</td>
					</tr>
					<tr>
						<td class="field">
							Amount:</td>
						<td>
							<input type="text" size="4" maxlength="7" name="amount" value="1.00"> GBP 
							<!--select name="currency">
								<option value="USD">USD</option>
								<option value="GBP">GBP</option>
								<option value="EUR">EUR</option>
								<option value="JPY">JPY</option>
								<option value="CAD">CAD</option>
								<option value="AUD">AUD</option>
							</select-->
							<b>(3D Secure Payment only supports GBP at this time)</b>
						</td>
					</tr>
					<tr>
						<td align="right"><br>
							<b>3D Secure:</b></td>
						</td>
					</tr>
					<tr>
						<td class="field">
							Eci Flag:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="eciflag" value="" ID="Text2"></td>
					</tr>
					<tr>
						<td class="field">
							Cavv:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="cavv" value="" ID="Text3"></td>
					</tr>
					<tr>
						<td class="field">
							Xid:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="xid" value="" ID="Text4"></td>
					</tr>
					<tr>
						<td class="field">
							MPIVendor3DS:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="mpivendor3ds" value="" ID="Text5"></td>
					</tr>
					<tr>
						<td class="field">
							AuthStatus3D:</td>
						<td>
							<input type="text" size="30" maxlength="32" name="authstatus3d" value="" ID="Text6"></td>
					</tr>
					<tr>
						<td class="field">
						</td>
						<td>
							<input type="Submit" value="Submit"></td>
					</tr>
				</table>
			</center>
			<a class="home" id="CallsLink" href="Default.htm">Home</a>
		</form>
		<% 
    If Err.Number <> 0 Then 
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"ThreeDSecureRequest.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
	</body>
</html>
