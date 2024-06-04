<%@ Page Language="C#" StyleSheetTheme="GridViewTheme" %>

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
        <asp:SqlDataSource ID="productsSubsetDataSource" Runat="server" SelectCommand="SELECT TOP 5 ProductID, ProductName, UnitPrice FROM Products ORDER BY ProductName"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <h2>A GridViwe Without a Skin Specified</h2>
        <asp:GridView ID="GridView3" Runat="server" DataSourceID="productsSubsetDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <h2>A GridViwe With the <i>Professional</i> Skin</h2>
        <asp:GridView ID="GridView1" Runat="server" DataSourceID="productsSubsetDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False" SkinID="Professional">
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <h2>A GridViwe With the <i>Fun</i> Skin</h2>
        <asp:GridView ID="GridView2" Runat="server" DataSourceID="productsSubsetDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False" SkinID="Fun">
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
