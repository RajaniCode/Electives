<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" 
        DataKeyField="ProductID" DataSourceID="SqlDataSource1" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <ItemTemplate>
            ProductID:
            <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
            <br />
            ProductName:
            <asp:Label ID="ProductNameLabel" runat="server" 
                Text='<%# Eval("ProductName") %>' />
            <br />
            QuantityPerUnit:
            <asp:Label ID="QuantityPerUnitLabel" runat="server" 
                Text='<%# Eval("QuantityPerUnit") %>' />
            <br />
            UnitsInStock:
            <asp:Label ID="UnitsInStockLabel" runat="server" 
                Text='<%# Eval("UnitsInStock") %>' />
            <br />
            UnitPrice:
            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
            <br />
<br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
        SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitsInStock], [UnitPrice] FROM [Alphabetical list of products]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
