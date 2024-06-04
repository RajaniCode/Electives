<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ValidationSummary Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
		Font-Underline="True" Text="ValidationSummary Control Example"></asp:Label>
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Text="First Name:  "></asp:Label>
		<asp:TextBox ID="TextBox1" runat="server" Width="174px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" Display="None" 
		ErrorMessage="First Name field can not be blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Text="Last Name:  "></asp:Label>
		<asp:TextBox ID="TextBox2" runat="server" Width="174px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
		ControlToValidate="TextBox2" Display="None" 
		ErrorMessage="Last Name field can not be blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="65px" 
		Width="439px" />
		<br />
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Small" ForeColor="White" Text="Submit" />

    </div>
    </form>
</body>
</html>
