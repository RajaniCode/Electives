<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using Partioning Operators</title>
	<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="header">
			<h1>
				ASP.NET 4.0 Black Book
			</h1>
		</div>
		<div id="sidebar">
			<div id="nav">
				&nbsp;
			</div>
		</div>
		<div id="content">
			<div class ="itemContent">
			Displays data in Listbox by using partioning operators
			<asp:ListBox ID="ListBox1" runat="server" Height="211px" 
			style="margin-left: 199px; margin-top: 91px" Width="209px"></asp:ListBox>
			<br />
			<asp:Button ID="Button1" runat="server" style="margin-left: 211px" 
			Text="Display" Width="108px" />
			</div>
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		</div>
	</div>
	</form>
</body>
</html>
