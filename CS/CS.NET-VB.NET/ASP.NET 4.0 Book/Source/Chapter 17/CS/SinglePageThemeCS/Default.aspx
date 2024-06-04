<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applying Theme to a Single Page</title>
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
		<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<br />
		<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" SkinID="TextBox"></asp:TextBox>
		<br /><br />
		<asp:Button ID="Button1" BackColor="Black" Font-Bold="True" 
            Font-Size="Small" ForeColor="White" runat="server" Text="Button" />
		<div id="footer">
			<p class="left">
				All content copyright &copy; Kogent Solutions Inc.</p>
		</div>
	</div>

    
    </form>
</body>
</html>
