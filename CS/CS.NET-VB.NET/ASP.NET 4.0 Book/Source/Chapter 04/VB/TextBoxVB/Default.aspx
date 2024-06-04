<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Text Box Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" 
				Text="TextBox example showing types of TextBox controls" 
				Font-Underline="True"></asp:Label>
				<br />
				<br />
				<br />
				<asp:Button ID="Button1" runat="server" Text="Click me" 
 				  Width="125px" onclick="Button1_Click" />
				&nbsp;
				<asp:TextBox ID="TextBox1" runat="server" Width="262px" 
 				  ></asp:TextBox><br />

				<asp:TextBox ID="TextBox4" runat="server" Rows="10"
 				  TextMode="MultiLine"></asp:TextBox><br />
			</div>
			<asp:Label ID="Label1" runat="server" Text="Enter Password"></asp:Label>
			<br />
			<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
 			  Width="172px" 
			></asp:TextBox>&nbsp;
			&nbsp;<br />
			<asp:TextBox ID="TextBox3" runat="server" Width="173px">
			</asp:TextBox><br />
    </div>
    </form>
</body>
</html>
