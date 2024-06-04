<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter text to send to serial port"></asp:Label>
		
		<br />
		<br />
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;
		</span>
		<asp:TextBox ID="TextBox1" runat="server" Height="64px" TextMode="MultiLine" 
		style="margin-left: 163px"></asp:TextBox>
		<br />		
		<br />
		&nbsp;<asp:Button ID="BtnSend" runat="server" Text="Send" 
		Width="127px" style="margin-left: 153px" />

        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
