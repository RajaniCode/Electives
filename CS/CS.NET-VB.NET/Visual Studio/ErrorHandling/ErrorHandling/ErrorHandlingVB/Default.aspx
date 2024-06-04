<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Test Error Handling</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnHandled" runat="server" Text="Throw Handled Exception" Width="237px" /><br />
        <br />
        <asp:Button ID="btnUnhandled" runat="server" OnClick="btnUnhandled_Click" Text="Throw Unhandled Exception" /></div>
    </form>
</body>
</html>