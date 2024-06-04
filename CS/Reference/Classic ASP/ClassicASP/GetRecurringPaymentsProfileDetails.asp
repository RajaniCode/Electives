<%
'-------------------------------------------------------------------------------------------
' GetRecurringPaymentsProfileDetails.asp
' ===================
' This is the main web page for the GetRecurringPaymentsProfileDetails sample.
' This page allows the user to enter profileid

' When the user clicks the Submit button, GetRecurringPaymentsProfileDetails.asp
' is called.

' Called by default.htm.

' Calls GetRecurringPaymentsProfileDetailsReceipt.asp.
'-------------------------------------------------------------------------------------------

On Error Resume Next

%>
<%
If Not Request.QueryString ("profileID")= "" Then
profileID	= Request.QueryString ("profileID")
End If
%>
<html>
	<head>
		<title>PayPal Classic ASP NVP SDK - GetRecurringPaymentsProfile API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css">
			<script src="CCGenerate.js">
			</script>
	</head>
	<body onload="generateCC()">
		<form id="frmDCC" name="frmDCC" action="GetRecurringPaymentsProfileDetailsReceipt.asp"
			method="POST">
			<center>
				<font size="2" color="black" face="Verdana"><b>Recurring Payments Profile Details</b></font>
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
							<input type="text" size="30" maxlength="32" name="profileID" value='<%=profileID%>'>(Required)
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
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"GetRecurringPaymentsProfileDetails.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<a class="home" id="CallsLink" href="RecurringPayments.asp"><font color="blue"><B>Recurring 
					Payments Home<B><font></a>
	</body>
</html>
