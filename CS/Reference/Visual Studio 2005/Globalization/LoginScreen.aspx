<%@ Page Language="C#"  
    AutoEventWireup="true" 
    CodeFile="LoginScreen.aspx.cs"  
    Inherits="_Default" 
    Culture="auto"  
    meta:resourcekey="LoginScreen" 
    UICulture="auto"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label 
                ID="lblUserId" 
                runat="server" 
                Text="User Id" meta:resourcekey="lblUserIdResource1"  Width="80px"></asp:Label>
        
        <asp:TextBox ID="txtUserID" runat="server" meta:resourcekey="txtUserIDResource1"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" Text="Password" runat="server" Width="80px" meta:resourcekey="lblPasswordResource1"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" meta:resourcekey="txtPasswordResource1" ></asp:TextBox></div>
    </form>
</body>
</html>
