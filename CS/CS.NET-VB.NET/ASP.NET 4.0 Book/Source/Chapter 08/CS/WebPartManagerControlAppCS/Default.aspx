<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebPartManager Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#0000C0"
		Text="WebPart Manager:"></asp:Label>
		<br />
		<br />
		<asp:Panel ID="Panel1" runat="server" BackColor="#FFE0C0" BorderColor="#FFC080" BorderStyle="Double"
		Height="129px" Width="320px">
		&nbsp; &nbsp; &nbsp;<br />
		&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Navy"
		Text="WEBPARTMANAGER CREATED!!!!" Visible="False"></asp:Label><br />
		<br />
		<asp:Button ID="Button2" runat="server" BackColor="#FFC080" Font-Bold="True" 
                ForeColor="#0000C0" Text="DisplayMode" Width="213px" onclick="Button2_Click" />
		&nbsp; &nbsp;
		<asp:Label ID="Label2" runat="server" Font-Bold="True" 	ForeColor="#0000C0" Visible="False"></asp:Label><br />
		&nbsp; &nbsp;</asp:Panel>
    </div>
    </form>
</body>
</html>
