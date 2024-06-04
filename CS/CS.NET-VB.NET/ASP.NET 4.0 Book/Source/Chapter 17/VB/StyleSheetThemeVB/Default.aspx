<%@ Page Language="VB" AutoEventWireup="false" StylesheetTheme="Theme1" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StyleSheetTheme Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
			<div class="itemContent">
			<div style="text-align: left">
           
			<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
			<br />
			<br />
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" Text="Button" ForeColor="Aqua" 
 			BackColor="DarkViolet" />
			</div></div>
	</div>
			<div id="footer">
			<p class="left">
				All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		

    </form>
</body>
</html>
