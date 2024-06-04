<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Type the text here 
		<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 25px" 
		Width="169px"></asp:TextBox>
		<br />
		<br />
		SHA1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" Height="20px" 
		style="margin-left: 68px; margin-top: 66px" Width="310px" 
            ></asp:TextBox>
		<br />
		<br />
        SHA256 <asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="310px" style="margin-left: 68px"></asp:TextBox>
        <br />
        <br />
        SHA384<asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="310px" style="margin-left: 68px"></asp:TextBox>
        <br />
        <br />
        SHA512<asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="310px" style="margin-left: 68px"></asp:TextBox><br />
		<br />
		<asp:Button ID="Btnsha1" runat="server" Font-Bold="True" 
		onclick="Btnsha1_Click" style="margin-left: 42px" Text="SHA1" Width="80px" />
		<asp:Button ID="btnsh256" runat="server" Font-Bold="True" 
		onclick="btnsh256_Click" style="margin-left: 42px; margin-top: 31px" 
		Text="SHA256" />
		<asp:Button ID="Btnsh384" runat="server" Font-Bold="True" 
		onclick="Btnsh384_Click" style="margin-left: 30px" Text="SHA384" Width="66px" />
		&nbsp;<asp:Button ID="BTN512" runat="server" Font-Bold="True" 
 		onclick="BTN512_Click" 
		style="margin-left: 18px" Text="SHA512" />

    </div>
    </form>
</body>
</html>
