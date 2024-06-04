<%
'-------------------------------------------------------------------------------------------
' ManageRecurringPaymentsProfileStatus.asp
' ===================
' This is the main web page for the ManageRecurringPaymentsProfileStatus sample.
' This page allows the user to enter profileid and action

' When the user clicks the Submit button, ManageRecurringPaymentsProfileStatus.asp
' is called.

' Called by default.htm.

' Calls ManageRecurringPaymentsProfileStatusReceipt.asp.
'-------------------------------------------------------------------------------------------

On Error Resume Next

%>
<html>
	<head>
		<title>PayPal Classic ASP NVP SDK - ManageRecurringPaymentsProfileStatus API</title>
		<link href="sdk.css" rel="stylesheet" type="text/css">
			<script src="CCGenerate.js">
			</script>
	</head>
	<body onload="generateCC()">
		<form id="frmDCC" name="frmDCC" action="ManageRecurringPaymentsProfileStatusReceipt.asp"
			method="POST">
			<center>
				<font size="2" color="black" face="Verdana"><b>Manage Recurring Payments Profile Status</b></font>
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
							Action:</td>
						<td>
							<select name="Action">
								<option value="Cancel" selected>Cancel</option>
								<option value="Suspend">Suspend</option>
								<option value="Reactivate">Reactivate</option>
							</select>
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
	SESSION("ErrorMessage")	= ErrorFormatter(Err.Description,Err.Number,Err.Source,"ManageRecurringPaymentsProfileStatus.asp")
	Response.Redirect "APIError.asp"
	Else
	SESSION("ErrorMessage")	= Null
	End If
    %>
		<a class="home" id="CallsLink" href="RecurringPayments.asp"><font color="blue"><B>Recurring 
					Payments Home<B><font></a>
	</body>
</html>
