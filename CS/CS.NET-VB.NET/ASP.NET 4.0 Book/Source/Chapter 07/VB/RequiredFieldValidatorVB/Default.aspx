<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RequiredFieldValidator Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" 
		Text="RequiredField Validator Control Example" Font-Bold="True" 
		Font-Size="Medium" Font-Underline="True"></asp:Label>
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="User name:"></asp:Label>
		&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Height="22px" 
 		Width="175px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="User name can not be 
 		empty"></asp:RequiredFieldValidator>
		<br />
		<br />

		<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Password:"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" Height="22px" TextMode="Password" 
		Width="175px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
		ControlToValidate="TextBox2" ErrorMessage="Password can not be 
 		empty"></asp:RequiredFieldValidator>
		<br />
		<br />
		<br />

		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Medium" ForeColor="White" Text="Submit" />

    </div>
    </form>
</body>
</html>
