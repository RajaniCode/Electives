<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Login ID="Login1" runat="server" BackColor="#FFFFCC" BorderColor="#E6E2D8" 
		BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
		Font-Size="0.8em" ForeColor="#333333" Height="332px" Width="351px">
		<TextBoxStyle Font-Size="0.8em" />
		<LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
		BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
		<LayoutTemplate>
		<table border="0" cellpadding="4" cellspacing="0" 
		style="border-collapse: collapse;">
		<tr>
		<td>
		<table border="0" cellpadding="0" class="style1">
		<tr>
		<td align="center" colspan="2" 
		style="color: White; background-color: #5D7B9D; font-size: 0.9em; font-weight: 
		bold;">
		Log In</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
		Name:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
		<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
		ControlToValidate="UserName" ErrorMessage="User Name is required." 
		ToolTip="User Name is required." 
		ValidationGroup="Login1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="PasswordLabel" runat="server" 
		AssociatedControlID="Password">Password:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="Password" runat="server" Font-Size="0.8em" 
		TextMode="Password"></asp:TextBox>
		<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
		ControlToValidate="Password" ErrorMessage="Password is required." 
		ToolTip="Password is required." 
		ValidationGroup="Login1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td colspan="2">
		<asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
		</td>
		</tr>
		<tr>
		<td align="center" colspan="2" style="color: Red;">
		<asp:Literal ID="FailureText" runat="server" 
		EnableViewState="False"></asp:Literal>
		</td>
		</tr>
		<tr>
		<td align="right" colspan="2">
		<asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
		BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
		Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" 
		onclick="LoginButton_Click" Text="Log In" ValidationGroup="Login1" 
		Width="246px" style="height: 18px" />
		<br />
		<asp:Button ID="BtnCreateUser" runat="server" Height="22px" 
		onclick="BtnCreateUser_Click" Text="Create New User" Width="247px" 
		BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
		Font-Names="Verdana" Font-Size="Smaller" />
		</td>
		</tr>
		</table>
		</td>
		</tr>
		</table>
		</LayoutTemplate>
		<InstructionTextStyle Font-Italic="True" ForeColor="Black" />
		<TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
		ForeColor="White" />
		</asp:Login>

    </div>
    </form>
</body>
</html>
