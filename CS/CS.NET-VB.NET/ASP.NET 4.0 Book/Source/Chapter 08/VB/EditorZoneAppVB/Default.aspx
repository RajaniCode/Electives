<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EditorZone control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp; &nbsp;
		<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#0000C0"
		Text="EditorZone Webpart"></asp:Label><br />
		<br />
		</div>
		<asp:Panel ID="Panel1" runat="server" BackColor="#FFFFC0" BorderStyle="Outset" Height="235px"
		Width="466px">
		&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" BackColor="#FFC0C0" Font-Bold="True"
		Text="Default Values" Width="221px" />
		&nbsp;<br />
		&nbsp; &nbsp;<br />
		&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True"
		ForeColor="Navy" Text="Browse Mode:"></asp:Label>&nbsp; &nbsp;<asp:Label ID="Label1"
		runat="server" Font-Bold="True" Text="Label"></asp:Label><br />
		<br />
		<br />
		<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Navy"
		Text="Empty Zone Text:"></asp:Label>&nbsp; &nbsp; &nbsp;<asp:Label ID="Label2" runat="server"
		Font-Bold="True" Text="Label"></asp:Label>&nbsp; &nbsp;<br />
		<br />
		&nbsp; &nbsp;
		<br />
		<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Navy"
		Text="Header Text:"></asp:Label>&nbsp; &nbsp;<asp:Label ID="Label3" runat="server"
		Font-Bold="True" Text="Label"></asp:Label><br />
		&nbsp; &nbsp;</asp:Panel>

    </div>
    </form>
</body>
</html>
