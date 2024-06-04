<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Welcome.aspx.vb" Inherits="Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Welcome"></asp:Label>&nbsp;
		<asp:LoginName ID="LoginName1" runat="server" FormatString="{0}!" />
		<br />
		<br />
		<asp:LoginStatus ID="LoginStatus1" runat="server" 
		LogoutAction="RedirectToLoginPage"
		LogoutPageUrl="~/login.aspx" />
		<br />
		Course name:<b> <%=Profile.CourseName%> </b>
		<br />
		<b>
		<br />
		Course duration:</b> <%=Profile.CourseDuration%>

    </div>
    </form>
</body>
</html>
