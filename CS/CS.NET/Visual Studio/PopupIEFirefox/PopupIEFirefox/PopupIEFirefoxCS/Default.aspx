<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Parent Page</title>
    <script type="text/javascript" src="pop.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtFName" runat="server">www.dotnetcurry.com</asp:TextBox>&nbsp;
        <br />
        <br />
        <asp:Button ID="btnPopup" runat="server" Text="Show Popup" />&nbsp;</div>
    </form>
</body>
</html>
