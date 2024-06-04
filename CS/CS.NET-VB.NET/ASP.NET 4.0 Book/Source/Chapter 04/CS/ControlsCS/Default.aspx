<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Controls Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Controls Example" 
 				  Font-Bold="True" Font-Names="Verdana"
				Font-Size="Large" style="text-align: center"></asp:Label><br />
				<br />
				<asp:Button ID="Button1" runat="server" Text="Enable /Disable Text Box" ToolTip="Button ToolTip" OnClick="Button1_Click" />
				<br />
				<br />
				<asp:Button ID="Button2" runat="server" Text="Show / Hide Text Box" OnClick="Button2_Click" /><br />
				<br />
				<asp:Button ID="Button3" runat="server" Text="Change Text Box Style" OnClick="Button3_Click" />&nbsp;<br />
				<br />
				<asp:Label ID="Label3" runat="server" 
				Text="First textbox associated with button clicks:"></asp:Label>
				&nbsp;<asp:TextBox ID="TextBox1" runat="server"
 				 AccessKey="T"></asp:TextBox>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label
				ID="Label2" runat="server" Text="Label"></asp:Label><br />
				<br />
				&nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" 
 				  AutoPostBack="True" Text="Select Me" 
 				  OnCheckedChanged="CheckBox1_CheckedChanged" />&nbsp;
				<br />
				<br />
				<asp:Label ID="Label4" runat="server" 
				Text="Second textbox associated with checkbox:"></asp:Label>
				<asp:TextBox ID="TextBox2" runat="server" Width="228px" 
 				  ></asp:TextBox>
    </div>
    </form>
</body>
</html>
