<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <b> Displays list of Drives available on your system</b>
				<br />
				<br />
				<br />
        <asp:Button ID="BtnShow" runat="server" Text="Show Drives" />
				
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
				
				<br />
				<br />
				<br />
			
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
				<br />
				<br />
				
				<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" ></asp:Label>
				<br />
			
				<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" ></asp:Label><br/>
			
				<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" ></asp:Label>
				<br />	

    </div>
    </form>
</body>
</html>
