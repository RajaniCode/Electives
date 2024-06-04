<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DropDownList Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label1" runat="server" Font-Bold="True" 
 				  Font-Underline="True" 
				Text="DropDownList Control Example" Font-Size="Medium" 
 				  ForeColor="Black"></asp:Label>
				<br />
				<br />
				<asp:Label ID="Label2" runat="server" Font-Size="Small" 
 				  ForeColor="#FF0066" 
				Text="Select the Product Name:"></asp:Label>
				<br />
				<asp:DropDownList ID="DropDownList1" runat="server" 
 				  AutoPostBack="True" Height="20px" 
				onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
 				  Width="227px" 
				style="margin-bottom: 0px" DataSourceID="SqlDataSource1" 
            DataTextField="ProductName" DataValueField="ProductName" >
				</asp:DropDownList>
				<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
            SelectCommand="SELECT [ProductName] FROM [Products]"></asp:SqlDataSource>
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<asp:Label ID="Label4" runat="server" Font-Size="Small" 
 				ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
