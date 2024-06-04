<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupWin.aspx.cs" Inherits="PopupWin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Popup Page</title>
    <script type="text/javascript" src="pop.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtReverse" runat="server"></asp:TextBox><br />
        <br />
        <input class="button" type="button" id="btnReverse" value="Reverse value back" onclick="ReverseString();" />&nbsp;</div>
    </form>
</body>
</html>
