<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter the First 
 			Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
			ID="TextBox1" runat="server"></asp:TextBox>
			<br />
			Enter the Second Number&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" Text="Display Result" OnClick="Button1_Click" />
			<br />
			<br />
			<asp:Label ID="Label1" runat="server" Text="Cached Result"></asp:Label>

    </div>
    </form>
</body>
</html>
