<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RadioButton Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="RadioButton Control Example"></asp:Label>
			<br />
			<br />
			<asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red" 
			Text="Select the car you want to buy:"></asp:Label>
			<br />
			<asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#0000CC" 
			Text="Maruti Zen" oncheckedchanged="RadioButton1_CheckedChanged" />
			<br />
			<asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#0000CC" 
			Text="Toyota Corolla" oncheckedchanged="RadioButton2_CheckedChanged" />
			<br />
			<asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#0000CC" 
			Text="Maruti Esteem" oncheckedchanged="RadioButton3_CheckedChanged" />
			<br />
			<asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#0000CC" 
			Text="Honda City" oncheckedchanged="RadioButton4_CheckedChanged" />
			<br />
			<asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" 
			Font-Size="Small" ForeColor="#0000CC" 
			Text="Hyundai Santro" oncheckedchanged="RadioButton5_CheckedChanged" />
			<br />
			<br />
			<asp:Label ID="Label3" runat="server" Font-Size="Small" 
 			  ForeColor="#FF6600"></asp:Label>

    </div>
    </form>
</body>
</html>
