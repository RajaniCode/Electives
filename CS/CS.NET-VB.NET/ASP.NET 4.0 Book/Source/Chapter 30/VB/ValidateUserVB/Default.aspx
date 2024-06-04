<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>WelCome!</h3>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<br />
		<br />
		<asp:LinkButton ID="LinkButton1" runat="server" 
 		  OnClick="LinkButton1_Click">Logout</asp:LinkButton></div>
		

    </form>
</body>
</html>
