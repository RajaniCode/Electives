<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Welcome.aspx.vb" Inherits="Welcome" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    WELCOME!<asp:LoginName ID="LoginName1" runat="server" /><br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" 
            LogoutPageUrl="~/Login.aspx" />        
    </div>
    </form>
</body>
</html>
