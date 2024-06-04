<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Displayprofile.aspx.cs" Inherits="Displayprofile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Literal ID ="Literal1" runat ="server" Text="<h1>Welcome</h1>"> 
		</asp:Literal>
		<span><br />
        Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
				<p>
		<span >Country&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:Label ID="Country" runat="server" Text="Label"></asp:Label>
		</p>
		<p>
		<span >Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:Label ID="Gender" runat="server" Text="Label"></asp:Label>
		</p>
		<input id="Button1" type="button" value="Exit" onclick="window.close()" class="style2" />
        <br />
        <a href="Manageprofile.aspx">ManageProfiles</a>
    </div>
    </form>
</body>
</html>
