<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TreeViewDatabase.aspx.vb" Inherits="TreeViewDatabase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreeView Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label2" runat="server" Text="TreeView Control bind to SQL Server  NORTHWIND  database" Font-Bold ="true"></asp:Label><br />
			<br />
			<asp:TreeView ID="TreeView2" runat="server" MaxDataBindDepth="2" 
            Width="261px">
			<Nodes>
			<asp:TreeNode PopulateOnDemand="True" Text="Categories and their products" Value="namesofCustomer">
			</asp:TreeNode>
			</Nodes>
			</asp:TreeView>
    </div>
    </form>
</body>
</html>
