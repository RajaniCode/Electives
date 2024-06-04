<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cross-Page Posting</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter your name:
	<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
 	 Width="152px"></asp:TextBox>
	&nbsp;<br />
	<br />
	<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
	<br />
    </div>
    <asp:Button ID="Button1" runat="server" Text="Same Page Post Back" 
 	 OnClick="Button1_Click" />
	&nbsp;<asp:Button ID="Button2" runat="server" Text="Cross Page Post Back" 
 	 PostBackUrl="~/Default2.aspx" />
	<p>
		<asp:Label ID="Label1" runat="server"></asp:Label>
	</p>
    </form>
</body>
</html>
