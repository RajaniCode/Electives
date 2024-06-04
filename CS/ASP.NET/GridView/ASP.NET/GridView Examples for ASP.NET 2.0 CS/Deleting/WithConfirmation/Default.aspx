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
        <h2>
            You Can Delete Order Detail Information for Orders that Have Included Shipments
            of the Selected Product - Note that a Client-Side Confirm Dialog Box is Presented Before
            Deleting
        </h2>
        <asp:SqlDataSource ID="productListingDataSource" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName] FROM [Products]" Runat="server">
        </asp:SqlDataSource>
        <asp:DropDownList ID="productSelector" Runat="server" DataSourceID="productListingDataSource"
            DataTextField="ProductName" DataValueField="ProductID" AutoPostBack="True">
        </asp:DropDownList>&nbsp;
        <asp:SqlDataSource ID="orderDetailsForProduct" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
            SelectCommand="SELECT [OrderID], [ProductID], [UnitPrice], [Quantity] FROM [Order Details] WHERE ([ProductID] = @ProductID2)"
            Runat="server" DataSourceMode="DataReader" DeleteCommand="DELETE FROM [Order Details] WHERE [OrderID] = @original_OrderID AND [ProductID] = @original_ProductID">
            <DeleteParameters>
                <asp:Parameter Type="Int32" Name="OrderID"></asp:Parameter>
                <asp:Parameter Type="Int32" Name="ProductID"></asp:Parameter>
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter Name="ProductID2" Type="Int32" ControlID="productSelector"
                    PropertyName="SelectedValue"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="orderDetailsGridView" Runat="server" DataSourceID="orderDetailsForProduct"
            AutoGenerateColumns="False" DataKeyNames="OrderID,ProductID" BorderColor="Tan"
            CellPadding="2" BackColor="LightGoldenrodYellow" BorderWidth="1px" ForeColor="Black"
            GridLines="None">
            <FooterStyle BackColor="Tan"></FooterStyle>
            <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod"></PagerStyle>
            <HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
            <AlternatingRowStyle BackColor="PaleGoldenrod"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField><ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" Runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                        CommandName="Delete">Delete Order Line Item</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Order ID" DataField="OrderID" SortExpression="OrderID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity"
                    DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" SortExpression="UnitPrice"
                    DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedRowStyle>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
