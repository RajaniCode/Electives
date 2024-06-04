<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="ASPCS2008Login.MyProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>My Profile Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Profile Settings for: <asp:LoginName ID="LoginName1" runat="server" />
        </h1>
        
        <table>
            <tr>
                <td>Country:</td>
                <td><asp:Label ID="Country" runat="server" Text="Label"></asp:Label></td>
            </tr>
            
            <tr>
                <td>Gender:</td>
                <td><asp:Label ID="Gender" runat="server" Text="Label"></asp:Label></td>
            </tr>
        
            <tr>
                <td>Age:</td>
                <td><asp:Label ID="Age" runat="server" Text="Label"></asp:Label></td>
            </tr>        
        
             <tr>
                <td valign="top">Roles:</td>
                <td><asp:ListBox ID="RoleList" runat="server" /></td>
            </tr>       
        
        </table>
        
    </div>
    </form>
</body>
</html>

