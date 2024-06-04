<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CompareValidator Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
		Font-Underline="True" Text="CompareValidator Control Example"></asp:Label>
		<br />
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="User Name:"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="173px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="This Field can not be  
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Password:"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
 		Width="173px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
		ControlToValidate="TextBox2" ErrorMessage="This Field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Re-type Password:"></asp:Label>
		&nbsp;<asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
 		Width="173px"></asp:TextBox>
		<asp:CompareValidator ID="CompareValidator1" runat="server" 
		ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
		ErrorMessage="Password does not match."></asp:CompareValidator>
		<br />
		<br />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
		ControlToValidate="TextBox3" ErrorMessage="This Field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Small" ForeColor="White" Text="Submit" />

    </div>
    </form>
</body>
</html>
