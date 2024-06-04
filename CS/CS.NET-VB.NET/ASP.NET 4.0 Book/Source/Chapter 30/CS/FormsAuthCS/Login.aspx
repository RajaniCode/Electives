<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="z-index: 150; left: 250px; position: absolute; top: 75px; width: 
 		  361px; height: 114px;">
		<tr>
			<td style="height: 25px">Enter User Name:</td>
			<td style="height: 25px"><asp:TextBox ID="textBox1" runat="server" 
 			  Width="126px"/></td>
			<td style="height: 25px;">
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
 			  ControlToValidate="textBox1" Display="Static" ErrorMessage="*" 
 			  runat="server"/>
			</td>
		</tr>
		<tr>
			<td style="height: 25px">Enter Password:</td>
			<td style="height: 25px"><asp:TextBox ID="textBox2" runat="server"  
 			  TextMode="Password"/></td>
			<td style="height: 25px;"><asp:RequiredFieldValidator 
 			  ID="RequiredFieldValidator2" ControlToValidate="textBox2" 
 			  Display="Static" ErrorMessage="*" runat="server"/>
			</td>
		</tr>
		<tr>
			<td style="height: 25px" colspan="3">
			<asp:CheckBox ID="checkBox1" runat="server" Text="Persistent 
 			  Cookie"/></td>                            
		</tr>
		<tr><td style="height: 25px"></td></tr>
		<tr>
			<td style="height: 25px"></td>
			<td style="height: 25px; left: 500px">
			<asp:Button ID="button1" Text="Login" runat="server" 
 			  OnClick="login_Click" Width="75px" />
			</td>
			<td></td>
		</tr>
		<tr><td style="height: 25px"></td></tr>
		<tr>
			<td colspan="3"><asp:Label ID="label1" runat="server" Text=""/></td>
		</tr>
		</table>                

    </div>
    </form>
</body>
</html>
