<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter Name and path of File "></asp:Label>
			<asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox>		
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
		<asp:Button ID="Btnshow" runat="server" Text="Show" 
		Width="78px" style="margin-left: 204px" onclick="Btnshow_Click" />
		<br />
		<br />
		<br />
		<asp:TextBox ID="TextBox2" runat="server" Height="183px" TextMode="MultiLine" 
		Width="287px"></asp:TextBox>
		<br />
		<br />
		<br />
		<br />
    </div>
    </form>
</body>
</html>
