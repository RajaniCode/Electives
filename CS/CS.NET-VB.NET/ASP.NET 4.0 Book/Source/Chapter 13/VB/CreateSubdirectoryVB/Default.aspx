<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Create a SubDirectory<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Lblsource" runat="server" Font-Bold="True" Font-Italic="True" Text="Enter path and name of source directory"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1"  runat="server" style="margin-left: 0px" 
            Width="231px"></asp:TextBox>
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Lbldestination" runat="server" Font-Bold="True" Font-Italic="True" Text="Enter name of Subdirectory "></asp:Label>

		<asp:TextBox ID="TextBox2" runat="server" Width="238px"></asp:TextBox>
		<br />
		<br />
		<br />		
		<asp:Button ID="BtnCreate" runat="server"  Font-Bold="True" Font-Italic="False" 
            Text="Create SubDirectory" Width="182px"   />
		<br />
		<br />
		<br />		
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
    </div>
    </form>
</body>
</html>
