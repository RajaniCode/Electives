<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Panel Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="Panel Control Example"></asp:Label>
			<br />
			<br />
			&nbsp;<asp:Button ID="Button1" runat="server" Text="Click Me to See the Color Options!!" />
			<br />
			&nbsp;<asp:Panel ID="Panel1" runat="server" Height="54px" Visible="False" 
 			  Width="285px">
			<asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#CC0000" GroupName="MyGroup" 
			Text="Red" />
			&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" 
 			  AutoPostBack="True" 
			Font-Size="Small" ForeColor="#009933" GroupName="MyGroup" 
			Text="Green" />
			&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" 
 			  AutoPostBack="True" 
			Font-Size="Small" ForeColor="#FFCC00" GroupName="MyGroup" 
			Text="Yellow" />
			<br />
			<br />
			<br />
			<br />
			<asp:Panel ID="Panel2" runat="server" Height="52px" Width="236px">
			</asp:Panel>
			<br />
			<br />
			<br />
			<br />
			</asp:Panel>
    </div>
    </form>
</body>
</html>
