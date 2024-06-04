<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Calendar Control Example" 
			Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
 			  <br />
			<br />
			<asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
 			  BorderColor="#FFCC66"
			BorderWidth="1px" Caption="Select Date and Month:" 
 			  DayNameFormat="Shortest" Font-Names="Verdana"
			Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" 
 			  Width="220px">
			<SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
			<SelectorStyle BackColor="#FFCC66" />
			<OtherMonthDayStyle ForeColor="#CC9966" />
			<TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
			<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
			<DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
			<TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
 			  ForeColor="#FFFFCC" />
			</asp:Calendar>
			<br />
			<asp:TextBox ID="TextBox1" runat="server" Width="316px"></asp:TextBox> 
    </div>
    </form>
</body>
</html>
