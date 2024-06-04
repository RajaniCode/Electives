<%@ Page Language="C#" 
    AutoEventWireup="true" 
     CodeFile="LoginScreenUsingStrongType.aspx.cs" 
     Inherits="Globalization._Default" 
     Culture="en-US"  
     UICulture="auto"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label 
                ID="lblUserId" 
                runat="server" 
                Width="152px" Height="32px"></asp:Label>
        
        <asp:TextBox ID="txtUserID" runat="server" meta:resourcekey="txtUserIDResource1" ></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword"    runat="server" Width="152px" meta:resourcekey="lblPasswordResource1" Height="32px"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" meta:resourcekey="txtPasswordResource1" ></asp:TextBox>
        <br />
        <asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" meta:resourcekey="ddlLanguagesResource1" >
            <asp:ListItem Value="en-us" meta:resourcekey="ListItemResource1" Text="English"></asp:ListItem>
            <asp:ListItem Value="el-gr" meta:resourcekey="ListItemResource2" Text="Greek"></asp:ListItem>
        </asp:DropDownList></div>
    </form>
</body>
</html>
