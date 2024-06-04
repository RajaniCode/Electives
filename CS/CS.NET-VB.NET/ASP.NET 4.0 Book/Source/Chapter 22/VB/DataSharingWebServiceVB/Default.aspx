<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Use of Type Sharing 
 			Webservice" Font-Bold="True"
			ForeColor="Black"></asp:Label>&nbsp;<br />
			<br />
			<asp:Button ID="BtnPopulate" runat="server" Text="Populate Employee 
 			Details" OnClick="BtnPopulate_Click" />
			<br />
			<br />
			<asp:Label ID="lblPopEmpDetails" runat="server"></asp:Label>
			<br />
			<br />
			<asp:Button ID="BtnUpdateDetails" runat="server" Text="Update Details" 
 			OnClick="BtnUpdateDetails_Click" /><br />
			<br />
			<asp:Label ID="EmpDetailsLabel" runat="server"></asp:Label><br />
			<br />
			<asp:Label ID="ErrEmpDetails" runat="server" 
 			ForeColor="#C00000"></asp:Label>

    </div>
    </form>
</body>
</html>
