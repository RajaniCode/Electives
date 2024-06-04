<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CheckBox Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="CheckBox Example"></asp:Label>
			<br />
			<br />
			<asp:Label ID="Label2" runat="server" Font-Size="Small" 
 			  ForeColor="#FF0066" 
			Text="Which of these cars you own?"></asp:Label>
			<br />
			<br />
			<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
			Font-Size="Small" Text="Maruti Zen" oncheckedchanged="CheckBox1_CheckedChanged1" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 			 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 			 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
			<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
			Font-Size="Small" Text="Honda City" oncheckedchanged="CheckBox2_CheckedChanged1" />
			<br />
			<asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" 
			Font-Size="Small" Text="Toyota Corolla" 
            oncheckedchanged="CheckBox3_CheckedChanged1" />
			<br />
			<asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True" 
			Font-Size="Small" Text="Hyundai Santro" 
            oncheckedchanged="CheckBox4_CheckedChanged1" />
			<br />
			<asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" 
			Font-Size="Small" Text="Maruti Swift" 
            oncheckedchanged="CheckBox5_CheckedChanged1" />
			<br />
			<br />
			<br />
			<asp:ListBox ID="ListBox1" runat="server" Height="102px" Width="118px">
			</asp:ListBox>
    </div>
    </form>
</body>
</html>
