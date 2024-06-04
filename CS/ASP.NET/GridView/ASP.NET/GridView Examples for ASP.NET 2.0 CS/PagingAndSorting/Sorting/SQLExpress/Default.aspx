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
        <asp:SqlDataSource ID="productDataSource" Runat="server" SelectCommand="SELECT [ProductName], [UnitPrice], [UnitsInStock], [QuantityPerUnit] FROM [Products]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" Runat="server" DataSourceID="productDataSource" AutoGenerateColumns="False"
            AllowSorting="True" BorderWidth="2px" BackColor="White" GridLines="None" CellPadding="3"
            CellSpacing="1" BorderStyle="Ridge" BorderColor="White">
            <FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#C6C3C6"></PagerStyle>
            <HeaderStyle ForeColor="#E7E7FF" Font-Bold="True" BackColor="#4A3C8C"></HeaderStyle>
            <Columns>
                <asp:BoundField HeaderText="Product" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" SortExpression="UnitPrice"
                    DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Units In Stock" DataField="UnitsInStock" SortExpression="UnitsInStock"
                    DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity Per Unit" DataField="QuantityPerUnit"></asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#9471DE"></SelectedRowStyle>
            <RowStyle ForeColor="Black" BackColor="#DEDFDE"></RowStyle>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
