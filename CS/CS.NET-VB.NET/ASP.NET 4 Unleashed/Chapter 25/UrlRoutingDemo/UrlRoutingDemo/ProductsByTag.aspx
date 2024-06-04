<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsByTag.aspx.cs" Inherits="UrlRoutingDemo.ProductsByTag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="testLink" runat="server" 
            NavigateUrl="<%$ RouteUrl:RouteName=products-by-tag,tagnames=new/discounted %>">New and Discounted Products</asp:HyperLink>

        <asp:HyperLink ID="codeGeneratedLink" runat="server">New And Discuonted Products (Code Generated Link)</asp:HyperLink>
    </div>
    </form>
</body>
</html>
