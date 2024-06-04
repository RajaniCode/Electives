<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <strong><span style="text-decoration: underline"><em>Calculate Simple 
 			 Interest using
			the Web Service<br />
			</em></span></strong>
			<br />
			<asp:Label ID="Label1" runat="server" Text="Principal" 
 			Width="66px"></asp:Label>
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 			&nbsp;<asp:TextBox ID="txtPrincipal"
			runat="server"></asp:TextBox><br />
			<br />
			<asp:Label ID="Label2" runat="server" Text="Rate" 
 			Width="63px"></asp:Label>
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
			<asp:TextBox ID="txtRate" runat="server"></asp:TextBox><br />
			<br />
			<asp:Label ID="Label3" runat="server" Text="Duration" 
 			Width="63px"></asp:Label>
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
			<asp:TextBox ID="txtDuration" runat="server"></asp:TextBox>
			<br />
			<br />
			<asp:Label ID="Label4" runat="server" Text="Simple Interest" 
 			Width="105px"></asp:Label>
			&nbsp; &nbsp; &nbsp; &nbsp;
			<asp:TextBox ID="txtSimpleInterest" runat="server"></asp:TextBox><br />
			<br />
			<asp:Label ID="Label5" runat="server" Width="66px"></asp:Label>
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
			<asp:Button ID="Button1" runat="server" Text="Calculate Simple Interest" 
 			Width="220px" onclick="Button1_Click" />

    </div>
    </form>
</body>
</html>
