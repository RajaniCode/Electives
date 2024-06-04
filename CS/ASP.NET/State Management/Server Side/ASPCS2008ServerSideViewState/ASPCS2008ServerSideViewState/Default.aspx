<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ServerSideViewState._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Server Side ViewState Persistance Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="hlnkCachePage" runat="server" NavigateUrl="~/ViewStateInCache.aspx" Text="ViewState Persisted on Server"></asp:HyperLink>
        <br /><br />
        <asp:HyperLink ID="hlnkInPage" runat="server" NavigateUrl="~/ViewStateInPage.aspx" Text="ViewState Persisted In Page"></asp:HyperLink>
    </div>
    </form>
</body>
</html>
