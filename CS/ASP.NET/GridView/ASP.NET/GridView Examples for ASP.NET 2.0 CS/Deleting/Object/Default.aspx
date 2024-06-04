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
       <div>
        <h2>You Can Delete Order Detail Information for Orders that Have Included Shipments
        of the Selected Product
        </h2>
        <asp:ObjectDataSource ID="productListingDataSource" Runat="server" TypeName="ProductDAL"
            SelectMethod="GetProducts">
        </asp:ObjectDataSource>
        <asp:DropDownList ID="productSelector" Runat="server" DataSourceID="productListingDataSource"
            DataTextField="ProductName" DataValueField="ProductID" AutoPostBack="True">
        </asp:DropDownList>&nbsp;&nbsp;
           <asp:ObjectDataSource ID="orderDetailsForProduct" Runat="server" SelectMethod="GetOrderDetailsByProductID" TypeName="OrderDetailDAL" DeleteMethod="DeleteOrderDetail">
               <DeleteParameters>
                   <asp:Parameter Type="Int32" Name="original_OrderID"></asp:Parameter>
                   <asp:Parameter Type="Int32" Name="original_ProductID"></asp:Parameter>
               </DeleteParameters>
               <SelectParameters>
                   <asp:ControlParameter Name="productID" Type="Int32" ControlID="productSelector" PropertyName="SelectedValue"></asp:ControlParameter>
               </SelectParameters>
           </asp:ObjectDataSource>
        
        <asp:GridView ID="orderDetailsGridView" Runat="server" AutoGenerateColumns="False" DataSourceID="orderDetailsForProduct" DataKeyNames="OrderID,ProductID" BorderColor="Tan" CellPadding="2" BackColor="LightGoldenrodYellow" BorderWidth="1px" ForeColor="Black" GridLines="None">
            <FooterStyle BackColor="Tan"></FooterStyle>
            <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod"></PagerStyle>
            <HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
            <AlternatingRowStyle BackColor="PaleGoldenrod"></AlternatingRowStyle>
            <Columns>
                <asp:CommandField DeleteText="Delete Order Line Item" ShowDeleteButton="True"></asp:CommandField>
                <asp:BoundField HeaderText="Order ID" DataField="OrderID" SortExpression="OrderID">
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
        </asp:GridView>&nbsp;</div>
    </div>
    </form>
</body>
</html>
