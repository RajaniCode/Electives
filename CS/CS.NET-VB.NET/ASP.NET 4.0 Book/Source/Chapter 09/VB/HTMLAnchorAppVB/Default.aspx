<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" 		Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 		"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>HTML Anchor Example</title>
	<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="mainForm" runat="server">
		<div>
		<div id="header">
		<h1>
		ASP.NET 4.0 Black Book</h1>
		</div>
		<div id="sidebar">
		<div id="nav">
		&nbsp;
		</div>
		</div>
		<div id="content">
			<div class="itemContent">
			<br />
			<asp:Label ID="Label1" runat="server" Text="HTML Anchor example"></asp:Label><br />
			<br />
			<br />
			<a id="HTMLAnchor1" runat="server">Click here</a>
			<br />
			<br />
			<span id="span1" runat="server"></span>
			&nbsp;</div>
			<div id="footer">
			<p class="left">
			All content copyright &copy; Kogent Solutions Inc.</p>
		</div>
		</div>
		</div>
	</form>
</body>
</html>
