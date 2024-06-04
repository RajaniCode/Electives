<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <strong><span style="text-decoration: underline"><em>Enter your login 
 		  Information<br />
		</em></span></strong>
		<br />
		<br />
		<table id="tblLogin" cellspacing="1" cellpadding="1" style="border-right: black 
 		  thin solid; border-top:  
		black thin solid; border-left: black thin solid; border-bottom: black thin 
 		  solid;" bgcolor="#ffffcc">
		<tr>
			<td colspan="2" >
				<div style="text-align: center">
					<strong><span style="text-decoration: underline">Login 
 					  Form</span></strong>
				</div>
			</td>
		</tr>
		<tr>
			<td width="40%">Enter Name:</td>
			<td>
			<asp:textbox id="textbox1" runat="server" width="100%"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td>Enter Password:</td>
			<td>
			<asp:textbox id="textbox2" runat="server" textmode="Password" 
 			  width="100%"></asp:textbox>
			</td>
		</tr>                    
		<tr>
			<td style="TEXT-ALIGN: center" colspan="2">
			&nbsp;<asp:Button ID="Button1" runat="server" Text="Login" 
 			  OnClick="Button1_Click" /></td>
		</tr>
		<tr>
			<td colspan="2" style="height: 21px">
			<asp:Label ID="label2" runat="server" Text=<%# "Application locking attempts:" & Membership.Provider.MaxInvalidPasswordAttempts %> />
			</td>
		</tr>
		</table>
		<br />
		<br />
		<asp:label id="label1" runat="server" BackColor="#FFC080" 
 		  Visible="false">Status:</asp:label>&nbsp;<br />
		<br />
		<br />
		<br />
		<br />
		<asp:label id="label4" runat="server" BackColor="#FFC080" 
 		  Visible="false">Status:</asp:label>&nbsp;
		<span style="color: #000099; text-decoration: underline"><strong>
		To unlock click here<br />
		</strong></span>
		<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Unlock"/><br />
    </div>
    </form>
</body>
</html>
