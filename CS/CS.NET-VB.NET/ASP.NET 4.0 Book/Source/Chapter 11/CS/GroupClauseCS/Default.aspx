<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using Group Clause</title>
		<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
		<style type="text/css">
		.itemContent
		{
			height: 309px;
			width: 530px;
		}
		</style>
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
				&nbsp;
			</div>
		</div>
		<div id="content">
			<div class ="itemContent">
				<br />
				<br />
				Displays data by using GroupBy clause<br />
				&nbsp;<br />
				&nbsp;<asp:ListBox ID="ListBox1" runat="server" Height="150px" 
 				style="margin-left: 120px" 
				Width="295px"></asp:ListBox>
				<br />
				<br />
				<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
				style="margin-left: 152px" Text="Display" Width="105px" />
				<br />
			</div>              
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc. </p>            
			</div>
		</div>
	</form>
</body>
</html>
