<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

    void orderGridView_PageIndexChanged(object sender, EventArgs e)
    {
        orderGridView.SelectedIndex = -1;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:50%;float:left;padding-right:10px;">
        <h2>Select an Order from the Left...</h2>
            <asp:SqlDataSource ID="ordersDataSource" Runat="server" SelectCommand="SELECT dbo.Orders.OrderID, dbo.Customers.CompanyName, dbo.Orders.OrderDate FROM dbo.Orders INNER JOIN dbo.Customers ON dbo.Orders.CustomerID = dbo.Customers.CustomerID"
                ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
            </asp:SqlDataSource>
            <asp:GridView ID="orderGridView" Runat="server" DataSourceID="ordersDataSource" DataKeyNames="OrderID"
                AutoGenerateColumns="False" AllowPaging="True" BorderWidth="1px" BackColor="#DEBA84"
                CellPadding="3" CellSpacing="2" BorderStyle="None" BorderColor="#DEBA84" OnPageIndexChanged="orderGridView_PageIndexChanged">
                <FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"></PagerStyle>
                <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#A55129"></HeaderStyle>
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="View Order Details"></asp:CommandField>
                    <asp:BoundField HeaderText="Company" DataField="CompanyName" SortExpression="CompanyName"></asp:BoundField>
                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" SortExpression="OrderDate"
                        DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7"></RowStyle>
            </asp:GridView>
    </div>
    <div>
        <h2>... and View the Order Details on the Right</h2>
        <asp:SqlDataSource ID="orderDetailsDataSource" Runat="server" SelectCommand="SELECT dbo.[Order Details].OrderID, dbo.Products.ProductName, dbo.[Order Details].UnitPrice, dbo.[Order Details].Quantity, dbo.[Order Details].Discount FROM dbo.[Order Details] INNER JOIN dbo.Products ON dbo.[Order Details].ProductID = dbo.Products.ProductID WHERE dbo.[Order Details].OrderID = @OrderID"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="orderGridView" Name="OrderID" Type="Int32" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="detailsGridView" Runat="server" DataSourceID="orderDetailsDataSource"
            AutoGenerateColumns="False" BorderWidth="1px" BackColor="#DEBA84" CellPadding="3"
            CellSpacing="2" BorderStyle="None" BorderColor="#DEBA84">
            <FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#A55129"></HeaderStyle>
            <Columns>
                <asp:BoundField HeaderText="Product" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" SortExpression="UnitPrice"
                    DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Discount" DataField="Discount" SortExpression="Discount"
                    DataFormatString="{0:P}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7"></RowStyle>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
