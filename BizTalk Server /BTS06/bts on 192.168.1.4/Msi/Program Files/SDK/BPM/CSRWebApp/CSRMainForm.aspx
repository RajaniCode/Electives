<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSRMainForm.aspx.cs" Inherits="CSRMainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>CSR WebForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body>
		<form id="Form2" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 80px; POSITION: absolute; TOP: 32px" runat="server"
				Width="448px" Font-Bold="True" Height="24px">Southridge Video Customer Service Rep Order Entry Form</asp:Label>
			<asp:Label id="CustomerIDLabel" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 104px" runat="server"
				Width="80px">Customer ID</asp:Label>
			<asp:Label id="OrderIDLabel" style="Z-INDEX: 103; LEFT: 112px; POSITION: absolute; TOP: 136px" runat="server">Order ID</asp:Label>
			<asp:TextBox id="CustomerIDTextBox" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 104px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="OrderIDTextBox" style="Z-INDEX: 105; LEFT: 184px; POSITION: absolute; TOP: 136px"
				runat="server"></asp:TextBox>
			<asp:Label id="ServiceTypeCodeLabel" style="Z-INDEX: 106; LEFT: 48px; POSITION: absolute; TOP: 200px" runat="server">Service Type Code</asp:Label>
			<asp:DropDownList id="OrderTypeCodeDropDownList" style="Z-INDEX: 107; LEFT: 184px; POSITION: absolute; TOP: 200px"
				runat="server">
				<asp:ListItem Value="UNKNOWN" Selected="True">Select Service Type</asp:ListItem>
				<asp:ListItem Value="NS">New Standard Service</asp:ListItem>
				<asp:ListItem Value="ND">New Deluxe Service</asp:ListItem>
				<asp:ListItem Value="XS">Cancel Standard Service</asp:ListItem>
				<asp:ListItem Value="XD">Cancel Deluxe Service</asp:ListItem>
				<asp:ListItem Value="CS">Change Standard Service</asp:ListItem>
				<asp:ListItem Value="CD">Change Deluxe Service</asp:ListItem>
			</asp:DropDownList>
			<asp:Button id="SubmitButton" style="Z-INDEX: 108; LEFT: 72px; POSITION: absolute; TOP: 256px" runat="server"
				Text="Submit Order" OnClick="SubmitButton_Click"></asp:Button>
            &nbsp;
			<asp:Label id="CSRMessageLabel" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 344px"
				runat="server" Width="616px" Height="224px"></asp:Label>
			<asp:Label id="LastMessageSentLabel" style="Z-INDEX: 111; LEFT: 40px; POSITION: absolute; TOP: 304px" runat="server">Last Message Sent</asp:Label>
			<asp:Button id="TerminateButton" style="Z-INDEX: 112; LEFT: 192px; POSITION: absolute; TOP: 256px" runat="server"
				Text="Terminate Order" OnClick="TerminateButton_Click"></asp:Button>
            <asp:Label ID="SequenceNumberLabel" runat="server" Style="z-index: 102; left: 56px;
                position: absolute; top: 168px" Width="120px">Sequence Number</asp:Label>
            <asp:TextBox ID="SequenceNumberTextBox" runat="server" Style="z-index: 105; left: 184px;
                position: absolute; top: 168px">1</asp:TextBox>
        </form>
</body>
</html>
