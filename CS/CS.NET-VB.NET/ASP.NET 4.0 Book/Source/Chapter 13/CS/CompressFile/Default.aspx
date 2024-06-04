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
		Text="Enter path and name of source file"></asp:Label>
		<span lang="en-us">
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;
		</span>
		<asp:TextBox ID="Txtsrc" runat="server"></asp:TextBox>
		&nbsp;<br />
		<br />
		<br />
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:Label ID="Label2" runat="server" Text="Enter path and name of destination" 
		Font-Bold="True" Font-Italic="True"></asp:Label>
		<span lang="en-us">
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</span>
		<asp:TextBox ID="Txtdestination" runat="server"></asp:TextBox>
		<br />
		<br />
		<br />
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</span>
		<asp:Button ID="Btncompress" runat="server"
		Text="Compress " Width="147px" onclick="Btncompress_Click" />
		<br />
		<br />
		<br />
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:Label ID="lbldisplay" runat="server" Font-Bold="True" Font-
 		Italic="True"></asp:Label>

    </div>
    </form>
</body>
</html>
