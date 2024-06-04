<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Literal Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server"  Font-Bold="True" Font-Underline ="true" 
				Text="Literal Control Example showing Text on Button Click 
 				  Event"></asp:Label>
				<br />
				<br />
				<br />
				<asp:Button ID="Button1" runat="server" Font-Bold="True"  
 				  Text="Click Me!!" />
				<br />
				<br />
				<br />
				<asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
