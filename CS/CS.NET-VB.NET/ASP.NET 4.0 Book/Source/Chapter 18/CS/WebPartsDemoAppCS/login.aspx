<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div id="header">
			<h1>
				ASP.NET 4.0 Black Book
			</h1>
		</div>
		<div id="sidebar">
			<div id="nav">
				&nbsp;
			</div>
		</div>
<div id="content">
			<div class="itemContent">
            <br />
			<table width="520px">
			
			<tr>
			<td style="width: 100px">
			</td>
			<td style="width: 100px">
			<asp:Login ID="Login1" runat="server" style="text-align: center">
			<LayoutTemplate>
			<table border="0" width="500px" cellpadding="1" style="border-right: blue thin groove; 
 			border-top: blue thin groove; border-left: blue thin groove; border-bottom: blue thin groove">
			<tr>
			<td style="width: 364px">
			<table border="0" cellpadding="0">
			<tr>
			    <td align="center" colspan="2">
                    <strong><span style="text-decoration: underline">User Login</span></strong></td>
			</tr>
			<tr>
			    <td align="right" style="width: 109px; text-align: center;">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                        Width="56px">User Name:</asp:Label>
                </td>
			<td style="width: 261px">
			<asp:TextBox ID="UserName" runat="server" Width="202px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
 			ControlToValidate="UserName"
			ErrorMessage="User Name is required." ToolTip="User Name is required." 
 			ValidationGroup="Login1">*</asp:RequiredFieldValidator>
			</td>
			</tr>
			<tr>
			    <td align="right" style="width:109px; text-align: center;">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                </td>
			<td style="width: 261px">
			<asp:TextBox ID="Password" runat="server" TextMode="Password" 
 			Width="201px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
 			ControlToValidate="Password"
			ErrorMessage="Password is required." ToolTip="Password is required." 
 			ValidationGroup="Login1">*</asp:RequiredFieldValidator>
			</td>
			</tr>
			<tr>
			    <td colspan="2">
                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next 
 			time." />
                </td>
			</tr>
			<tr>
			    <td align="center" colspan="2" style="color: red">
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </td>
			</tr>
			<tr>
			    <td align="right" colspan="2">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="OK" 
                        ValidationGroup="Login1" />
                   
                    <br /><br />
                </td>
                
			</tr>
			</table>
			</td>
			</tr>
			</table>
			</LayoutTemplate>
			</asp:Login>
			</td>
			<td style="width: 100px">
			</td>
			</tr>
			<tr>
			<td style="width: 100px">
			</td>
			<td style="width: 100px">
			</td>
			<td style="width: 100px">
			</td>
			</tr>
			</table>
			</div></div>
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
			

    
    </div>
    </form>
</body>
</html>
