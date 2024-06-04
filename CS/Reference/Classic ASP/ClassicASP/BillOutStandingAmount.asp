<%
'-------------------------------------------------------------------------------------------
' BillOutStandingAmount.asp
' ===================
' This is the main web page for the BillOutStandingAmount sample.
' This page allows the user to enter profileid and amount

' When the user clicks the Submit button, BillOutStandingAmount.asp
' is called.

' Called by default.htm.

' Calls BillOutStandingAmountReceipt.asp.
'-------------------------------------------------------------------------------------------

On Error Resume Next

%>
<html>
	<head>
		<title>PayPal Classic ASP NVP SDK - BillOutStanding Amount API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css">
			<script src="CCGenerate.js">
			</script>
	</head>
	<body onload="generateCC()">
		<form id="frmDCC" name="frmDCC" action="BillOutStandingAmountReceipt.asp" method="POST">
			<center>
				<font size="2" color="black" face="Verdana"><b>Bill Out Standing Amount</b></font>
				<br>
				</br>
				<table class="api">
					<tr>
					</tr>
					<tr>
						<td class="field">
							Profile ID:
						</td>
						<td>
							<input type="text" size="30" maxlength="32" name="profileID" value="">(Required)
						</td>
					</tr>
					<tr>
						<td class="field">
							Amount:
						</td>
						<td>
							<input type="text" size="30" maxlength="32" name="Amount" value="">
						</td>
					</tr>
					<tr>
						<td class="field">
						</td>
						<td>
							<input type="Submit" value="Submit"></td>
					</tr>
				</table>
			</center>
		</form>
		<% 
    If Err.Number <> 0 Then 
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"BillOutStandingAmount.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<a class="home" id="CallsLink" href="RecurringPayments.asp"><font color="blue"><B>Recurring 
					Payments Home<B><font></a>
	</body>
</html>
