<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    Enter Role Name:<br />
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<asp:Label ID="Label1" runat="server" Text="Label" Visible="False" 
 		  Width="314px"></asp:Label><br />
		<asp:Button ID="BtnCreate" runat="server" onclick="BtnCreate_Click" Text="Create Roles" />
		&nbsp;<asp:Button ID="BtnDelete" runat="server" onclick="BtnDelete_Click"  style="margin-left: 81px" Text="Delete Roles" />
		<br />
		<br />
		<asp:DropDownList ID="Dropgetallroles" runat="server">
		</asp:DropDownList>
        <br />
        <br />
        <br />
        <hr style="background-color:Black"/>
<span style="color: #000000">
        <br />
        Enter user name:<br />
</span>
<asp:TextBox ID="Txtusername" runat="server"></asp:TextBox><br />
		<span style="color: #000000">Enter Role:</span><br />
		<asp:TextBox ID="TxtRolename" runat="server"></asp:TextBox>
		<asp:Label ID="Label2" runat="server"></asp:Label><br />
		<br />
		<asp:Button ID="BtnAdd" runat="server" onclick="BtnAdd_Click" Text="Add User" Width="103px" />
		<asp:Button ID="BtnDelUser" runat="server" style="margin-left: 63px" Text="Delete User" onclick="BtnDelUser_Click" />
		<br />
		<br />
		<asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="100px" style="margin-left: 136px" Width="191px">
		<FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
		<RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
		<PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
	</asp:GridView>


    </div>
    </form>
</body>
</html>
