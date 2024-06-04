<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinkButton Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" ForeColor="Black" Text="LinkButton Control 
 			  Example"></asp:Label>
			<br />
			<br />
			<br />
			<asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" 
			BorderColor="#00CCFF" Font-Names="Tahoma" Font-Size="Small" 
 			  ForeColor="#0000CC" 
			onclick="LinkButton1_Click" ToolTip="Google 
 			  Website">LinkButton</asp:LinkButton>

    </div>
    </form>
</body>
</html>
