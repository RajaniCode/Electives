<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	Displays list of subdirectory for the directory mentioned in the text box.
		<br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter path and name of directory"></asp:Label>
		
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<br />
		&nbsp;<br />
		<br />
		
		<asp:Button ID="Btnshow" runat="server" onclick="Btnshow_Click" 
		Text="Show SubDirectories" />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:ListBox ID="ListBox1" runat="server" Height="181px" Width="269px">
		</asp:ListBox>


    </div>
    </form>
</body>
</html>
