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
        <asp:ObjectDataSource ID="productsDataSource" Runat="server" SelectMethod="GetProducts"
            TypeName="ProductDAL">
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" Runat="server" DataSourceID="productsDataSource">
        </asp:GridView>&nbsp;
    
    </div>
    </form>
</body>
</html>
