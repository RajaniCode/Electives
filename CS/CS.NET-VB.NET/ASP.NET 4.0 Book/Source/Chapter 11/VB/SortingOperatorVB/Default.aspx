<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Using Sorting operators </title>
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
			<asp:ListBox ID="ListBox1" runat="server" Height="126px" 
			style="margin-left: 157px; margin-top: 82px" Width="225px"></asp:ListBox>
			<br />
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" 
			style="margin-left: 199px; height: 26px;" Text="Ascending" Width="97px" />
			<asp:Button ID="Button2" runat="server" 
			style="margin-left: 35px; margin-top: 0px" Text="Descending" />
			</div>
			<div id="footer">
				<p class="left">
				All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		</div>
	</form>
</body>
</html>
