<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using WCF service</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter text in textbox<br />
						<br />
						<asp:TextBox 
						ID="TextBox1"
						runat="server"></asp:TextBox>
						<br />
						<br />
						<asp:Label 
						ID="Label1" runat="server" 
						Width="112px"></asp:Label>
						<br />
						<br />
						<asp:Button 
						ID="Button1" runat="server" 
						OnClick="Button1_Click" 
						Text="CALL" />
						<br />
						<asp:Label ID="Label2" runat="server" Text="Click 
 						the CALL button to call the service"></asp:Label>
    </div>
    </form>
</body>
</html>
