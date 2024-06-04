<%@ Page Language="VB" Theme="Theme1" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applying themes Example</title>
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
			    <strong><em>Applying Themes at Runtime<br />
			</em></strong>
			<br />
			<asp:Image ID="Image1" runat="server" ImageUrl="~/images/organisation.jpg" /><br />
			<br />
			<asp:Label ID="Label1" runat="server" Text="Enter your name in the text 
 			box"></asp:Label><br />
			&nbsp;
			<br />
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
			<br />
			<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
            Font-Size="Small" ForeColor="White" Text="Click to Submit" /><br />
			<br />
			    <br />
			Select Theme&nbsp;&nbsp;&nbsp; 
			<a href="Default.aspx?Theme=Theme1">Simple</a>
            <a href="Default.aspx?Theme=Theme2">Inverse</a>
			<br />
			<br />
			</div>	</div>
	</div>
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
			</div>
	

    </form>
</body>
</html>
