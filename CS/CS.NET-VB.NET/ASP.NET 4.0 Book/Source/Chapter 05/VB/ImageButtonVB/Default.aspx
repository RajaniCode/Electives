<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Button Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-
 				  Underline="True" 
				Text="ImageButton Control Example"></asp:Label>
				<br />
				<br />
				<asp:Label ID="Label2" runat="server" BorderWidth="2px" Font-
 				  Italic="True" 
				ForeColor="#FF0066" Text="Click Anywhere on the ImageButton Control Below:"></asp:Label>
				<br />
				<br />
				<asp:ImageButton ID="ImageButton1" runat="server" Height="300px" 
				ImageUrl="~/Lighthouse.jpg" onclick="ImageButton1_Click" />
				<br />
				<asp:Label ID="Label3" runat="server" 
				Text="You clicked on the ImageButton at following co-ordinates:"></asp:Label>
				<br />
				<asp:Label ID="Label4" runat="server" 
 				  BackColor="#00CCFF"></asp:Label>

    </div>
    </form>
</body>
</html>
