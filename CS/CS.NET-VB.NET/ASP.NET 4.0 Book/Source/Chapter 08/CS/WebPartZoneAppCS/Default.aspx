<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebPartZone control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Navy" Text="WebPart Zone:">
		</asp:Label>
		<br />
		<br />
		 <asp:Panel ID="Panel1" runat="server" BackColor="#FFE0C0" BorderColor="#FF8000" BorderStyle="Double" Height="226px"                
		Width="550px">
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Navy"
		Text="Enter Header Text:"></asp:Label><br />
		<br />
		<br />
		<asp:TextBox ID="TextBox1" runat="server" Width="230px">
		</asp:TextBox>
		<br />
		<br />
		<asp:Button ID="Button1" runat="server" BackColor="#FFFFC0" OnClick="Button1_Click"
		Text="Create WebPartZone" />
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Font-							Bold="True"></asp:Label>
		</asp:Panel>
    </div>
    </form>
</body>
</html>
