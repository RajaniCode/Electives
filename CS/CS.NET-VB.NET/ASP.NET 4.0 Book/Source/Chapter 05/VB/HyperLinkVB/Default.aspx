<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HyperLink Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" ForeColor="Black" Text="HyperLink Control 
 			  Example"></asp:Label>
			<br />
			<br />
			<br />
			<asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
			ForeColor="Blue"  Target="_blank" 
 			  NavigateUrl="http:\\www.google.co.in">Click me to move to the google 
 			  website</asp:HyperLink>
			<br />

    </div>
    </form>
</body>
</html>
