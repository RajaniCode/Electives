<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Button Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-
 			  Underline="True" 
			Text="Button control example showing text on button click 
 			  event"></asp:Label>
			<br />
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" Font-Bold="True" 
			onclick="Button1_Click" Text="Click Me, I will Welcome You !!" />
			&nbsp;<br />
			<br />
			<asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
