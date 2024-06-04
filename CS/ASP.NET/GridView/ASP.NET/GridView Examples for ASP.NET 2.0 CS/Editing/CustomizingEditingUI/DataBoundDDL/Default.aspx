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
        <asp:SqlDataSource ID="productsDataSource" Runat="server" SelectCommand="SELECT dbo.Products.ProductID, dbo.Products.ProductName, dbo.Products.CategoryID, dbo.Categories.CategoryName FROM dbo.Products INNER JOIN dbo.Categories ON dbo.Products.CategoryID = dbo.Categories.CategoryID"
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID WHERE [ProductID] = @original_ProductID"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
            <UpdateParameters>
                <asp:Parameter Type="String" Name="ProductName"></asp:Parameter>
                <asp:Parameter Type="Int32" Name="CategoryID"></asp:Parameter>
                <asp:Parameter Name="original_ProductID"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="categoryDataSource" Runat="server" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories] ORDER BY [CategoryName]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView1" Runat="server" DataSourceID="productsDataSource" DataKeyNames="ProductID"
            AutoGenerateColumns="False" AllowPaging="True" BorderWidth="1px" BackColor="White"
            CellPadding="3" BorderStyle="None" BorderColor="#CCCCCC">
            <FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#006699"></HeaderStyle>
            <Columns>
                <asp:CommandField ShowEditButton="True"></asp:CommandField>
                <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:TemplateField SortExpression="CategoryName" HeaderText="CategoryName"><EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" Runat="server" DataSourceID="categoryDataSource"
                        DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label Runat="server" Text='<%# Bind("CategoryName") %>' ID="Label1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#669999"></SelectedRowStyle>
            <RowStyle ForeColor="#000066"></RowStyle>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
