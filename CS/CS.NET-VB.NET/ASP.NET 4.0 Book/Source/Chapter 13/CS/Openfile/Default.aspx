<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>Open a existing file<span lang="en-us"> and writes into the file.</span><br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Lblpath" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter the path and name of a file"></asp:Label>
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="271px"></asp:TextBox>
		</span>
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
		<br />
		<br />
		
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter text to replace data of file"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;
		
		<asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="55px" 
		Width="177px"></asp:TextBox>
		<br />
				<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Btnfile" runat="server" Font-Bold="True" Font-Italic="True" 
		onclick="Btnfile_Click" Text="Open File" Width="144px" />
	
		<br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Lbldisplay" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>

    
    </div>
    </form>
</body>
</html>
