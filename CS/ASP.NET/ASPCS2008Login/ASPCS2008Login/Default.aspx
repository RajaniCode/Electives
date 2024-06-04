<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008Login._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sample Login, Roles and Profile Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Simple Login/CreateUserWizard/Profile Sample (<asp:LoginStatus ID="LoginStatus2"
                runat="server" />
            )</h1>
        <p>
            This is a simple sample that shows off the new ASP.NET 2.0 Login, Roles and Profile
            System.&nbsp;
        </p>
        <p>
            There are 5 pages on this site:
        </p>
        <p>
            <a href="Login.aspx">Login.aspx</a> - this page uses the new asp:login control to
            allow users to login to the system</p>
        <p>
            <a href="CreateNewWizard.aspx">CreateNewWizard.aspx</a> -- this page allows a user
            to create a new account, join some roles, and set some profile settings</p>
        <p>
            <a href="MyProfile.aspx">MyProfile.aspx</a> -- this page allows a logged in user
            view their profile settings</p>
        <p>
            <a href="RecoverPassword.aspx">RecoverPassword.aspx</a> -- this page allows a user
            to reset their password and receive a new one through email</p>
        <p>
            <a href="ChangePassword.aspx">ChangePassword.aspx</a> -- this page allows a user
            to change their password</p>
    
    </div>
    </form>
</body>
</html>

