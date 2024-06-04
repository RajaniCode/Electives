<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  Culture="auto" UICulture="auto"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  id="Html1" runat="server" dir="<%$ Resources:default,TextDirection %>" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StaticContentCulture Example</title>
</head>
<body id="Body1" runat="server" dir="<%$ Resources:default,TextDirection %>">
    <form id="form1" runat="server">
    <div>
        <strong>ASP.NET 4.0 BLACK BOOK</strong><br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:default, msg %>"></asp:Label>
    </div>
    </form>
</body>
</html>
