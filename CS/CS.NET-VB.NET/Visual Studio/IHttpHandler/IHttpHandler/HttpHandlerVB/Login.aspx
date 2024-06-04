<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="HttpHandlerVB.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Log in please</h1>
        <p>
            <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate">
            </asp:Login>
        </p>
    </div>
    </form>
</body>
</html>
