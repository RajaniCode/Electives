<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       Reading contents of a file on a screen 
		<br />
        <br />
		<br />

   <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter path and name of File"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="232px"></asp:TextBox>
				<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
		<asp:TextBox ID="TextBox2" runat="server" Height="206px" TextMode="MultiLine" 
		Width="628px"></asp:TextBox>
		<br />
		<br />		
		<asp:Button ID="BtnRead" runat="server" Text="Read " 
		Width="89px" onclick="BtnRead_Click" />		
		&nbsp;&nbsp;&nbsp;		
		
        
        <asp:Button ID="BtnAppend" runat="server" Text="Append text" /><br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label> 
    </div>
    </form>
</body>
</html>

    