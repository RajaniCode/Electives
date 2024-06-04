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
            <asp:SqlDataSource ID="productDataSource" Runat="server" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
                UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @original_ProductID"
                SelectCommand="SELECT [ProductName], [ProductID], [UnitPrice], [UnitsInStock] FROM [Products]">
                <UpdateParameters>
                    <asp:Parameter Type="String" Name="ProductName"></asp:Parameter>
                    <asp:Parameter Type="Decimal" Name="UnitPrice"></asp:Parameter>
                    <asp:Parameter Type="Int16" Name="UnitsInStock"></asp:Parameter>
                    <asp:Parameter Type="Int32" Name="ProductID"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" Runat="server" BorderColor="#3366CC" BorderStyle="None"
                CellPadding="4" BackColor="White" BorderWidth="1px" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ProductID" DataSourceID="productDataSource">
                <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC"></PagerStyle>
                <HeaderStyle ForeColor="#CCCCFF" Font-Bold="True" BackColor="#003399"></HeaderStyle>
                <Columns>
                    <asp:CommandField ShowEditButton="True"></asp:CommandField>
                    <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                        SortExpression="ProductID"></asp:BoundField>
                    <asp:TemplateField SortExpression="ProductName" HeaderText="Product"><EditItemTemplate>
                        <asp:TextBox ID="editProductName" Runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Runat="server" ErrorMessage="You must provide a Product Name."
                            ControlToValidate="editProductName">
                            *</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label Runat="server" Text='<%# Bind("ProductName") %>' ID="Label3"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="UnitPrice" HeaderText="Unit Price"><EditItemTemplate>
                        <asp:TextBox ID="editUnitPrice" Runat="server" Text='<%# Bind("UnitPrice", "{0:#,##0.00}") %>' Columns="6"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" Runat="server" ErrorMessage="You must provide a valid currency value for the Unit Price."
                            ControlToValidate="editUnitPrice" Operator="DataTypeCheck" Type="Currency">
                            *</asp:CompareValidator>
                    </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label Runat="server" Text='<%# Bind("UnitPrice", "{0:c}") %>' ID="Label1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="UnitsInStock" HeaderText="Units In Stock"><EditItemTemplate>
                        <asp:TextBox ID="editUnitsInStock" Runat="server" Text='<%# Bind("UnitsInStock") %>'
                            Columns="4"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" Runat="server" ErrorMessage="You must provide a valid integer for Units In Stock."
                            ControlToValidate="editUnitsInStock" Operator="DataTypeCheck" Type="Integer">
                            *</asp:CompareValidator>
                    </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label Runat="server" Text='<%# Bind("UnitsInStock") %>' ID="Label2"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
                <RowStyle ForeColor="#003399" BackColor="White"></RowStyle>
            </asp:GridView>
        </div>
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" Runat="server" />
    
    </div>
    </form>
</body>
</html>
