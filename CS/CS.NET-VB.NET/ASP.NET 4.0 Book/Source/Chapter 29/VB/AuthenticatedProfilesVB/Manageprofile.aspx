<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Manageprofile.aspx.vb" Inherits="Manageprofile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="Txtnumprofiles" runat="server"></asp:TextBox>
		<br />
		<br />
		<br />
		<span lang="en-us">Delete Inactive Profiles </span>
		<asp:Button ID="Btndelete" runat="server" onclick="Btndelete_Click" 
		style="margin-left: 83px" Text="Delete" />
		<br />
		<br />
		<br />
		<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<br />
		<br />
		<span lang="en-us">
		</span>
		<br />
		<a href="Displayprofile.aspx">Home</a>
		&nbsp;&nbsp;
		<a href="Login.aspx">Login</a>
		&nbsp;&nbsp;
		<a href="CreateUser.aspx">Create New User</a>

    </div>
    </form>
</body>
</html>
