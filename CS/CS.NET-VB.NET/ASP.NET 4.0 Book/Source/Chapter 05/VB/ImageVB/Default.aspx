<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-
 				  Underline="True" 
				Text="Image Control Example"></asp:Label>
				<br />
				<br />
				<br />
				<br />
				<asp:Button ID="Button1" runat="server" BackColor="#000066" Font-
 				  Bold="True" 
				ForeColor="#66FFFF" Height="51px" 
				Text="Click Me to View the Image!!" />
				<br />
				<br />
				<asp:Image ID="Image1" runat="server" BorderColor="#660066" 
 				  Height="300px" 
				ImageUrl="~/Tulips.jpg" ToolTip="Image control example" 
 				  Visible="False" 
				Width="300px" />
				&nbsp;

    </div>
    </form>
</body>
</html>
