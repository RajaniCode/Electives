<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:SqlDataSource ID="productsDataSource" Runat="server" SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Products]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>" DataSourceMode="DataReader">
        </asp:SqlDataSource>
        <asp:GridView ID="productGridView" Runat="server" DataSourceID="productsDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False" BorderWidth="1px" BackColor="#DEBA84" CellPadding="3" CellSpacing="2" BorderStyle="None" BorderColor="#DEBA84">
            <FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#A55129"></HeaderStyle>
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Name" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="Qty/Unit" DataField="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
                <asp:BoundField HeaderText="Price/Unit" DataField="UnitPrice" SortExpression="UnitPrice" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Units In Stock" DataField="UnitsInStock" SortExpression="UnitsInStock" DataFormatString="{0:d}">
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
