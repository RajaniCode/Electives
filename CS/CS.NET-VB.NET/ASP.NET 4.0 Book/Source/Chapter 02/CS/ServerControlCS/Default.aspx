<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server Controls</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
		<asp:Label ID="Label1" runat="server" Text="Select 						  Title"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList1" 				  runat="server">
		<asp:listitem >Mr</asp:listitem>
		<asp:listitem >Mrs</asp:listitem>
		<asp:listitem >Miss</asp:listitem>
		</asp:DropDownList>
		&nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Enter 					  Name"></asp:Label>
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
		<br />
		&nbsp; &nbsp;<br />
		&nbsp; &nbsp;
		<asp:Button ID="Button1" runat="server" Text="Submit" 
            onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
