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
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" CellPadding="4" 
        DataKeyNames="ProductID" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        Width="254px">
        <EditItemTemplate>
            ProductID:
            <asp:Label ID="ProductIDLabel1" runat="server" 
                Text='<%# Eval("ProductID") %>' />
            <br />
            ProductName:
            <asp:TextBox ID="ProductNameTextBox" runat="server" 
                Text='<%# Bind("ProductName") %>' />
            <br />
            QuantityPerUnit:
            <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" 
                Text='<%# Bind("QuantityPerUnit") %>' />
            <br />
            UnitPrice:
            <asp:TextBox ID="UnitPriceTextBox" runat="server" 
                Text='<%# Bind("UnitPrice") %>' />
            <br />
            UnitsInStock:
            <asp:TextBox ID="UnitsInStockTextBox" runat="server" 
                Text='<%# Bind("UnitsInStock") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            ProductName:
            <asp:TextBox ID="ProductNameTextBox" runat="server" 
                Text='<%# Bind("ProductName") %>' />
            <br />
            QuantityPerUnit:
            <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" 
                Text='<%# Bind("QuantityPerUnit") %>' />
            <br />
            UnitPrice:
            <asp:TextBox ID="UnitPriceTextBox" runat="server" 
                Text='<%# Bind("UnitPrice") %>' />
            <br />
            UnitsInStock:
            <asp:TextBox ID="UnitsInStockTextBox" runat="server" 
                Text='<%# Bind("UnitsInStock") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            ProductID:
            <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
            <br />
            ProductName:
            <asp:Label ID="ProductNameLabel" runat="server" 
                Text='<%# Bind("ProductName") %>' />
            <br />
            QuantityPerUnit:
            <asp:Label ID="QuantityPerUnitLabel" runat="server" 
                Text='<%# Bind("QuantityPerUnit") %>' />
            <br />
            UnitPrice:
            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>' />
            <br />
            UnitsInStock:
            <asp:Label ID="UnitsInStockLabel" runat="server" 
                Text='<%# Bind("UnitsInStock") %>' />
            <br />
        </ItemTemplate>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
        SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Alphabetical list of products]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
