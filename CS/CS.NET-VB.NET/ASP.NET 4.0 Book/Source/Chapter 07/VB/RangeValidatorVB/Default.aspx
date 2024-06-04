<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RangeValidator Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="RangeValidator Control Example" 
		Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
		<br />
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Your Age:"></asp:Label>
		&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="172px"></asp:TextBox>
		<asp:RangeValidator ID="RangeValidator1" runat="server" 
		ControlToValidate="TextBox1" 
		ErrorMessage="Invalid Age. Please enter the age between 20 to 40." 
		MaximumValue="40" MinimumValue="20" Type="Integer"></asp:RangeValidator>
		&nbsp;<br />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="This field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Date of Birth (YYYY/MM/DD format) :"></asp:Label>
		&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" Width="172px"></asp:TextBox>
		<asp:RangeValidator ID="RangeValidator2" runat="server" 
		ControlToValidate="TextBox2" 
		ErrorMessage="Invalid DOB. It must be between 1988/1/1 to 2028/1/1." 
		MaximumValue="2028/1/1" MinimumValue="1988/1/1" Type="Date"></asp:RangeValidator>
		<br />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
		ControlToValidate="TextBox2" ErrorMessage="This field can not be 
 		blank."></asp:RequiredFieldValidator>
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Small" ForeColor="White" Text="Submit" />

    </div>
    </form>
</body>
</html>
