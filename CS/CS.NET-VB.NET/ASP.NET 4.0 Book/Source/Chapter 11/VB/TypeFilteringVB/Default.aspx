<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TypeFiltering Example</title>
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
			&nbsp;Retrives data after filtering type of data<asp:ListBox ID="ListBox1" runat="server" Height="125px" 
			style="margin-left: 98px; margin-top: 73px" Width="145px"></asp:ListBox>
			<br />
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Button1" runat="server" style="margin-left: 102px" 
			 Text="Type Filtering" Width="143px" onclick="Button1_Click1" />
			</div>
			<div id="footer">
			<p class="left">
				All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		</div>
	</form>
</body>
</html>   
