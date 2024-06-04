<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegularExpressionValidator Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
		Font-Underline="True" Text="RegularExpressionValidator Control 
 		Example"></asp:Label>
		<br />
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Enter URL:"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox>
		<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="Not a Valid URL." 
		ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
		<br />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="This field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Enter E-mail address:"></asp:Label>
		&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" Width="177px"></asp:TextBox>
		<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
		ControlToValidate="TextBox2" ErrorMessage="Not a Valid E-mail address." 
		ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		<br />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
		ControlToValidate="TextBox2" ErrorMessage="This field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Small" ForeColor="White" Text="Submit" Width="60px" />

    </div>
    </form>
</body>
</html>
