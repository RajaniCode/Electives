<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using Extension Method</title>
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
			Retrieves data using Extensions Method
			<br />
			<asp:ListBox ID="ListBox1" runat="server" Height="156px" 
			style="margin-left: 1px; margin-top: 65px;" 
 			Width="191px"></asp:ListBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" Text="Use Extension Methods" 
			style="margin-left: 209px" Width="176px" onclick="Button1_Click" />
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
