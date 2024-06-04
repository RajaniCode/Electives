<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
	static string GetTime(HttpContext context)
	{
		return DateTime.Now.ToString("T");
	} 
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Substitution control</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>
		Using Substitution Control</h2>
		<div class="itemContent" style="font-family: 'Book Antiqua'; font-size: large">
		The Cached time is:<br />
		<%=DateTime.Now.ToString("T")%>
		<hr />
		The Substitution time is:
		<br />
		<asp:Substitution ID="Substitution1" MethodName="GetTime" runat="server" />

    </div>
    </form>
</body>
</html>
