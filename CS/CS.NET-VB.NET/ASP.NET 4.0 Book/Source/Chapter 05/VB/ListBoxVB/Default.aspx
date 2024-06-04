<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListBox Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
 					  Font-Underline="True" 
					Text="ListBox Control Example"></asp:Label>
					<br />
					<br />
					<br />
					<asp:Label ID="Label2" runat="server" Font-Bold="True" 
 					  Font-Size="Small" 
					ForeColor="#FF0066" Text="Select the Items from the 
 					  ListBox:"></asp:Label>
					<br />
					<asp:ListBox ID="ListBox2" runat="server" 
 					  Width="280px" DataSourceID="SqlDataSource1" DataTextField="ProductName" 
            DataValueField="ProductName">
					</asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
            SelectCommand="SELECT [ProductName] FROM [Products]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" 
            Width="154px" />
        <br />
					<br />
					<asp:Label ID="Label3" runat="server" Font-Bold="True" 
 					  Font-Size="Small" 
					ForeColor="#FF0066" Text="The Items you have selected 
 					  are:"></asp:Label>
					<br />
					<asp:ListBox ID="ListBox1" runat="server" Height="139px" 
 					  Width="280px">
					</asp:ListBox>
    </div>
    </form>
</body>
</html>
