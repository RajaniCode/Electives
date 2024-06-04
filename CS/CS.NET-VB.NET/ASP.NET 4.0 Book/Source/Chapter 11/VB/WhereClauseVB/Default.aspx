<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Where Clause Demo</title>
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
				Displays data in the listbox according to the condition 
				specified in the where clause.
				<br />
				<asp:ListBox ID="ListBox1" runat="server" Height="117px" 
				style="margin-left: 36px; margin-top: 35px" 
 				Width="135px"></asp:ListBox>
				<br />
				<br />
				<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
				style="margin-left: 30px" Text="Using Where clause" Width="144px" />
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
