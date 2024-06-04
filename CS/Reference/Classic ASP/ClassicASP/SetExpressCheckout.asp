<%@ CodePage=65001%> 





<!-- #include file ="Constants.asp" -->
<%

Response.Charset = "UTF-8"  

'-------------------------------------------------------------------------------------------
' SetExpressCheckout.asp
'=======================
' This is the main web page for the Express Checkout sample.
' The page allows the user to enter amount and currency type.
' It also accept input variable paymentType which becomes the
' value of the PAYMENTACTION parameter.

' When the user clicks the Submit button, ReviewOrder.asp is called.

' Called by Default.htm.

' Calls ReviewOrder.asp.
'-------------------------------------------------------------------------------------------
On Error Resume Next
%>
<html>
	<head>
		<title>PayPal NVP Web Samples Using ASP - SetExpressCheckout</title>
		<link href="sdk.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		<center>
			<form action="ReviewOrder.asp" method="POST">
				<input type="hidden" name="paymentType" value='<%=Request.QueryString("paymentType")%>'>
				<span id="apiheader">SetExpressCheckout</span>
				<table class="api">
					<tr>
						<td colspan="2">
							<center>
								You must be logged into <a href='<%=ECURLLOGIN%>' target="_blank">Developer 
									Central</a>
							</center>
						</td>
					</tr>
					</table>
				<table class="api">
        	    <th>Shopping cart Products:</th>	
        	        <tr>
					        <td class="field">
						        CDs:</td>
					        <td>
						        <input type="text" size="30" maxlength="32" name="L_NAME1" id="L_NAME1" value="Path To Nirvana"></td>
						<td class="field">
							Amount:</td>
						<td>
					        <input type="text" name="L_AMT1" size="5" maxlength="32" id="L_AMT1" value="39.00"> </td>
		
					    <td class="field">
					        Quantity:   </td>
				        <td>
					         <input type="text" size="3" maxlength="32" name="L_QTY1" id="L_QTY1" value="2"> </td>
					</tr>
					<tr>
					    <td class="field">
					        Books:</td>
				        <td>
					        <input type="text" size="30" maxlength="32" name="L_NAME0" id="L_NAME0" value="Know Thyself"> </td>

			            <td class="field">
				            Amount: <br /> </td>
			            <td>
				            <input type="text" name="L_AMT0" size="5" maxlength="32" id="L_AMT0" value="9.00"> </td>

				         <td class="field">
				            Quantity:   </td>
			                 <td>  <input type="text" size="3" maxlength="32" name="L_QTY0" id="L_QTY0" value="2"> </td>
					</tr>

		            <tr>
		               <td class="field">
				        Currency: <br /> </td>
			            <td>
		                    <select name="currencyCodeType" id="currencyCodeType">
				                <option value="USD">USD</option>
				                <option value="GBP">GBP</option>
				                <option value="EUR">EUR</option>
				                <option value="JPY">JPY</option>
				                <option value="CAD">CAD</option>
				                <option value="AUD">AUD</option>
			                </select>     
			            </td>
	                  </tr>
	          </table>
			<br/><br/>
	         <table class="api">
	            <th>Ship To:</th>

	            <tr>
			        <td class="field">
				        Name:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="NAME" value="True Seeker" id="NAME"></td>
		        </tr>
		        <tr>
			        <td class="field">
				        Street:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="SHIPTOSTREET" id="SHIPTOSTREET" value="111, Bliss Ave"></td>
		        </tr>
		        <tr>
			       <td class="field">
				        City:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="SHIPTOCITY" id="SHIPTOCITY" value="San Jose"></td>
		        </tr>
		        
		        <tr>
			        <td class="field">
				        State:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="SHIPTOSTATE" id="SHIPTOSTATE" value="CA"></td>
		        </tr>
		        <tr>
			        <td class="field">
				        Country:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="SHIPTOCOUNTRYCODE" id="SHIPTOCOUNTRYCODE" value="US"></td>
		        </tr>
		        <tr>
			        <td class="field">
				        Zip Code:</td>
			        <td>
				        <input type="text" size="30" maxlength="32" name="SHIPTOZIP" id="SHIPTOZIP" value="95128"></td>
		            </tr>
					<tr>
						<td>
							<input type="image" name="submit" src="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" />
						</td>
						<td>
							Save time. Pay securely without sharing your financial information.
						</td>
					</tr>
				</table>
		</center>
	<%
    If Err.Number <> 0 Then
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"SetExpressCheckout.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<br>
		<a class="home" id="CallsLink" href="Default.htm">Home</a>
	</body>
</html>
