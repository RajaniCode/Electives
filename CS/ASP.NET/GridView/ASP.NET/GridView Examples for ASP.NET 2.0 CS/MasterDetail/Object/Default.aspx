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
        <asp:ObjectDataSource ID="productListingDataSource" Runat="server" TypeName="ProductDAL"
            SelectMethod="GetProducts">
        </asp:ObjectDataSource>
        <asp:DropDownList ID="productSelector" Runat="server" AutoPostBack="True" DataSourceID="productListingDataSource"
            DataTextField="ProductName" DataValueField="ProductID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="orderDetailsForProduct" Runat="server" TypeName="OrderDetailDAL"
            SelectMethod="GetOrderDetailsByProductID">
            <SelectParameters>
                <asp:ControlParameter Name="productID" Type="Int32" ControlID="productSelector" PropertyName="SelectedValue"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="productGridView" Runat="server" DataSourceID="orderDetailsForProduct" AutoGenerateColumns="False" DataKeyNames="OrderID">
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
        </asp:GridView>    
    
    </div>
    </form>
</body>
</html>
