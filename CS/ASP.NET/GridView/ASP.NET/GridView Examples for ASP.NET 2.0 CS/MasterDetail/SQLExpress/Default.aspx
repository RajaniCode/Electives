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
        <h2>You are Viewing Order Detail Information for Orders that Have Included Shipments of the Selected Product</h2>
        <asp:SqlDataSource ID="productListingDataSource" Runat="server" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName] FROM [Products]">
        </asp:SqlDataSource>
        <asp:DropDownList ID="productSelector" Runat="server" DataSourceID="productListingDataSource"
            DataTextField="ProductName" DataValueField="ProductID" AutoPostBack="True">
        </asp:DropDownList>&nbsp;
        <asp:SqlDataSource ID="orderDetailsForProduct" Runat="server" SelectCommand="SELECT [OrderID], [ProductID], [UnitPrice], [Quantity] FROM [Order Details] WHERE ([ProductID] = @ProductID)"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>" DataSourceMode="DataReader">
            <SelectParameters>
                <asp:ControlParameter Name="ProductID" Type="Int32" ControlID="productSelector" PropertyName="SelectedValue"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource><asp:GridView ID="orderDetailsGridView" Runat="server" DataSourceID="orderDetailsForProduct" AutoGenerateColumns="False" DataKeyNames="OrderID" BorderWidth="1px" BackColor="LightGoldenrodYellow" GridLines="None" CellPadding="2" BorderColor="Tan" ForeColor="Black">
            <FooterStyle BackColor="Tan"></FooterStyle>
            <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod"></PagerStyle>
            <HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
            <AlternatingRowStyle BackColor="PaleGoldenrod"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="Order ID" InsertVisible="False" DataField="OrderID"
                    SortExpression="OrderID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" SortExpression="UnitPrice" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedRowStyle>
        </asp:GridView>    
    </div>
    </form>
</body>
</html>
