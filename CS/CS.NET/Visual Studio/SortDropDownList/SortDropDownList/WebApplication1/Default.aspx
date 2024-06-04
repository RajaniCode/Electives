<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="cboNames" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnSortDescending" runat="server" Text="Sort Descending" OnClick="btnSortNames_Click" />
        <asp:Button ID="btnSortAscending" runat="server" Text="Sort Ascending" OnClick="btnSortAscending_Click" />
    </div>
    </form>
</body>
</html>
