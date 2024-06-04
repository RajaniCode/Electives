<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPCS2008Login.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid"
            BorderWidth="1px" CreateUserText="Create New User" CreateUserUrl="~/CreateNewWizard.aspx"
            DestinationPageUrl="Default.aspx" Font-Names="Verdana" Font-Size="10pt" PasswordRecoveryText="Forgot Password?"
            PasswordRecoveryUrl="recoverpassword.aspx">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
